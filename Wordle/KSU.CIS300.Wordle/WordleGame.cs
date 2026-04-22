using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KSU.CIS300.Wordle
{

    public class WordleGame
    {
        /// <summary>
        /// max word count for the decisiontree
        /// </summary>
        private const int _treeLimit = 1000;

        /// <summary>
        /// trie holding all valid word
        /// </summary>
        private readonly Trie _words;

        /// <summary>
        /// all valid word for current word length
        /// </summary>
        private readonly List<string> _validWordList;

        /// <summary>
        /// the length of words for this game
        /// </summary>
        private readonly int _wordLength;

        /// <summary>
        /// cached decision tree for fast hit
        /// </summary>
        private DecisionTreeNode<string>? _hintDecisionTree;

        /// <summary>
        /// guesses made when the current tree was built
        /// </summary>
        private int _hintTreeGuessIndex;

        /// <summary>
        /// the best opening guess
        /// </summary>
        private string _firstGuess = "SALET";

        public List<string> Guesses { get; private set; } = new List<string>();
        public List<string> Patterns { get; private set; } = new List<string>();
        public string TargetWord { get; private set; } = string.Empty;
        public int CurrentAttempt { get; private set; }
        public int MaxAttempts { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool IsWon { get; private set; }

        /// <summary>
        /// sets up a new game, picks a target word, and builds a decision tree if the word list is small enough
        /// </summary>
        /// <param name="wordList">the trie containing all valid words</param>
        /// <param name="wordLength">the length of words for this game</param>
        /// <param name="maxAttempts">the maximum number of guesses allowed</param>
        /// <param name="forcedTargetWord">if provided, uses this as the target word instead of picking randomly</param>
        /// <exception cref="ArgumentException">thrown if no valid words of the requested length exist</exception>
        public WordleGame(Trie wordList, int wordLength = 5, int maxAttempts = 6, string? forcedTargetWord = null)
        {
            _words = wordList;
            MaxAttempts = maxAttempts;

            if (forcedTargetWord != null)
            {
                _wordLength = forcedTargetWord.Length;
                TargetWord = forcedTargetWord.ToUpper();
            }
            else
            {
                _wordLength = wordLength;
            }

            _validWordList = _words.GetWordsByLength(_wordLength);

            if (forcedTargetWord == null)
            {
                if (_validWordList.Count == 0)
                    throw new ArgumentException("No valid words of the requested length exist.");
                Random rng = new Random();
                TargetWord = _validWordList[rng.Next(_validWordList.Count)];
            }

            if (_validWordList.Count >= 1 && _validWordList.Count <= _treeLimit)
            {
                _hintDecisionTree = BuildDecisionTree(_validWordList, _validWordList);
                _firstGuess = _hintDecisionTree.Value;
            }
        }

        /// <summary>
        /// generates a pattern string by comparing the guess to the target, handles duplicate letters correctly
        /// </summary>
        /// <param name="guess">the word being guessed</param>
        /// <param name="target">the secret target word</param>
        /// <returns>a pattern string where G is correct, Y is wrong position, X is not in word</returns>
        /// <exception cref="ArgumentException">thrown if guess and target have different lengths</exception>
        public static string GeneratePattern(string guess, string target)
        {
            if (guess.Length != target.Length)
                throw new ArgumentException("Guess and target must be the same length.");

            char[] pattern = new char[guess.Length];
            bool[] guessUsed = new bool[guess.Length];
            bool[] targetUsed = new bool[target.Length];

            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == target[i])
                {
                    pattern[i] = 'G';
                    guessUsed[i] = true;
                    targetUsed[i] = true;
                }
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (guessUsed[i]) continue;
                bool found = false;
                for (int j = 0; j < target.Length; j++)
                {
                    if (!targetUsed[j] && target[j] == guess[i])
                    {
                        pattern[i] = 'Y';
                        targetUsed[j] = true;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    pattern[i] = 'X';
            }

            return new string(pattern);
        }

        /// <summary>
        /// Calculates the Shannon entropy of <paramref name="guess"/> against
        /// <paramref name="possibleWords"/>. Entropy is highest when the guess splits
        /// the candidates into many equally-sized pattern groups.
        /// </summary>
        /// <param name="guess">The guess to evaluate</param>
        /// <param name="possibleWords">The current candidate words</param>
        /// <returns>The entropy value; 0 when the list is empty or all words produce the same pattern</returns>
        public static double CalculateEntropy(string guess, List<string> possibleWords)
        {
            if (possibleWords.Count == 0)
                return 0;

            Dictionary<string, int> patternCounts = new Dictionary<string, int>();

            foreach (string word in possibleWords)
            {
                string pattern = GeneratePattern(guess, word);
                if (patternCounts.ContainsKey(pattern))
                    patternCounts[pattern]++;
                else
                    patternCounts[pattern] = 1;
            }

            double entropy = 0;
            int totalWords = possibleWords.Count;

            foreach (int count in patternCounts.Values)
            {
                double probability = (double)count / totalWords;
                entropy -= probability * Math.Log2(probability);
            }

            return entropy;
        }

        /// <summary>
        /// returns the word from allWords with the highest entropy against the possible words
        /// </summary>
        /// <param name="possibleWords">the current list of candidate words</param>
        /// <param name="allWords">all valid words to evaluate as potential guesses</param>
        /// <returns>the word with the highest entropy, or empty string if no possibilities remain</returns>
        public static string FindBestGuess(List<string> possibleWords, List<string> allWords)
        {
            if (possibleWords.Count == 0) return string.Empty;
            if (possibleWords.Count == 1) return possibleWords[0];

            string bestGuess = string.Empty;
            double bestEntropy = -1;

            foreach (string guess in allWords)
            {
                double entropy = CalculateEntropy(guess, possibleWords);
                if (entropy > bestEntropy)
                {
                    bestEntropy = entropy;
                    bestGuess = guess;
                }
            }
            return bestGuess;
        }

        /// <summary>
        /// recursively builds a decision tree of optimal guesses based on entropy
        /// </summary>
        /// <param name="possibleWords">the current list of candidate words</param>
        /// <param name="allWords">all valid words to evaluate as potential guesses</param>
        /// <param name="maxDepth">the maximum depth of the tree, defaults to 6</param>
        /// <returns>the root node of the decision tree</returns>
        public static DecisionTreeNode<string> BuildDecisionTree(List<string> possibleWords, List<string> allWords, int maxDepth = 6)
        {
            if (possibleWords.Count == 0)
                return new DecisionTreeNode<string>(string.Empty);
            if (possibleWords.Count == 1 || maxDepth == 0)
                return new DecisionTreeNode<string>(possibleWords[0]);

            string bestGuess = FindBestGuess(possibleWords, allWords);
            DecisionTreeNode<string> root = new DecisionTreeNode<string>(bestGuess);

            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            foreach (string word in possibleWords)
            {
                string pattern = GeneratePattern(bestGuess, word);
                if (!groups.ContainsKey(pattern))
                    groups[pattern] = new List<string>();
                groups[pattern].Add(word);
            }

            foreach (var kvp in groups)
            {
                DecisionTreeNode<string> child = BuildDecisionTree(kvp.Value, allWords, maxDepth - 1);
                child.Label = kvp.Key;
                root.Children.Add(child);
            }

            return root;
        }

        /// <summary>
        /// attempts a guess and returns false if the game is over, the word is wrong length, or not in the trie
        /// </summary>
        /// <param name="guess">the word being guessed</param>
        /// <param name="pattern">the pattern result of the guess, empty string if invalid</param>
        /// <returns>true if the guess was valid, false otherwise</returns>
        public bool MakeGuess(string guess, out string pattern)
        {
            pattern = string.Empty;
            if (IsGameOver) return false;
            if (guess.Length != _wordLength) return false;
            if (!_words.Contains(guess)) return false;

            pattern = GeneratePattern(guess, TargetWord);
            Guesses.Add(guess);
            Patterns.Add(pattern);
            CurrentAttempt++;

            if (pattern == new string('G', _wordLength))
                IsWon = true;

            if (IsWon || CurrentAttempt >= MaxAttempts)
                IsGameOver = true;

            return true;
        }

        /// <summary>
        /// returns all words still consistent with the guesses and patterns so far
        /// </summary>
        /// <returns>a list of words that could still be the answer</returns>
        public List<string> GetRemainingPossibilities()
        {
            return _words.GetWordsMatchingPatterns(Guesses, Patterns, _wordLength);
        }

        /// <summary>
        /// returns the ai's best next guess based on the current game state using the decision tree or entropy
        /// </summary>
        /// <returns>the optimal next guess, or empty string if no possibilities remain</returns>
        public string GetBestGuess()
        {
            if (CurrentAttempt == 0) return _firstGuess;

            List<string> possibilities = GetRemainingPossibilities();
            if (possibilities.Count == 0) return string.Empty;

            if (_hintDecisionTree != null)
            {
                DecisionTreeNode<string> node = _hintDecisionTree;
                bool success = true;

                for (int i = _hintTreeGuessIndex; i < Guesses.Count; i++)
                {
                    if (node.Value != Guesses[i])
                    {
                        success = false;
                        break;
                    }
                    DecisionTreeNode<string>? next = node.Children.FirstOrDefault(c => c.Label == Patterns[i]);
                    if (next == null)
                    {
                        success = false;
                        break;
                    }
                    node = next;
                }

                if (success) return node.Value;
            }

            if (possibilities.Count <= _treeLimit)
            {
                _hintDecisionTree = BuildDecisionTree(possibilities, _validWordList);
                _hintTreeGuessIndex = Guesses.Count;
                return _hintDecisionTree.Value;
            }

            return FindBestGuess(possibilities, _validWordList);
        }

        /// <summary>
        /// resets the game state and picks a new random target word
        /// </summary>
        public void Reset()
        {
            Guesses = new List<string>();
            Patterns = new List<string>();
            CurrentAttempt = 0;
            IsGameOver = false;
            IsWon = false;
            Random rng = new Random();
            TargetWord = _validWordList[rng.Next(_validWordList.Count)];
        }
    }
}

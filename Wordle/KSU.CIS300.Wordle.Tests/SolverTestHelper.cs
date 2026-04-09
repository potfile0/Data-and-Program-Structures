// Author: Josh Weese
using System.Linq;
using KSU.CIS300.Wordle;

namespace KSU.CIS300.Wordle.Tests
{
    internal static class SolverTestHelper
    {
        public static string GetNextGuess(Trie words, int wordLength, List<string> previousGuesses, List<string> previousPatterns)
        {
            if (previousGuesses.Count != previousPatterns.Count)
                throw new ArgumentException("Guesses and patterns must have the same count");

            List<string> remaining = words.GetWordsMatchingPatterns(previousGuesses, previousPatterns, wordLength);

            if (remaining.Count == 0)
                return string.Empty;

            return WordleGame.FindBestGuess(remaining, remaining);
        }

        public static int SolveWord(Trie words, string targetWord, int wordLength, out List<string> guesses)
        {
            guesses = new List<string>();

            if (targetWord.Length != wordLength)
                return -1;

            List<string> allWords = words.GetWordsByLength(wordLength);
            string target = targetWord.ToUpper();
            List<string> patterns = new List<string>();
            int attempts = 0;
            const int maxAttempts = 10;

            while (attempts < maxAttempts)
            {
                string guess = attempts == 0
                    ? WordleGame.FindBestGuess(allWords, allWords)
                    : GetNextGuess(words, wordLength, guesses, patterns);

                if (string.IsNullOrEmpty(guess))
                    return -1;

                guesses.Add(guess);
                attempts++;

                string pattern = WordleGame.GeneratePattern(guess, target);
                patterns.Add(pattern);

                if (guess == target)
                    return attempts;
            }

            return -1;
        }

        public static Dictionary<string, double> GetGuessesWithEntropy(Trie words, int wordLength, List<string> remainingWords, int topN = 10)
        {
            if (remainingWords.Count == 0)
                return new Dictionary<string, double>();

            List<string> allWords = words.GetWordsByLength(wordLength);

            Dictionary<string, double> entropyMap = new Dictionary<string, double>();

            foreach (string guess in allWords.Take(Math.Min(allWords.Count, 500)))
                entropyMap[guess] = WordleGame.CalculateEntropy(guess, remainingWords);

            return entropyMap
                .OrderByDescending(kvp => kvp.Value)
                .Take(topN)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}

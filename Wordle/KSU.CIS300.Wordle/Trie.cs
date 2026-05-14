using System;
using System.Collections.Generic;
using System.Text;

namespace KSU.CIS300.Wordle
{
    public class Trie
    {
        /// <summary>
        /// true if marks end of valid node
        /// </summary>
        public bool IsWord { get; set; }

        /// <summary>
        /// length of prefix at node
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// child node indexed by character
        /// </summary>
        public Dictionary<char, Trie> Children { get; private set; } = new Dictionary<char, Trie>();

        /// <summary>
        /// Adds words to the trie
        /// </summary>
        /// <param name="text">word to add</param>
        public void Add(string text)
        {
            text = text.ToUpper().Trim();
            Trie current = this;
            foreach (char c in text)
            {
                if (!current.Children.TryGetValue(c, out Trie? child))
                {
                    child = new Trie();
                    child.Length = current.Length + 1;
                    current.Children[c] = child;
                }
                current = child;
            }
            current.IsWord = true;
        }

        /// <summary>
        /// returns true if the exact word exists in the trie else false
        /// </summary>
        /// <param name="text">the word to search for</param>
        /// <returns>true or false</returns>
        public bool Contains(string text)
        {
            text = text.ToUpper().Trim();
            Trie current = this;
            foreach (char c in text)
            {
                if (!current.Children.TryGetValue(c, out Trie? child))
                    return false;
                current = child;
            }
            return current.IsWord;
        }

        /// <summary>
        /// returns all word in tire with specified length
        /// </summary>
        /// <param name="length">length to check</param>
        /// <returns>all words</returns>
        public List<string> GetWordsByLength(int length)
        {
            List<string> words = new List<string>();
            GetWordsByLengthHelper(new StringBuilder(), words, length);
            return words;
        }

        /// <summary>
        /// helper that builds a list of all words matching the target length using backtracking
        /// </summary>
        /// <param name="prefix">the current word being built along the trie path</param>
        /// <param name="words">the list to add matching words to</param>
        /// <param name="targetLength">the word length we are looking for</param>
        private void GetWordsByLengthHelper(StringBuilder prefix, List<string> words, int targetLength)
        {
            if (prefix.Length == targetLength)
            {
                if (IsWord)
                    words.Add(prefix.ToString());
                return;
            }
            foreach (var kvp in Children)
            {
                prefix.Append(kvp.Key);
                kvp.Value.GetWordsByLengthHelper(prefix, words, targetLength);
                prefix.Length--;
            }
        }

        /// <summary>
        /// returns all words of the given length that satisfy every guess/pattern constraint
        /// </summary>
        /// <param name="guesses">the list of guesses made so far</param>
        /// <param name="patterns">the pattern produced by each guess</param>
        /// <param name="wordLength">the length of words to filter</param>
        /// <returns>a list of words that match all constraints</returns>
        public List<string> GetWordsMatchingPatterns(List<string> guesses, List<string> patterns, int wordLength)
        {
            if (guesses.Count != patterns.Count)
                throw new ArgumentException("Guesses and patterns must have the same count.");

            char[] requiredAt = new char[wordLength];

            Dictionary<char, bool>[] forbiddenAt = new Dictionary<char, bool>[wordLength];
            for (int i = 0; i < wordLength; i++)
                forbiddenAt[i] = new Dictionary<char, bool>();

            Dictionary<char, int> minCounts = new Dictionary<char, int>();

            Dictionary<char, int> maxCounts = new Dictionary<char, int>();

            for (int g = 0; g < guesses.Count; g++)
            {
                string guess = guesses[g].ToUpper();
                string pattern = patterns[g].ToUpper();

                Dictionary<char, int> gyCount = new Dictionary<char, int>();
                for (int i = 0; i < guess.Length; i++)
                {
                    if (pattern[i] == 'G' || pattern[i] == 'Y')
                    {
                        char c = guess[i];
                        if (gyCount.TryGetValue(c, out int cnt))
                            gyCount[c] = cnt + 1;
                        else
                            gyCount[c] = 1;
                    }
                }

                for (int i = 0; i < guess.Length; i++)
                {
                    char c = guess[i];
                    char p = pattern[i];

                    if (p == 'G')
                    {
                        requiredAt[i] = c;
                    }
                    else
                    {
                        forbiddenAt[i][c] = true;
                    }

                    if (p == 'G' || p == 'Y')
                    {
                        int gyVal = gyCount.TryGetValue(c, out int gv) ? gv : 0;
                        if (minCounts.TryGetValue(c, out int minVal))
                            minCounts[c] = Math.Max(minVal, gyVal);
                        else
                            minCounts[c] = gyVal;
                    }
                    else 
                    {
                        int gyVal = gyCount.TryGetValue(c, out int gv) ? gv : 0;
                        if (maxCounts.TryGetValue(c, out int maxVal))
                            maxCounts[c] = Math.Min(maxVal, gyVal);
                        else
                            maxCounts[c] = gyVal;
                    }
                }
            }

            List<string> results = new List<string>();
            FilterHelper(new StringBuilder(), results, requiredAt, forbiddenAt, minCounts, maxCounts, new Dictionary<char, int>(), wordLength);
            return results;
        }

        /// <summary>
        /// recursively traverses the trie and collects words that satisfy all constraints
        /// </summary>
        /// <param name="buffer">the word being built along the current path</param>
        /// <param name="results">the list to add valid words to</param>
        /// <param name="requiredAt">chars that must appear at specific positions</param>
        /// <param name="forbiddenAt">chars that are banned at specific positions</param>
        /// <param name="minCounts">minimum number of times each char must appear</param>
        /// <param name="maxCounts">maximum number of times each char can appear</param>
        /// <param name="currentCounts">how many times each char has appeared so far on this path</param>
        /// <param name="wordLength">the target word length</param>
        private void FilterHelper(StringBuilder buffer, List<string> results, char[] requiredAt,
            Dictionary<char, bool>[] forbiddenAt, Dictionary<char, int> minCounts,
            Dictionary<char, int> maxCounts, Dictionary<char, int> currentCounts, int wordLength)
        {
            if (buffer.Length == wordLength)
            {
                if (!IsWord) return;

                foreach (var kvp in minCounts)
                {
                    currentCounts.TryGetValue(kvp.Key, out int cnt);
                    if (cnt < kvp.Value) return;
                }

                foreach (var kvp in maxCounts)
                {
                    currentCounts.TryGetValue(kvp.Key, out int cnt);
                    if (cnt != kvp.Value) return;
                }

                results.Add(buffer.ToString());
                return;
            }

            int pos = buffer.Length;

            if (requiredAt[pos] != '\0')
            {
                char required = requiredAt[pos];
                if (Children.TryGetValue(required, out Trie? child))
                {
                    buffer.Append(required);
                    IncrementCount(currentCounts, required);
                    child.FilterHelper(buffer, results, requiredAt, forbiddenAt, minCounts, maxCounts, currentCounts, wordLength);
                    DecrementCount(currentCounts, required);
                    buffer.Length--;
                }
            }
            else
            {
                foreach (var kvp in Children)
                {
                    char c = kvp.Key;
                    if (forbiddenAt[pos].ContainsKey(c)) continue;
                    if (maxCounts.TryGetValue(c, out int maxVal))
                    {
                        currentCounts.TryGetValue(c, out int currVal);
                        if (currVal >= maxVal) continue;
                    }
                    buffer.Append(c);
                    IncrementCount(currentCounts, c);
                    kvp.Value.FilterHelper(buffer, results, requiredAt, forbiddenAt, minCounts, maxCounts, currentCounts, wordLength);
                    DecrementCount(currentCounts, c);
                    buffer.Length--;
                }
            }
        }

        /// <summary>
        /// increments the count for c in the dictionary, used during trie descent
        /// </summary>
        /// <param name="counts">the dictionary tracking character counts</param>
        /// <param name="c">the character to increment</param>
        private static void IncrementCount(Dictionary<char, int> counts, char c)
        {
            if (counts.TryGetValue(c, out int val))
                counts[c] = val + 1;
            else
                counts[c] = 1;
        }

        /// <summary>
        /// decrements the count for c in the dictionary, used during backtracking
        /// </summary>
        /// <param name="counts">the dictionary tracking character counts</param>
        /// <param name="c">the character to decrement</param>
        private static void DecrementCount(Dictionary<char, int> counts, char c)
        {
            if (counts.TryGetValue(c, out int val))
                counts[c] = val - 1;
        }
    }
}
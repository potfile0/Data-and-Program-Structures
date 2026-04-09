// Author: Josh Weese
using System;
using System.Collections.Generic;
using System.Linq;

namespace KSU.CIS300.Wordle
{

    public class WordleGame
    {


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

    }
}

// Author: Josh Weese
using KSU.CIS300.Wordle;

namespace KSU.CIS300.Wordle.Tests
{
    /// <summary>
    /// Unit tests for the KSU.CIS300.Wordle namespace, organized from simple unit tests
    /// through progressively more integrated solver behavior.
    /// </summary>
    public class Tests
    {
        private Trie _trie;
        private List<string> _fiveLetterWords = new List<string>
        {
            "apple", "APPLY", "apron", "CRANE", "SlaTE", "TRACE", "CRATE",
            "LIGHT", "might", "FIGHT", "STALE", "STEAL", "tales", "sAlEt"
        };

        [SetUp]
        public void Setup()
        {
            _trie = new Trie();
            foreach (string word in _fiveLetterWords)
            {
                _trie.Add(word);
            }
        }

        #region A-TrieBasics

        /// <summary>
        /// Verifies that <see cref="Trie.Contains"/> returns <c>true</c> for a word that was
        /// added and <c>false</c> for a word that was never added.
        /// </summary>
        [Test]
        [Category("A-TrieBasics")]
        public void Trie_Contains_FindsExistingWord()
        {
            Assert.That(_trie.Contains("apple"), Is.True);
            Assert.That(_trie.Contains("banana"), Is.False);
        }

        /// <summary>
        /// Verifies that <see cref="Trie.GetWordsByLength"/> returns all words of the specified
        /// length from a trie populated only with 5-letter words.
        /// </summary>
        [Test]
        [Category("A-TrieBasics")]
        public void Trie_GetWordsByLength_ReturnsCorrectWords()
        {
            List<string> fiveLetterWords = _trie.GetWordsByLength(5);

            Assert.That(fiveLetterWords.Count, Is.EqualTo(_fiveLetterWords.Count));
            foreach(string word in _fiveLetterWords)
            {
                Assert.That(fiveLetterWords, Contains.Item(word.ToUpper()));
            }
        }

        /// <summary>
        /// Verifies that <see cref="Trie.GetWordsByLength"/> does not include words shorter than
        /// the requested length.
        /// </summary>
        [Test]
        [Category("A-TrieBasics")]
        public void Trie_GetWordsByLength_ExcludesShorterWords()
        {
            Trie mixedTrie = new Trie();
            mixedTrie.Add("to");
            mixedTrie.Add("cat");
            mixedTrie.Add("cats");
            mixedTrie.Add("crane");

            List<string> fiveLetterWords = mixedTrie.GetWordsByLength(5);
            Assert.That(fiveLetterWords.Count, Is.EqualTo(1));
            Assert.That(fiveLetterWords, Contains.Item("CRANE"));
            Assert.That(fiveLetterWords, Does.Not.Contain("CAT"));
            Assert.That(fiveLetterWords, Does.Not.Contain("CATS"));
            Assert.That(fiveLetterWords, Does.Not.Contain("TO"));
        }

        /// <summary>
        /// Verifies that <see cref="Trie.GetWordsByLength"/> does not include words longer than
        /// the requested length.
        /// </summary>
        [Test]
        [Category("A-TrieBasics")]
        public void Trie_GetWordsByLength_ExcludesLongerWords()
        {
            Trie mixedTrie = new Trie();
            mixedTrie.Add("cat");
            mixedTrie.Add("cats");
            mixedTrie.Add("crane");
            mixedTrie.Add("castle");
            mixedTrie.Add("castles");

            List<string> fiveLetterWords = mixedTrie.GetWordsByLength(5);
            Assert.That(fiveLetterWords.Count, Is.EqualTo(1));
            Assert.That(fiveLetterWords, Does.Not.Contain("CASTLE"));
            Assert.That(fiveLetterWords, Does.Not.Contain("CASTLES"));
        }

        /// <summary>
        /// Verifies that <see cref="Trie.GetWordsByLength"/> returns an empty list when no words
        /// of the given length are stored in the trie.
        /// </summary>
        [Test]
        [Category("A-TrieBasics")]
        public void Trie_GetWordsByLength_ReturnsEmptyForUnusedLength()
        {
            List<string> tenLetterWords = _trie.GetWordsByLength(10);

            Assert.That(tenLetterWords, Is.Empty);
        }

        /// <summary>
        /// Verifies that <see cref="Trie.GetWordsByLength"/> correctly retrieves words across
        /// multiple different lengths stored in the same trie.
        /// </summary>
        [Test]
        [Category("A-TrieBasics")]
        public void Trie_GetWordsByLength_DifferentLengths()
        {
            Trie mixedTrie = new Trie();
            mixedTrie.Add("cat");
            mixedTrie.Add("crane");
            mixedTrie.Add("castle");

            Assert.That(mixedTrie.GetWordsByLength(3), Contains.Item("CAT"));
            Assert.That(mixedTrie.GetWordsByLength(5), Contains.Item("CRANE"));
            Assert.That(mixedTrie.GetWordsByLength(6), Contains.Item("CASTLE"));
        }

        #endregion

        #region B-DecisionTreeBasics

        /// <summary>
        /// Verifies that <see cref="DecisionTreeNode{T}.IsLeaf"/> returns <c>true</c> for a
        /// node with no children and <c>false</c> after a child is added.
        /// </summary>
        [Test]
        [Category("B-DecisionTreeBasics")]
        public void DecisionTree_IsLeaf_ReturnsCorrectValue()
        {
            DecisionTreeNode<string> node = new DecisionTreeNode<string>("test");
            Assert.That(node.IsLeaf, Is.True);

            node.AddChild("child");
            Assert.That(node.IsLeaf, Is.False);
        }

        /// <summary>
        /// Verifies that <see cref="DecisionTreeNode{T}.GetAllValuesBreadthFirst"/> visits
        /// nodes in breadth-first (level-order) sequence across a multi-level tree.
        /// </summary>
        [Test]
        [Category("B-DecisionTreeBasics")]
        public void DecisionTree_TraverseBreadthFirst_ReturnsCorrectOrder()
        {
            DecisionTreeNode<string> root = new DecisionTreeNode<string>("root");
            DecisionTreeNode<string> child1 = root.AddChild("child1");
            DecisionTreeNode<string> child2 = root.AddChild("child2");
            child1.AddChild("grandchild1");

            List<string> values = root.GetAllValuesBreadthFirst();

            Assert.That(values[0], Is.EqualTo("root"));
            Assert.That(values[1], Is.EqualTo("child1"));
            Assert.That(values[2], Is.EqualTo("child2"));
            Assert.That(values[3], Is.EqualTo("grandchild1"));
        }

        #endregion

        #region C-PatternLogic

        /// <summary>
        /// Verifies that <see cref="WordleGame.GeneratePattern"/> returns <c>"GGGGG"</c> when the
        /// guess exactly matches the target word.
        /// </summary>
        [Test]
        [Category("C-PatternLogic")]
        public void Pattern_AllCorrect_ReturnsAllGreen()
        {
            string pattern = WordleGame.GeneratePattern("APPLE", "APPLE");
            Assert.That(pattern, Is.EqualTo("GGGGG"));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GeneratePattern"/> returns <c>"XXXXX"</c> when none
        /// of the guess letters appear in the target word.
        /// </summary>
        [Test]
        [Category("C-PatternLogic")]
        public void Pattern_AllWrong_ReturnsAllGray()
        {
            string pattern = WordleGame.GeneratePattern("APPLE", "STINK");
            Assert.That(pattern, Is.EqualTo("XXXXX"));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GeneratePattern"/> correctly produces a mixed
        /// pattern containing green, yellow, and gray codes.
        /// </summary>
        [Test]
        [Category("C-PatternLogic")]
        public void Pattern_Mixed_ReturnsCorrectPattern()
        {
            string pattern = WordleGame.GeneratePattern("CRANE", "TRACE");
            Assert.That(pattern, Is.EqualTo("YGGXG"));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GeneratePattern"/> returns all yellows when every
        /// guessed letter exists in the target but at a different position.
        /// </summary>
        [Test]
        [Category("C-PatternLogic")]
        public void Pattern_WrongPosition_ReturnsAllYellow()
        {
            string pattern = WordleGame.GeneratePattern("SLATE", "TALES");
            Assert.That(pattern, Is.EqualTo("YYYYY"));
        }

        /// <summary>
        /// Verifies the duplicate-letter handling rule: when the guess contains more copies of a
        /// letter than the target, the extra copies are marked gray (<c>'X'</c>) rather than
        /// yellow, so that no letter is over-credited.
        /// </summary>
        [Test]
        [Category("C-PatternLogic")]
        public void Pattern_DuplicateLetters_ExtraGuessCopiesAreGray()
        {
            string pattern = WordleGame.GeneratePattern("SEEDS", "STEAM");
            Assert.That(pattern, Is.EqualTo("GXGXX"));
        }

        /// <summary>
        /// Homework example: target is <c>"STEAM"</c>, guess is <c>"SEEDS"</c>.
        /// The first <c>S</c> is green (correct position), the first <c>E</c> is gray
        /// (target's only <c>E</c> at position 2 is already claimed by the green match),
        /// the second <c>E</c> is green (correct position), <c>D</c> is gray, and the
        /// second <c>S</c> is gray (target's only <c>S</c> at position 0 is already claimed).
        /// Result: <c>"GXGXX"</c>.
        /// </summary>
        [Test]
        [Category("C-PatternLogic")]
        public void Game_SteamSeeds_HwExample_ReturnsCorrectPattern()
        {
            Trie trie = new Trie();
            trie.Add("steam");
            trie.Add("seeds");

            WordleGame game = new WordleGame(trie, forcedTargetWord: "STEAM");
            bool valid = game.MakeGuess("SEEDS", out string pattern);

            Assert.That(valid, Is.True);
            Assert.That(pattern, Is.EqualTo("GXGXX"));
        }

        #endregion

        #region D-GameFlow

        /// <summary>
        /// Verifies that guessing the exact target word is accepted, produces an all-green
        /// pattern, and sets <see cref="WordleGame.IsWon"/> to <c>true</c>.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_ValidGuess_AcceptsAndWins()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");
            bool isValid = game.MakeGuess("APPLE", out string pattern);

            Assert.That(isValid, Is.True);
            Assert.That(pattern, Is.EqualTo("GGGGG"));
            Assert.That(game.IsWon, Is.True);
        }

        /// <summary>
        /// Verifies that a guess not present in the trie is rejected and
        /// <see cref="WordleGame.MakeGuess"/> returns <c>false</c> without consuming an attempt.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_InvalidGuess_RejectsWord()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");
            bool isValid = game.MakeGuess("ZZZZZ", out string pattern);

            Assert.That(isValid, Is.False);
            Assert.That(game.CurrentAttempt, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that a full game flow can win in two guesses and that the game state is
        /// updated correctly after each guess.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_FullGameFlow_WinsInTwoGuesses()
        {
            WordleGame game = new WordleGame(_trie, maxAttempts: 6, forcedTargetWord: "APPLE");

            Assert.That(game.IsGameOver, Is.False);
            Assert.That(game.CurrentAttempt, Is.EqualTo(0));

            bool valid1 = game.MakeGuess("CRANE", out string pattern1);
            Assert.That(valid1, Is.True);
            Assert.That(game.CurrentAttempt, Is.EqualTo(1));

            bool valid2 = game.MakeGuess("APPLE", out string pattern2);
            Assert.That(valid2, Is.True);
            Assert.That(pattern2, Is.EqualTo("GGGGG"));
            Assert.That(game.IsWon, Is.True);
            Assert.That(game.IsGameOver, Is.True);
        }

        /// <summary>
        /// Verifies that the game ends as a loss once the maximum number of attempts is reached
        /// without guessing the target word.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_MaxAttempts_EndsGameAsLoss()
        {
            WordleGame game = new WordleGame(_trie, maxAttempts: 3, forcedTargetWord: "APPLE");

            _ = game.MakeGuess("CRANE", out string firstAttemptPattern);
            _ = game.MakeGuess("SLATE", out string secondAttemptPattern);
            _ = game.MakeGuess("TRACE", out string thirdAttemptPattern);

            Assert.That(game.IsGameOver, Is.True);
            Assert.That(game.IsWon, Is.False);
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GetRemainingPossibilities"/> correctly narrows
        /// the candidate list based on the accumulated guess/pattern history.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_GetRemainingPossibilities_FiltersCorrectly()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "TRACE");
            _ = game.MakeGuess("CRANE", out _);

            List<string> remaining = game.GetRemainingPossibilities();

            Assert.That(remaining, Contains.Item("TRACE"));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GetBestGuess"/> returns a non-empty,
        /// correctly-sized opening guess before any attempts have been made.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_GetBestGuess_ReturnsFirstGuessWhenNoAttempts()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");
            string bestGuess = game.GetBestGuess();

            Assert.That(bestGuess, Is.Not.Empty);
            Assert.That(bestGuess.Length, Is.EqualTo(5));
            Assert.That(game.CurrentAttempt, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GetBestGuess"/> returns a non-empty,
        /// correctly-sized suggestion after the first guess has been recorded.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_GetBestGuess_ReturnsOptimalGuessAfterFirstAttempt()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");
            _ = game.MakeGuess("CRANE", out _);

            string bestGuess = game.GetBestGuess();

            Assert.That(bestGuess, Is.Not.Empty);
            Assert.That(bestGuess.Length, Is.EqualTo(5));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.GetBestGuess"/> returns <see cref="string.Empty"/>
        /// when no words remain consistent with the guess history.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_GetBestGuess_ReturnsEmptyWhenNoPossibilities()
        {
            Trie smallTrie = new Trie();
            smallTrie.Add("crane");

            WordleGame game = new WordleGame(smallTrie, forcedTargetWord: "APPLE");
            _ = game.MakeGuess("CRANE", out _);

            string bestGuess = game.GetBestGuess();

            Assert.That(bestGuess, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.Reset"/> clears all guesses, patterns, and state
        /// flags, then selects a new non-empty target word.
        /// </summary>
        [Test]
        [Category("D-GameFlow")]
        public void Game_Reset_ClearsGameStateAndSelectsNewWord()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");
            _ = game.MakeGuess("CRANE", out _);
            _ = game.MakeGuess("SLATE", out _);

            game.Reset();

            Assert.That(game.CurrentAttempt, Is.EqualTo(0));
            Assert.That(game.Guesses, Is.Empty);
            Assert.That(game.Patterns, Is.Empty);
            Assert.That(game.IsGameOver, Is.False);
            Assert.That(game.IsWon, Is.False);
            Assert.That(game.TargetWord, Is.Not.Empty);
        }

        #endregion

        #region E-Entropy

        /// <summary>
        /// Verifies that <see cref="WordleGame.CalculateEntropy"/> returns a non-negative value
        /// for a valid guess and a non-empty candidate list.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_Calculate_ReturnsNonNegative()
        {
            List<string> words = new List<string> { "CRANE", "TRACE", "CRATE" };
            double entropy = WordleGame.CalculateEntropy("SLATE", words);

            Assert.That(entropy, Is.GreaterThanOrEqualTo(0));
        }

        /// <summary>
        /// Verifies that entropy is zero when there are no candidate words.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_EmptyWordList_ReturnsZero()
        {
            List<string> words = new List<string>();
            double entropy = WordleGame.CalculateEntropy("CRANE", words);

            Assert.That(entropy, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that entropy is zero when only one possible target word remains.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_SingleWord_ReturnsZero()
        {
            List<string> words = new List<string> { "APPLE" };
            double entropy = WordleGame.CalculateEntropy("CRANE", words);

            Assert.That(entropy, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that entropy is 1.0 for two candidate words that split perfectly into two
        /// equally likely pattern outcomes.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_TwoWords_ReturnsOneForPerfectSplit()
        {
            List<string> words = new List<string> { "APPLE", "APPLY" };
            double entropy = WordleGame.CalculateEntropy("APPLE", words);

            Assert.That(entropy, Is.EqualTo(1.0).Within(0.0001));
        }

        /// <summary>
        /// Verifies that entropy is positive and does not exceed the maximum possible value for
        /// four candidate words.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_FourWords_LessThanMaximum()
        {
            List<string> words = new List<string> { "CRANE", "TRACE", "SLATE", "CRATE" };
            double entropy = WordleGame.CalculateEntropy("SLATE", words);

            Assert.That(entropy, Is.LessThanOrEqualTo(2.0));
            Assert.That(entropy, Is.GreaterThan(0));
        }

        /// <summary>
        /// Verifies that different guesses over the same candidate set can both produce positive
        /// entropy values.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_DifferentGuesses_ProducesPositiveValues()
        {
            List<string> words = new List<string> { "APPLE", "APPLY", "APRON" };

            double entropyInList = WordleGame.CalculateEntropy("APPLE", words);
            double entropyNotInList = WordleGame.CalculateEntropy("SLATE", words);

            Assert.That(entropyInList, Is.GreaterThan(0));
            Assert.That(entropyNotInList, Is.GreaterThan(0));
        }

        /// <summary>
        /// Verifies that entropy is zero when every candidate word yields the same pattern.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_AllSamePattern_ReturnsZero()
        {
            List<string> words = new List<string> { "BBBBB", "BBBBB" };
            double entropy = WordleGame.CalculateEntropy("CRANE", words);

            Assert.That(entropy, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that adding more candidate words can increase or preserve entropy when more
        /// distinct feedback patterns are possible.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_MoreWords_IncreasesWithMoreDistinctPatterns()
        {
            List<string> twoWords = new List<string> { "APPLE", "APPLY" };
            List<string> fourWords = new List<string> { "APPLE", "APPLY", "CRANE", "SLATE" };

            double entropyTwo = WordleGame.CalculateEntropy("TRACE", twoWords);
            double entropyFour = WordleGame.CalculateEntropy("TRACE", fourWords);

            Assert.That(entropyFour, Is.GreaterThanOrEqualTo(entropyTwo));
        }

        /// <summary>
        /// Verifies that entropy never exceeds log2(n), where n is the number of candidate words.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_BoundedByLog2_NeverExceedsMaximum()
        {
            List<string> words = new List<string> { "APPLE", "APPLY", "CRANE", "SLATE", "TRACE", "CRATE", "STALE", "STEAL" };

            double entropy = WordleGame.CalculateEntropy("TALES", words);
            double maxPossibleEntropy = Math.Log2(words.Count);

            Assert.That(entropy, Is.LessThanOrEqualTo(maxPossibleEntropy));
            Assert.That(entropy, Is.GreaterThanOrEqualTo(0));
        }

        /// <summary>
        /// Verifies that entropy values used for guess ranking are always non-negative and that
        /// at least one tested guess provides information.
        /// </summary>
        [Test]
        [Category("E-Entropy")]
        public void Entropy_OptimalGuessSelection_ProducesNonNegativeValues()
        {
            List<string> words = new List<string> { "APPLE", "APPLY", "APRON" };

            double entropyA = WordleGame.CalculateEntropy("SLATE", words);
            double entropyB = WordleGame.CalculateEntropy("ZZZZZ", words);
            double entropyC = WordleGame.CalculateEntropy("APPLE", words);

            Assert.That(entropyA, Is.GreaterThanOrEqualTo(0));
            Assert.That(entropyB, Is.GreaterThanOrEqualTo(0));
            Assert.That(entropyC, Is.GreaterThanOrEqualTo(0));
            Assert.That(entropyA + entropyB + entropyC, Is.GreaterThan(0));
        }

        #endregion

        #region F-Solver

        /// <summary>
        /// Verifies that <see cref="WordleGame.BuildDecisionTree"/> produces a non-null tree
        /// whose root has a non-empty guess value.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_BuildDecisionTree_CreatesNonEmptyTree()
        {
            List<string> words = new List<string> { "CRANE", "TRACE", "CRATE" };
            DecisionTreeNode<string> tree = WordleGame.BuildDecisionTree(words, words, 2);

            Assert.That(tree, Is.Not.Null);
            Assert.That(tree.Value, Is.Not.Empty);
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.FindBestGuess"/> returns a non-empty word
        /// of the correct length for a non-empty candidate set.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_FindBestGuess_ReturnsValidWord()
        {
            List<string> words = _trie.GetWordsByLength(5);
            string firstGuess = WordleGame.FindBestGuess(words, words);

            Assert.That(firstGuess, Is.Not.Empty);
            Assert.That(firstGuess.Length, Is.EqualTo(5));
        }

        /// <summary>
        /// Verifies that the solver can find the solution within the allowed six attempts
        /// when given a small word list containing the target word.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_SmallWordList_FindsSolutionInSixAttempts()
        {
            List<string> words = _trie.GetWordsByLength(5);
            string firstGuess = WordleGame.FindBestGuess(words, words);
            Assert.That(firstGuess, Is.Not.Empty);

            int attempts = SolverTestHelper.SolveWord(_trie, "APPLE", 5, out List<string> guesses);
            Assert.That(attempts, Is.GreaterThan(0));
            Assert.That(attempts, Is.LessThanOrEqualTo(6));
            Assert.That(guesses[guesses.Count - 1], Is.EqualTo("APPLE"));
        }

        /// <summary>
        /// Verifies that <see cref="SolverTestHelper.SolveWord"/> finds the target word, returns a
        /// positive attempt count, and records exactly that many guesses with the target as the
        /// final guess.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_SolveWord_FindsSolution()
        {
            int attempts = SolverTestHelper.SolveWord(_trie, "APPLE", 5, out List<string> guesses);

            Assert.That(attempts, Is.GreaterThan(0));
            Assert.That(guesses.Count, Is.EqualTo(attempts));
            Assert.That(guesses[guesses.Count - 1], Is.EqualTo("APPLE"));
        }

        /// <summary>
        /// Verifies that the solver efficiently narrows down possibilities and finds the solution
        /// within the allowed attempts, even when the initial guess is suboptimal.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_OptimalPlay_FindsSolutionInFewAttempts()
        {
            List<string> wordList = new List<string> { "APPLE", "RANGE", "SLATE", "CRANE", "TRACE" };
            Trie testTrie = new Trie();
            foreach (string word in wordList)
            {
                testTrie.Add(word);
            }

            List<string> guesses = new List<string> { "APPLE" };
            List<string> patterns = new List<string> { WordleGame.GeneratePattern("APPLE", "TRACE") };

            while (guesses[guesses.Count - 1] != "TRACE" && guesses.Count < 6)
            {
                string nextGuess = SolverTestHelper.GetNextGuess(testTrie, 5, guesses, patterns);
                Assert.That(nextGuess, Is.Not.Empty);

                guesses.Add(nextGuess);
                patterns.Add(WordleGame.GeneratePattern(nextGuess, "TRACE"));
            }

            Assert.That(guesses.Count, Is.LessThanOrEqualTo(6));
            Assert.That(guesses[guesses.Count - 1], Is.EqualTo("TRACE"));
        }

        /// <summary>
        /// Verifies that <see cref="SolverTestHelper.GetNextGuess"/> does not suggest any letter
        /// that has been globally eliminated by a prior all-gray pattern.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_GetNextGuess_ExcludesKnownWrongLetters()
        {
            List<string> guesses = new List<string> { "CRANE" };
            List<string> patterns = new List<string> { "XXXXX" };

            string nextGuess = SolverTestHelper.GetNextGuess(_trie, 5, guesses, patterns);

            Assert.That(nextGuess, Is.Not.Empty);
            Assert.That(nextGuess.Contains('C'), Is.False);
            Assert.That(nextGuess.Contains('R'), Is.False);
            Assert.That(nextGuess.Contains('A'), Is.False);
            Assert.That(nextGuess.Contains('N'), Is.False);
            Assert.That(nextGuess.Contains('E'), Is.False);
        }

        /// <summary>
        /// Verifies that <see cref="SolverTestHelper.GetGuessesWithEntropy"/> returns a
        /// non-empty dictionary and that every entropy value is non-negative.
        /// </summary>
        [Test]
        [Category("F-Solver")]
        public void Solver_GetGuessesWithEntropy_ReturnsPositiveValues()
        {
            List<string> remaining = new List<string> { "APPLE", "APPLY" };

            Dictionary<string, double> entropyMap = SolverTestHelper.GetGuessesWithEntropy(_trie, 5, remaining, 5);

            Assert.That(entropyMap.Count, Is.GreaterThan(0));
            Assert.That(entropyMap.Values.All(v => v >= 0), Is.True);
        }

        #endregion

        #region G-ErrorHandling

        /// <summary>
        /// Verifies that <see cref="WordleGame.GeneratePattern"/> throws
        /// <see cref="ArgumentException"/> when the guess and target have different lengths.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Pattern_GeneratePattern_ThrowsOnLengthMismatch()
        {
            Assert.Throws<ArgumentException>(() =>
                WordleGame.GeneratePattern("APPLE", "CAT"));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.MakeGuess"/> returns <c>false</c> and an empty
        /// pattern string when the game has already ended.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Game_MakeGuess_ReturnsFalseAfterGameOver()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");
            _ = game.MakeGuess("APPLE", out _);

            bool result = game.MakeGuess("CRANE", out string pattern);

            Assert.That(result, Is.False);
            Assert.That(pattern, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.MakeGuess"/> returns <c>false</c> and does not
        /// increment <see cref="WordleGame.CurrentAttempt"/> when the guess has the wrong length.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Game_MakeGuess_ReturnsFalseForWrongLength()
        {
            WordleGame game = new WordleGame(_trie, forcedTargetWord: "APPLE");

            bool result = game.MakeGuess("CAT", out string pattern);

            Assert.That(result, Is.False);
            Assert.That(game.CurrentAttempt, Is.EqualTo(0));
        }

        /// <summary>
        /// Verifies that constructing a <see cref="WordleGame"/> with an empty trie results in
        /// an <see cref="ArgumentException"/>.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Game_EmptyWordList_SetsEmptyTargetWord()
        {
            Trie emptyTrie = new Trie();
            Assert.Throws<ArgumentException>(() =>
                new WordleGame(emptyTrie, 5));
        }

        /// <summary>
        /// Verifies that <see cref="SolverTestHelper.GetNextGuess"/> throws
        /// <see cref="ArgumentException"/> when the number of guesses and patterns do not match.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Solver_GetNextGuess_ThrowsOnMismatchedCounts()
        {
            List<string> guesses = new List<string> { "CRANE", "SLATE" };
            List<string> patterns = new List<string> { "XXXXX" };

            Assert.Throws<ArgumentException>(() =>
                SolverTestHelper.GetNextGuess(_trie, 5, guesses, patterns));
        }

        /// <summary>
        /// Verifies that <see cref="SolverTestHelper.SolveWord"/> returns <c>-1</c> when the target
        /// word's length does not match the solver's configured word length.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Solver_SolveWord_ReturnsNegativeOneForWrongLength()
        {
            int result = SolverTestHelper.SolveWord(_trie, "CAT", 5, out List<string> guesses);

            Assert.That(result, Is.EqualTo(-1));
        }

        /// <summary>
        /// Verifies that <see cref="WordleGame.FindBestGuess"/> returns
        /// <see cref="string.Empty"/> when the candidate list is empty.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void Solver_FindBestGuess_EmptyWordList_ReturnsEmpty()
        {
            List<string> empty = new List<string>();

            string firstGuess = WordleGame.FindBestGuess(empty, empty);

            Assert.That(firstGuess, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Verifies that <see cref="Trie.GetWordsMatchingPatterns"/> throws
        /// <see cref="ArgumentException"/> when the number of guesses and patterns do not match.
        /// </summary>
        [Test]
        [Category("G-ErrorHandling")]
        public void GetWordsMatchingPatterns_MismatchedGuessesAndPatterns_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                _trie.GetWordsMatchingPatterns(
                    new List<string> { "CRANE", "SLATE" },
                    new List<string> { "XXXXX" },
                    5));
        }

        #endregion
    }
}
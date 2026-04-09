// Author: Josh Weese
using KSU.CIS300.Wordle;

namespace KSU.CIS300.Wordle
{
    /// <summary>
    /// Code-behind for the Wordle game window. Manages user interaction,
    /// displays colored guess tiles, and delegates game logic to <see cref="WordleGame"/>.
    /// </summary>
    public partial class WordleGUI : Form
    {
        /// <summary>
        /// The trie containing all words loaded from the word-list file.
        /// </summary>
        private Trie? _wordTrie;

        /// <summary>
        /// The current game instance, or null if no game has been started.
        /// </summary>
        private WordleGame? _game;

        /// <summary>
        /// The required word length for the current game (default 5).
        /// </summary>
        private int _wordLength = 5;

        /// <summary>
        /// The maximum number of guesses allowed per game.
        /// </summary>
        private const int MaxAttempts = 6;

        /// <summary>
        /// Initializes the form, fixes the guess panel's auto-size settings,
        /// creates an empty word list, and refreshes the UI.
        /// </summary>
        public WordleGUI()
        {
            InitializeComponent();

            uxGuesses_Panel.AutoSize = false;
            uxGuesses_Panel.AutoScroll = true;

            InitializeWordList();
            UpdateUI();
        }

        /// <summary>
        /// Creates a new empty <see cref="Trie"/> for the word list.
        /// </summary>
        private void InitializeWordList()
        {
            _wordTrie = new Trie();
        }

        /// <summary>
        /// Reads every line from the specified file, adds non-empty words to the trie,
        /// and shows a message box reporting the number of words loaded.
        /// </summary>
        /// <param name="filePath">The full path to the word-list file.</param>
        private void LoadWordsFromFile(string filePath)
        {
            try
            {
                string[] words = File.ReadAllLines(filePath);
                int count = 0;
                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        _wordTrie!.Add(word.Trim().ToLower());
                        count++;
                    }
                }
                MessageBox.Show("Successfully loaded " + count + " words!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uxStatus_Label.Text = "Click 'New Game' to start playing!";
                uxNewGame_ToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading word list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates a new <see cref="WordleGame"/>, clears the guess panel and text box,
        /// and refreshes the UI.
        /// </summary>
        /// <param name="wordLength">The required word length for the new game.</param>
        private void StartNewGame(int wordLength = 5)
        {
            _wordLength = wordLength;
            _game = new WordleGame(_wordTrie!, wordLength, MaxAttempts);
            uxGuesses_Panel.Controls.Clear();
            uxGuess_TextBox.Text = string.Empty;
            uxGuess_TextBox.MaxLength = wordLength;
            uxGuess_TextBox.Focus();
            UpdateUI();
        }

        /// <summary>
        /// Submits a guess to the current game. Shows an error on an invalid guess.
        /// On success, displays the colored tiles, clears the text box, and updates the UI.
        /// Shows a win or loss dialog when the game ends.
        /// </summary>
        /// <param name="guess">The word to guess.</param>
        private void MakeGuess(string guess)
        {
            if (_game == null)
                return;

            guess = guess.ToUpper();

            bool isValid = _game.MakeGuess(guess, out string pattern);

            if (!isValid)
            {
                MessageBox.Show("Invalid guess. Please enter a valid word from the dictionary.", "Invalid Guess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DisplayGuess(guess, pattern);
            uxGuess_TextBox.Text = string.Empty;
            uxGuess_TextBox.Focus();
            UpdateUI();

            if (_game.IsGameOver)
            {
                if (_game.IsWon)
                {
                    MessageBox.Show("Congratulations! You won in " + _game.CurrentAttempt + " attempts!", "You Won!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Game Over! The word was: " + _game.TargetWord, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Creates a row of colored letter tiles for the given guess and pattern and
        /// adds it to the guess panel. Tile and row dimensions are computed dynamically
        /// so that all <see cref="MaxAttempts"/> rows fit within the panel without overflow.
        /// Colors: Green (106, 170, 100), Yellow (201, 180, 88), Gray (120, 124, 126).
        /// </summary>
        /// <param name="guess">The guessed word (uppercase).</param>
        /// <param name="pattern">The pattern string (e.g., "GYGXX") for tile coloring.</param>
        private void DisplayGuess(string guess, string pattern)
        {
            const int padding = 10;
            const int gap = 5;

            int availableHeight = uxGuesses_Panel.ClientSize.Height - 2 * padding - (MaxAttempts - 1) * gap;
            int rowHeight = Math.Max(14, availableHeight / MaxAttempts - 5);

            int rowWidth = uxGuesses_Panel.ClientSize.Width - 2 * padding;
            int reservedForLabel = 95;
            int availableWidth = rowWidth - reservedForLabel;
            int maxTileByWidth = Math.Max(9, availableWidth / _wordLength - 3);
            int tileSize = Math.Min(rowHeight - 3, maxTileByWidth);

            int tileSpacing = tileSize + 1;
            float fontSize = Math.Max(6f, tileSize * 0.28f);

            Panel guessRow = new Panel
            {
                Height = rowHeight,
                Width = rowWidth,
                Location = new Point(padding, uxGuesses_Panel.Controls.Count * (rowHeight + gap) + padding)
            };

            for (int i = 0; i < guess.Length; i++)
            {
                Label letterBox = new Label
                {
                    Text = guess[i].ToString(),
                    Font = new Font("Consolas", fontSize, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(tileSize, tileSize),
                    Location = new Point(i * tileSpacing, 0),
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoSize = false,
                    BackColor = pattern[i] switch
                    {
                        'G' => Color.FromArgb(106, 170, 100),
                        'Y' => Color.FromArgb(201, 180, 88),
                        'X' => Color.FromArgb(120, 124, 126),
                        _ => Color.White
                    },
                    ForeColor = Color.White
                };

                guessRow.Controls.Add(letterBox);
            }

            int labelX = guess.Length * tileSpacing + 8;
            int labelWidth = Math.Max(30, rowWidth - labelX);

            Label attemptLabel = new Label
            {
                Text = "#" + _game!.CurrentAttempt,
                Font = new Font("Segoe UI", Math.Max(6.5f, fontSize * 0.75f), FontStyle.Bold),
                Size = new Size(labelWidth, rowHeight),
                Location = new Point(labelX, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = false
            };
            guessRow.Controls.Add(attemptLabel);

            uxGuesses_Panel.Controls.Add(guessRow);
        }

        /// <summary>
        /// Returns the AI's recommended next guess for the current game,
        /// or <see cref="string.Empty"/> if no game is active.
        /// </summary>
        /// <returns>The optimal guess string.</returns>
        private string GetAISuggestion()
        {
            if (_game == null)
                return string.Empty;

            return _game.GetBestGuess();
        }

        /// <summary>
        /// Returns all words that remain consistent with every guess and pattern so far,
        /// or an empty list if no game is active.
        /// </summary>
        /// <returns>The list of remaining candidate words.</returns>
        private List<string> GetRemainingWords()
        {
            if (_game == null)
                return new List<string>();

            return _game.GetRemainingPossibilities();
        }

        /// <summary>
        /// Enables or disables controls and updates status labels based on the
        /// current game state (no game, in progress, won, or lost).
        /// </summary>
        private void UpdateUI()
        {
            if (_game == null)
            {
                uxStatus_Label.Text = "No game in progress";
                uxRemaining_Label.Text = "Remaining possibilities: 0";
                uxGuess_TextBox.Enabled = false;
                uxSubmit_Button.Enabled = false;
                uxHint_Button.Enabled = false;
                return;
            }

            List<string> remaining = GetRemainingWords();
            uxRemaining_Label.Text = "Remaining possibilities: " + remaining.Count;

            if (_game.IsGameOver)
            {
                if (_game.IsWon)
                {
                    uxStatus_Label.Text = "🎉 You Won in " + _game.CurrentAttempt + " attempts! 🎉";
                    uxStatus_Label.ForeColor = Color.Green;
                }
                else
                {
                    uxStatus_Label.Text = "Game Over - Word was: " + _game.TargetWord;
                    uxStatus_Label.ForeColor = Color.Red;
                }
                uxGuess_TextBox.Enabled = false;
                uxSubmit_Button.Enabled = false;
                uxHint_Button.Enabled = false;
            }
            else
            {
                uxStatus_Label.Text = "Attempt " + (_game.CurrentAttempt + 1) + "/" + MaxAttempts + " - Enter your guess";
                uxStatus_Label.ForeColor = Color.Black;
                uxGuess_TextBox.Enabled = true;
                uxSubmit_Button.Enabled = true;
                uxHint_Button.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Load Words menu item click. Opens a file dialog and loads
        /// the selected word-list file into the trie.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void LoadWordsMenuItem_Click(object sender, EventArgs e)
        {
            if (uxWordList_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadWordsFromFile(uxWordList_OpenFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handles the New Game menu item click. Resets an existing game or
        /// starts a fresh one if no game exists. Warns the user if no words
        /// have been loaded yet.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void NewGameMenuItem_Click(object sender, EventArgs e)
        {
            if (_wordTrie!.GetWordsByLength(_wordLength).Count == 0)
            {
                MessageBox.Show("Please load a word list first!", "No Words", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_game != null)
            {
                _game.Reset();
            }
            else
            {
                StartNewGame(_wordLength);
                return;
            }

            uxGuesses_Panel.Controls.Clear();
            uxGuess_TextBox.Text = string.Empty;
            UpdateUI();
            uxGuess_TextBox.Focus();
        }

        /// <summary>
        /// Handles the Exit menu item click. Closes the application.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Submit button click. Validates that the input is non-empty
        /// and the correct length, then submits the guess.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(uxGuess_TextBox.Text))
            {
                MessageBox.Show("Please enter a guess!", "Empty Guess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (uxGuess_TextBox.Text.Length != _wordLength)
            {
                MessageBox.Show("Guess must be " + _wordLength + " letters!", "Invalid Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MakeGuess(uxGuess_TextBox.Text);
            uxGuess_TextBox.Focus();
        }

        /// <summary>
        /// Handles the Hint button click. Displays the AI's optimal guess suggestion
        /// and the number of remaining possibilities in a message box.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void HintButton_Click(object sender, EventArgs e)
        {
            string hint = GetAISuggestion();
            if (!string.IsNullOrEmpty(hint))
            {
                List<string> remaining = GetRemainingWords();
                MessageBox.Show(
                    "AI Suggestion: " + hint.ToUpper() + "\n\n" +
                    "This is the optimal guess based on entropy.\n" +
                    "Remaining possibilities: " + remaining.Count,
                    "AI Hint",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No suggestions available!", "No Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            uxGuess_TextBox.Focus();
        }

        /// <summary>
        /// Handles key presses in the guess text box. Routes the Enter key to
        /// <see cref="SubmitButton_Click"/> and blocks non-letter characters.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">The key-press event data.</param>
        private void GuessTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SubmitButton_Click(sender, e);
            }
            else if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

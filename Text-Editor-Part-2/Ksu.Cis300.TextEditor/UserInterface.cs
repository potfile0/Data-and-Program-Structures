/* UserInterface.cs
 * Author: Josh Weese
 */
using System.Text;

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A GUI for a simple text editor.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Open . . ." menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void OpenClick(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxEditBuffer.Text = File.ReadAllText(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Save As . . ." menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void SaveAsClick(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveDialog.FileName, uxEditBuffer.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Displays the given exception to the user.
        /// </summary>
        /// <param name="e">The exception to show.</param>
        private static void ShowError(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e);
        }

        /// <summary>
        /// The number of characters to rotate when encrypting.
        /// </summary>
        private const int _rotationDistance = 13;

        /// <summary>
        /// The number of characters in the alphabet.
        /// </summary>
        private const int _alphabetLength = 26;

        /// <summary>
        /// The first letter of the lower-case alphabet.
        /// </summary>
        private const char _lowerCaseStart = 'a';

        /// <summary>
        /// The first letter of the upper-case alphabet.
        /// </summary>
        private const char _upperCaseStart = 'A';

        /// <summary>
        /// Rotates the given character c through the alphabet whose first
        /// letter is firstLetter.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private static char Rotate(char c, char firstLetter)
        {
            return (char)(firstLetter + (c - firstLetter + _rotationDistance) % _alphabetLength);
        }

        /// <summary>
        /// Checks wether a given character is in a specified 26 letter alphabet
        /// </summary>
        /// <param name="c">gives the character to check</param>
        /// <param name="firstLetter">gives the first letter of the alphabet</param>
        /// <returns></returns>
        private static bool Checker(char c, char firstLetter)
        {
            char lastLetter = (char)(firstLetter + _alphabetLength - 1);
            return c >= firstLetter && c <= lastLetter;
        }

        /// <summary>
        /// encrypts a single character
        /// </summary>
        /// <param name="c">gives the character to encrypt</param>
        /// <returns></returns>
        private static char Encrypt(char c)
        {
            if (Checker(c, _lowerCaseStart))
            {
                return Rotate(c, _lowerCaseStart);
            }
            else if (Checker(c, _upperCaseStart))
            {
                return Rotate(c, _upperCaseStart);
            }
            else
            {
                return c;
            }
        }

        /// <summary>
        /// Handles a click event on the "With String" menu item
        /// </summary>
        /// <param name="sender"> The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void WithStringClick(object sender, EventArgs e)
        {
            string text = uxEditBuffer.Text;

            string result = "";

            foreach (char c in text)
            {
                result += Encrypt(c);
            }

            uxEditBuffer.Text = result;
        }

        /// <summary>
        /// Handles a click event on the "With StringBuilder" menu item
        /// </summary>
        /// <param name="sender"> The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void WithStringBuilderClick(object sender, EventArgs e)
        {
            string text = uxEditBuffer.Text;

            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                result.Append(Encrypt(c));
            }

            uxEditBuffer.Text = result.ToString();
        }

    }
}

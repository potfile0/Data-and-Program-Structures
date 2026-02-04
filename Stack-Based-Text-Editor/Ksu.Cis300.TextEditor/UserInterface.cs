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
        /// The history of edits.
        /// </summary>
        private StackLibrary.Stack<object> _editHistory = new();

        /// <summary>
        /// The history of undone edits.
        /// </summary>
        private StackLibrary.Stack<object> _undoHistory = new();

        /// <summary>
        /// The last text seen in the editor.
        /// </summary>
        private string _lastText = "";

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
                    _lastText = uxEditBuffer.Text;
                    _editHistory.Clear();
                    _undoHistory.Clear();
                    uxUndo.Enabled = false;
                    uxRedo.Enabled = false;
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
        /// Rotates the given character c n positions through the alphabet whose first
        /// letter is firstLetter and whose number of letters is alphabetLen. alphabetLen
        /// must be positive.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private static char Rotate(char c, char firstLetter)
        {
            return (char)(firstLetter + (c - firstLetter + _rotationDistance) % _alphabetLength);
        }

        /// <summary>
        /// Determines whether the given character is in the alphabet that starts with the given
        /// start character.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <param name="start">The start of the alphabet.</param>
        /// <returns>Whether c is in the alphabet that starts at the character start.</returns>
        private static bool IsInAlphabet(char c, char start)
        {
            return c >= start && c < start + _alphabetLength;
        }

        /// <summary>
        /// Encrypts the given character.
        /// </summary>
        /// <param name="c">The character to encrypt.</param>
        /// <returns>The encrypted character.</returns>
        private static char Encrypt(char c)
        {
            if (IsInAlphabet(c, _lowerCaseStart))
            {
                return Rotate(c, _lowerCaseStart);
            }
            else if (IsInAlphabet(c, _upperCaseStart))
            {
                return Rotate(c, _upperCaseStart);
            }
            else
            {
                return c;
            }
        }

        /// <summary>
        /// Handles a Click event on the "With String" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void EncryptWithStringClick(object sender, EventArgs e)
        {
            string text = uxEditBuffer.Text;
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += Encrypt(text[i]);
            }
            uxEditBuffer.Text = result;
        }

        /// <summary>
        /// Handles a Click event on the "With StringBuilder" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void EncryptWithStringBuilderClick(object sender, EventArgs e)
        {
            string text = uxEditBuffer.Text;
            StringBuilder result = new();
            for (int i = 0; i < text.Length; i++)
            {
                result.Append(Encrypt(text[i]));
            }
            uxEditBuffer.Text = result.ToString();
        }

        /// <summary>
        /// Records an edit made by the user.
        /// </summary>
        private void RecordEdit()
        {
            bool isDel = IsDeletion(uxEditBuffer, _lastText); // Indicates whether the edit was a deletion
            int len = GetEditLength(uxEditBuffer, _lastText); // The length of the string inserted or deleted
            int loc = GetEditLocation(uxEditBuffer, isDel, len); // The location of the edit
            string text = uxEditBuffer.Text; // The current editor content
            string editStr = GetEditString(text, _lastText, isDel, loc, len); // The string deleted or inserted
            _lastText = text;
            _editHistory.Push(isDel);
            _editHistory.Push(loc);
            _editHistory.Push(editStr);
            _undoHistory.Clear();
            uxUndo.Enabled = true;
            uxRedo.Enabled = false;
        }

        /// <summary>
        /// Returns whether text was deleted from the given string in order to obtain the contents
        /// of the given TextBox.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <returns>Whether the edit was a deletion.</returns>
        private static bool IsDeletion(TextBox editor, string lastContent)
        {
            return editor.TextLength < lastContent.Length;
        }

        /// <summary>
        /// Gets the length of the text inserted or deleted.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <returns>The length of the edit.</returns>
        private static int GetEditLength(TextBox editor, string lastContent)
        {
            return Math.Abs(editor.TextLength - lastContent.Length);
        }

        /// <summary>
        /// Gets the location of the beginning of the edit.
        /// </summary>
        /// <param name="editor">The TextBox containing the result of the edit.</param>
        /// <param name="isDeletion">Indicates whether the edit was a deletion.</param>
        /// <param name="len">The length of the edit string.</param>
        /// <returns>The location of the beginning of the edit.</returns>
        private static int GetEditLocation(TextBox editor, bool isDeletion, int len)
        {
            if (isDeletion)
            {
                return editor.SelectionStart;
            }
            else
            {
                return editor.SelectionStart - len;
            }
        }

        /// <summary>
        /// Gets the edit string.
        /// </summary>
        /// <param name="content">The current content of the TextBox.</param>
        /// <param name="lastContent">The string representing the text prior to the edit.</param>
        /// <param name="isDeletion">Indicates whether the edit was a deletion.</param>
        /// <param name="editLocation">The location of the beginning of the edit.</param>
        /// <param name="len">The length of the edit.</param>
        /// <returns>The edit string.</returns>
        private static string GetEditString(string content, string lastContent, bool isDeletion, int editLocation, int len)
        {
            if (isDeletion)
            {
                return lastContent.Substring(editLocation, len);
            }
            else
            {
                return content.Substring(editLocation, len);
            }
        }

        /// <summary>
        /// Performs the given edit on the contents of the given TextBox.
        /// </summary>
        /// <param name="editor">The TextBox to edit.</param>
        /// <param name="isDeletion">Indicates whether the edit is a deletion.</param>
        /// <param name="loc">The location of the beginning of the edit.</param>
        /// <param name="text">The text to insert or delete.</param>
        private void DoEdit(TextBox editor, bool isDeletion, int loc, string text)
        {
            if (isDeletion)
            {
                _lastText = editor.Text.Remove(loc, text.Length);
                editor.Text = _lastText;
                editor.SelectionStart = loc;
            }
            else
            {
                _lastText = editor.Text.Insert(loc, text);
                editor.Text = _lastText;
                editor.SelectionStart = loc + text.Length;
            }
        }

        /// <summary>
        /// Handles a TextChanged event on the edit buffer.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void EditBufferTextChanged(object sender, EventArgs e)
        {
            if (uxEditBuffer.Modified)
            {
                RecordEdit();
            }
        }

        /// <summary>
        /// Handles a Click event on the Undo menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void UndoClick(object sender, EventArgs e)
        {
            // Because no null values are pushed onto the stack, Pop won't return a null.
            string editStr = (string)_editHistory.Pop()!;
            int loc = (int)_editHistory.Pop()!;
            bool isDel = (bool)_editHistory.Pop()!;
            _undoHistory.Push(isDel);
            _undoHistory.Push(loc);
            _undoHistory.Push(editStr);
            DoEdit(uxEditBuffer, !isDel, loc, editStr);
            uxRedo.Enabled = true;
            uxUndo.Enabled = _editHistory.Count > 0;
        }

        /// <summary>
        /// Handles a Click event on the Redo menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void RedoClick(object sender, EventArgs e)
        {
            // Because no null values are pushed onto the stack, Pop won't return a null.
            string editStr = (string)_undoHistory.Pop()!;
            int loc = (int)_undoHistory.Pop()!;
            bool isDel = (bool)_undoHistory.Pop()!;
            _editHistory.Push(isDel);
            _editHistory.Push(loc);
            _editHistory.Push(editStr);
            DoEdit(uxEditBuffer, isDel, loc, editStr);
            uxUndo.Enabled = true;
            uxRedo.Enabled = _undoHistory.Count > 0;
        }
    }
}

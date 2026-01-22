/* UserInterface.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.TrieLibrary;

namespace Ksu.Cis300.Prefixes
{
    /// <summary>
    /// A GUI for a program to display all completions of a prefix.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The legal words.
        /// </summary>
        private ITrie _words = new TrieWithNoChildren();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Open Word List" button.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void OpenClick(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _words = new TrieWithNoChildren();
                    using (StreamReader input = new(uxOpenDialog.FileName))
                    {
                        while (!input.EndOfStream)
                        {
                            // Because we aren't at the end of the stream, ReadLine
                            // shouldn't return null.
                            _words = _words.Add(input.ReadLine()!);
                        }
                    }
                    MessageBox.Show("Word list successfully read.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Look up Prefix" button.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void LookUpClick(object sender, EventArgs e)
        {

        }
    }
}

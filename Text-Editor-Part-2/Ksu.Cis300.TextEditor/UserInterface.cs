/* UserInterface.cs
 * Author: Josh Weese
 */
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
    }
}

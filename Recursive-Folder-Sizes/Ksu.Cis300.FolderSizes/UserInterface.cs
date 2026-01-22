/* UserInterface.cs
 * Author: Josh Weese
 */
namespace Ksu.Cis300.FolderSizes
{
    /// <summary>
    /// A GUI for a program that finds sizes of folders.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The subfolders currently being shown.
        /// </summary>
        private DirectoryInfo[] _subfolders = new DirectoryInfo[0];

        /// <summary>
        /// Construcst the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Finds the size of the given folder.
        /// </summary>
        /// <param name="folder">The folder to measure.</param>
        /// <returns>The size in bytes of the given folder.</returns>
        private static long TotalSize(DirectoryInfo folder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the currently-analyzed folder to the given path name.
        /// </summary>
        /// <param name="folder">The path name for the folder to analyze.</param>
        private void SetCurrentFolder(DirectoryInfo folder)
        {
            uxCurrentFolder.Text = folder.FullName;
            uxCurrentFolder.SelectionStart = folder.FullName.Length;
            long size = TotalSize(folder);
            uxSize.Text = size.ToString("N0");
            uxFolderList.Items.Clear();
            uxUp.Enabled = folder.Parent != null;
            _subfolders = folder.GetDirectories();
            try
            {
                foreach (DirectoryInfo d in _subfolders)
                {
                    uxFolderList.Items.Add(d.Name);
                }
            }
            catch
            {
                // If we can't access the sub-folders, we can't add them to the list.
            }
        }

        /// <summary>
        /// Handles a Click event on the "Folder:" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void OpenClick(object sender, EventArgs e)
        {
            if (uxFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                SetCurrentFolder(new DirectoryInfo(uxFolderBrowser.SelectedPath));
            }
        }

        /// <summary>
        /// Handles a SelectedIndexChanged event on the folder list.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void FolderListSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = uxFolderList.SelectedIndex;
            if (index >= 0)
            {
                DirectoryInfo d = _subfolders[index];
                if (d != null)
                {
                    SetCurrentFolder(d);
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "^" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void UpClick(object sender, EventArgs e)
        {
            DirectoryInfo d = new(uxCurrentFolder.Text);
            // This menu item is only enabled when d.Parent is non-null.
            SetCurrentFolder(d.Parent!);
        }
    }
}

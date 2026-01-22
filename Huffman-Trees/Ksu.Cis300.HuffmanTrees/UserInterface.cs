/* UserInterface.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.PriorityQueueLibrary;
using Ksu.Cis300.ImmutableBinaryTrees;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.HuffmanTrees
{
    /// <summary>
    /// A GUI for a program that builds and displays Huffman trees.
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
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information on the event.</param>
        private void SelectFileClick(object sender, EventArgs e)
        {

        }
    }
}

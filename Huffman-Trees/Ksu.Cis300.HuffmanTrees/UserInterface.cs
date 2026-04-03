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
        /// A constant field defining th length of the frequency table
        /// </summary>
        private const int _length = 256;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to build a frequency table from a given file
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>returns a long containing the frequency table</returns>
        private static long[] FrequencyTableBuilder(string fileName)
        {
            long[] freq = new long[_length];

            using (FileStream fs = File.OpenRead(fileName))
            {
                int b;
                while ((b = fs.ReadByte()) != -1)
                {
                    freq[b]++;
                }
            }

            return freq;
        }

        /// <summary>
        /// A method that builds the leaves of the Huffman tree
        /// </summary>
        /// <param name="a"> long giving the frequency table</param>
        /// <returns>returns a min priority queue containing the leaves </returns>
        private static MinPriorityQueue<long, BinaryTreeNode<byte>> BuildLeaves(long[] a)
        {
            MinPriorityQueue<long, BinaryTreeNode<byte>> pq = new MinPriorityQueue<long, BinaryTreeNode<byte>>();

            for (int i = 0; i < _length; i++)
            {
                if (a[i] > 0)
                {
                    BinaryTreeNode<byte> node = new BinaryTreeNode<byte>((byte)i, null, null);

                    pq.Add(a[i], node);
                }
            }

            return pq;
        }

        /// <summary>
        /// A method to build the Huffman tree
        /// </summary>
        /// <param name="pq"> the MinPriorityQueue containing the leaves</param>
        /// <returns> a BinaryTreeNode containing the Huffman tree </returns>
        private static BinaryTreeNode<byte> HuffmanTree(MinPriorityQueue<long, BinaryTreeNode<byte>> pq)
        {
            while (pq.Count > 1)
            {
                long p1 = pq.MinPriority;
                BinaryTreeNode<byte> t1 = pq.RemoveMinPriorityElement();

                long p2 = pq.MinPriority;
                BinaryTreeNode<byte> t2 = pq.RemoveMinPriorityElement();

                BinaryTreeNode<byte> combined = new BinaryTreeNode<byte>(0, t1, t2);

                pq.Add(p1 + p2, combined);
            }

            return pq.RemoveMinPriorityElement();
        }

        /// <summary>
        /// Handles a Click event on the "Select a File" button.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information on the event.</param>
        private void SelectFileClick(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryTreeNode<byte> t;

                    long[] freq = FrequencyTableBuilder(uxOpenDialog.FileName);
                    var pq = BuildLeaves(freq);
                    t = HuffmanTree(pq);

                    new TreeForm(t, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

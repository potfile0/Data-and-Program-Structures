/*
 * Author: 
 * 
 */

using System;
using System.IO;
using System.Windows.Forms;
using KansasStateUniversity.TreeViewer2;

namespace KSU.CIS300.RBTrees
{
    /// <summary>
    /// User interface to use the rbtree
    /// </summary>
    public partial class UserInterface : Form
    {

        /// <summary>
        /// The red black tree that holds all the name entries loaded from the file
        /// </summary>
        private RBTree<NameEntry> _tree;

        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads a file and loads all the name entries into a new red black tree
        /// </summary>
        /// <param name="fn">The path of the file to read from</param>
        /// <returns>A new red black tree containing all the name entries from the file</returns>
        private RBTree<NameEntry> ReadFile(string fn)
        {
            RBTree<NameEntry> tree = new RBTree<NameEntry>();
            using (StreamReader reader = new StreamReader(fn))
            {
                while (!reader.EndOfStream)
                {
                    string name = reader.ReadLine().Trim();
                    float frequency = float.Parse(reader.ReadLine());
                    int rank = int.Parse(reader.ReadLine());
                    tree.Insert(new NameEntry(name, frequency, rank));
                }
            }
            return tree;
        }

        /// <summary>
        /// Opens a file dialog so the user can pick a names file, loads it into the tree and shows it
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">The event data</param>
        private void LoadNames_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _tree = ReadFile(uxOpenFileDialog.FileName);
                    new TreeForm(_tree, 10000).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Tries to remove the name typed in the text box from the tree and shows the updated tree if successful
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">The event data</param>
        private void RemoveName_Click(object sender, EventArgs e)
        {
            NameEntry dummy = new NameEntry(uxTextBox_Name.Text, 0, 0);
            if (_tree.Remove(dummy))
            {
                MessageBox.Show($"{uxTextBox_Name.Text} was removed.");
                new TreeForm(_tree, 10000).Show();
            }
            else
            {
                MessageBox.Show($"{uxTextBox_Name.Text} was not found in the tree.");
            }
        }

        /// <summary>
        /// Looks up the name typed in the text box and displays its frequency and rank if found
        /// </summary>
        /// <param name="sender">The object that triggered the event</param>
        /// <param name="e">The event data</param>
        private void LookupName_Click(object sender, EventArgs e)
        {
            NameEntry dummy = new NameEntry(uxTextBox_Name.Text, 0, 0);
            if (_tree.Find(dummy, out NameEntry result))
            {
                uxTextBox_Freq.Text = result.Frequency.ToString();
                uxTextBox_Rank.Text = result.Rank.ToString();
            }
            else
            {
                MessageBox.Show($"{uxTextBox_Name.Text} was not found in the tree.");
                uxTextBox_Freq.Clear();
                uxTextBox_Rank.Clear();
            }
        }

    }
}

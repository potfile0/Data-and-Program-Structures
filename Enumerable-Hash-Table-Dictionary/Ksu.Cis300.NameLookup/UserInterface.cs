/* UserInterface.cs
 * Author: Josh Weese
 */
namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program to look up information on names.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The index in uxTable.Items of the frequency.
        /// </summary>
        private const int _frequencyIndex = 0;

        /// <summary>
        /// The index in uxTable.Items of the rank.
        /// </summary>
        private const int _rankIndex = 1;

        /// <summary>
        /// The index in uxTable of the values column.
        /// </summary>
        private const int _valueIndex = 1;

        /// <summary>
        /// The information for each name.
        /// </summary>
        private DictionaryLibrary.Dictionary<string, FrequencyAndRank> _nameInformation = new();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the given input file into a dictionary.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A dictionary whose keys are the names from the file and whose values give the frequency and 
        /// rank for each name.</returns>
        private static DictionaryLibrary.Dictionary<string, FrequencyAndRank> ReadFile(string fn)
        {
            DictionaryLibrary.Dictionary<string, FrequencyAndRank> d = new();
            using (StreamReader input = new(fn))
            {
                while (!input.EndOfStream)
                {
                    // Because input is not at the end of the stream, ReadLine won't return null.
                    string name = input.ReadLine()!.Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    d.Add(name, new FrequencyAndRank(freq, rank));
                }
            }
            return d;
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
                    _nameInformation = ReadFile(uxOpenDialog.FileName);
                    MessageBox.Show("File successfully read.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Lookup" button.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void LookupClick(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            if (_nameInformation.TryGetValue(name, out FrequencyAndRank info))
            {
                SetValue(_frequencyIndex, info.Frequency);
                SetValue(_rankIndex, info.Rank);
            }
            else
            {
                MessageBox.Show("Name not found.");
                SetValue(_frequencyIndex, "");
                SetValue(_rankIndex, "");
            }
        }

        /// <summary>
        /// Sets the value of the table item at the specified index to the given value.
        /// The given value will be displayed as a string.
        /// </summary>
        /// <param name="index">The index in uxTable.Items of the item whose value is to
        /// be set.</param>
        /// <param name="value">The value for the specified item.</param>
        private void SetValue(int index, object value)
        {
            uxTable.Items[index].SubItems[_valueIndex].Text = value.ToString();
        }

        /// <summary>
        /// Handles a Click event on the Remove menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void RemoveClick(object sender, EventArgs e)
        {
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
                    using (StreamWriter output = new(uxSaveDialog.FileName))
                    {
                        foreach (KeyValuePair<string, FrequencyAndRank> pair in _nameInformation)
                        {
                            output.WriteLine(pair.Key);
                            output.WriteLine(pair.Value.Frequency.ToString());
                            output.WriteLine(pair.Value.Rank.ToString());
                        }
                    }
                    MessageBox.Show("File written.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

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
        /// A Dictionary that takes a key and a value 
        /// </summary>
        private Dictionary<string, FrequencyAndRank> _infoDictionary = new();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>

        public UserInterface()
        {
            InitializeComponent();
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
        /// A method ReadFile to read a file provided by the user and then
        /// return a dictionary with the file contents
        /// </summary>
        /// <param name="fileName">name of the file user wants to read</param>
        /// <returns>returns a dictionary</returns>
        private static Dictionary<string, FrequencyAndRank> ReadFile(string fileName)
        {
            using (StreamReader input = new StreamReader(fileName))
            {

                Dictionary<string, FrequencyAndRank> temp = new Dictionary<string, FrequencyAndRank>();
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine()!.Trim();
                    float frequency = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());

                    FrequencyAndRank dictionary = new FrequencyAndRank(frequency, rank);

                    temp.Add(name!, dictionary);
                }
                return temp;
            }

        }


        /// <summary>
        /// An event handler for the Lookup button
        /// </summary>
        /// <param name="sender">a sender</param>
        /// <param name="e">events</param>
        private void UxLookup_Click(object sender, EventArgs e)
        {

            ListView list = new ListView();
            string name = uxName.Text.ToUpper().Trim();
            if (_infoDictionary.TryGetValue(name, out FrequencyAndRank value))
            {
                SetValue(_rankIndex, value.Rank);
                SetValue(_frequencyIndex, value.Frequency);
            }
            else
            {
                MessageBox.Show("Name not found");
                SetValue(_rankIndex, "");
                SetValue(_frequencyIndex, "");

            }
        }

        /// <summary>
        /// An event handler for the lookup button
        /// </summary>
        /// <param name="sender">a sender</param>
        /// <param name="e">events</param>
        private void UxOpenClick(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _infoDictionary = ReadFile(uxOpenDialog.FileName);

                    MessageBox.Show("File Read Successfully");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

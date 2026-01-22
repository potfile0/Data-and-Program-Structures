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
    }
}

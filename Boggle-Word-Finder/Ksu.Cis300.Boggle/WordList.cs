/* WordList.cs
 * Author: Josh Weese
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Ksu.Cis300.Boggle
{
    /// <summary>
    /// A dialog that displays a list of words.
    /// </summary>
    public partial class WordList : Form
    {
        /// <summary>
        /// Gets the list of words.
        /// </summary>
        public IList List => uxWords.Items;

        /// <summary>
        /// Constructs the dialog.
        /// </summary>
        public WordList()
        {
            InitializeComponent();
        }
    }
}

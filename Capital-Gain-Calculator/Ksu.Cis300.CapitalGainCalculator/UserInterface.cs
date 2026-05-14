/* UserInterface.cs
 * Author: Josh Weese
 */
using System.Collections.Generic;
namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A user interface for a simple captial gain calculator for a single stock commodity.
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
        /// a private field that will store the costs of each share currently owned
        /// </summary>
        private Queue<decimal> _decimals = new Queue<decimal>();

        /// <summary>
        /// event handler for the buy button
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void uxBuy_Click(object sender, EventArgs e)
        {
            decimal numberOfShares = uxNumber.Value;
            decimal cost = uxCost.Value;

            for (int i = 0; i < numberOfShares; i++)
            {
                _decimals.Enqueue(cost);
            }

            uxOwned.Text = _decimals.Count.ToString();
        }

        /// <summary>
        /// an event handler for the click button
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void uxSell_Click(object sender, EventArgs e)
        {
            decimal numberOfShares = uxNumber.Value;

            if (numberOfShares > _decimals.Count)
            {
                MessageBox.Show("User does not own that many shares");
                return;
            }

            decimal accumulatedGain = Convert.ToDecimal(uxGain.Text);
            decimal sellPrice = uxCost.Value;

            for (int i = 0; i < numberOfShares; i++)
            {
                decimal purchaseCost = _decimals.Dequeue();
                accumulatedGain += sellPrice - purchaseCost;
            }

            uxOwned.Text = _decimals.Count.ToString();
            uxGain.Text = accumulatedGain.ToString();
        }
    }
}

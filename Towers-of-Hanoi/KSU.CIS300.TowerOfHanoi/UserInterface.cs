///
/// Project: Homework 1 - Tower of Hanoi
/// Author: Sanskar Luitel
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KSU.CIS300.TowerOfHanoi
{
    /// <summary>
    /// The main class and only class for the Program
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// A property with a default getter and a private default setter that keeps track of the number of moves made for the current puzzle.
        /// </summary>
        public int MoveCount { get; private set; }

        /// <summary>
        /// A property with a default getter and setter that indicates if the program is in test mode or not. 
        /// This is used by the unit tests in order to skip over MessageBox prompts.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// The stack that stores the discs for the first peg.This property has a default getter and setter.
        /// </summary>
        public Stack<int> PegA { get; set; }

        /// <summary>
        /// The stack that stores the discs for the second peg. This property has a default getter and setter.
        /// </summary>
        public Stack<int> PegB { get; set; }

        /// <summary>
        /// The stack that stores the discs for the third peg. This property has a default getter and setter.
        /// </summary>
        public Stack<int> PegC { get; set; }

        /// <summary>
        /// The number of discs being used for the current puzzle.
        /// </summary>
        private int _discCount;

        /// <summary>
        /// Stores the history of source positions for manual moves,
        /// used to support the Undo feature.
        /// </summary>
        private Stack<Stack<int>> _moveFromHistory = new();

        /// <summary>
        /// Stores the history of destination positions for manual moves,
        /// used to support the Undo feature.
        /// </summary>
        private Stack<Stack<int>> _moveToHistory = new();


        /// <summary>
        /// Creates a new puzzle with the specified number of discs.
        /// Resets the move counter, clears all pegs and UI panels,
        /// and initializes PegA with discs in descending order.
        /// </summary>
        /// <param name="count">The number of discs to generate.</param>
        public void NewPuzzle(int count)
        {
            MoveCount = 0;

            PegA = new();
            PegB.Clear();
            PegC.Clear();

            CleanPanel(flowLayoutPanel1);
            CleanPanel(flowLayoutPanel2);
            CleanPanel(flowLayoutPanel3);

            _discCount = count;

            // Add discs to PegA from largest to smallest
            for (int i = _discCount; i > 0; i--)
            {
                PegA.Push(i);
                DrawDisc(i, flowLayoutPanel1);
            }
        }

        /// <summary>
        /// Initializes a new instance of the UserInterface class.
        /// Sets up the form components, initializes the peg stacks,
        /// retrieves the disc count from the NumericUpDown control,
        /// and calls NewPuzzle to generate the initial puzzle state.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

            PegA = new Stack<int>();
            PegB = new Stack<int>();
            PegC = new Stack<int>();

            int count = (int)numericUpDown1.Value;
            NewPuzzle(count);
        }


        /// <summary>
        /// Creates a visual representation of a disc and adds it to the specified panel.
        /// The disc size is calculated dynamically based on its number and the total disc count.
        /// </summary>
        /// <param name="number">The numeric value representing the disc size.</param>
        /// <param name="panel">The FlowLayoutPanel where the disc will be displayed.</param>
        private void DrawDisc(int number, FlowLayoutPanel panel)
        {
            Label disc = new Label();

            // Calculate disc width relative to total disc count
            disc.Width = (int)(panel.Width / (_discCount - number + 1.25));

            // Center the disc horizontally within the panel
            Padding temp = disc.Margin;
            temp.Left = (int)((panel.Width - disc.Width) / 2);
            temp.Right = (int)((panel.Width - disc.Width) / 2);
            disc.Margin = temp;

            // Set disc color based on whether total disc count is even or odd
            if (_discCount % 2 == 0)
            {
                disc.BackColor = Color.Gray;
            }
            else
            {
                disc.BackColor = Color.Red;
            }

            disc.Text = number.ToString();
            disc.TextAlign = ContentAlignment.MiddleCenter;

            panel.Controls.Add(disc);
        }


        /// <summary>
        /// Removes and disposes all controls from the specified FlowLayoutPanel.
        /// This ensures the panel is fully cleared and releases associated resources.
        /// </summary>
        /// <param name="panel">The FlowLayoutPanel to clear.</param>
        private void CleanPanel(FlowLayoutPanel panel)
        {
            // Store controls in a stack to safely remove them
            Stack<Control> controls = new Stack<Control>();

            foreach (Control control in panel.Controls)
            {
                controls.Push(control);
            }

            // Remove and dispose each control
            while (controls.Count > 0)
            {
                Control x = controls.Pop();
                panel.Controls.Remove(x);
                x.Dispose();
            }
        }


        /// <summary>
        /// Synchronizes the visual panels with their corresponding stacks.
        /// Moves the top control from the source panel to the appropriate
        /// destination panel based on stack count differences.
        /// </summary>
        /// <param name="source">The source FlowLayoutPanel.</param>
        /// <param name="sourceStack">The stack associated with the source panel.</param>
        /// <param name="dest">The primary destination FlowLayoutPanel.</param>
        /// <param name="destStack">The stack associated with the primary destination panel.</param>
        /// <param name="alt">The alternative destination FlowLayoutPanel.</param>
        /// <param name="altStack">The stack associated with the alternative destination panel.</param>
        /// <returns>Always returns true.</returns>
        private bool UpdatePanelHelper(
            FlowLayoutPanel source, Stack<int> sourceStack,
            FlowLayoutPanel dest, Stack<int> destStack,
            FlowLayoutPanel alt, Stack<int> altStack)
        {
            Control temp = null;

            // Check if the visual panel and its stack are out of sync
            if (source.Controls.Count != sourceStack.Count)
            {
                // A disc was removed from the stack, so remove it from the panel
                if (source.Controls.Count > sourceStack.Count)
                {
                    temp = source.Controls[source.Controls.Count - 1];
                    source.Controls.RemoveAt(source.Controls.Count - 1);
                    source.Update();

                    // Add the control to whichever destination panel matches its stack state
                    if (dest.Controls.Count < destStack.Count)
                    {
                        dest.Controls.Add(temp);
                        dest.Update();
                    }
                    else if (alt.Controls.Count < altStack.Count)
                    {
                        alt.Controls.Add(temp);
                        alt.Update();
                    }
                }

                // A disc was restored to the stack (e.g., undo), so restore it to the panel
                if (source.Controls.Count < sourceStack.Count)
                {
                    if (temp != null)
                    {
                        source.Controls.Add(temp);
                        source.Update();
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// Updates the UI to reflect the current state of the peg stacks.
        /// Calls UpdatePanelHelper to synchronize the panels with their corresponding stacks.
        /// </summary>
        private void UpdatePanels()
        {
            UpdatePanelHelper(flowLayoutPanel1, PegA, flowLayoutPanel2, PegB, flowLayoutPanel3, PegC);
        }


        /// <summary>
        /// Determines whether a move from one peg stack to another is valid
        /// according to Tower of Hanoi rules.
        /// </summary>
        /// <param name="from">The source stack of discs.</param>
        /// <param name="to">The destination stack of discs.</param>
        /// <returns>
        /// True if the move is valid (either the destination is empty 
        /// or the top disc on the source is smaller than the top disc on the destination); 
        /// otherwise, false.
        /// </returns>
        public bool CheckMove(Stack<int> from, Stack<int> to)
        {
            if (from.Count == 0)
            {
                return false;
            }
            else if (to.Count == 0)
            {
                return true;
            }
            else
            {
                return from.Peek() < to.Peek();
            }
        }


        /// <summary>
        /// Attempts to move the top disc from one peg stack to another.
        /// Increments the move counter, updates the UI, and disables/enables
        /// the undo button based on the current state.
        /// </summary>
        /// <param name="from">The source stack of discs.</param>
        /// <param name="to">The destination stack of discs.</param>
        /// <returns>
        /// True if the move was successful; false if the move is invalid.
        /// </returns>
        public bool MoveDisc(Stack<int> from, Stack<int> to)
        {
            // Validate the move first
            if (!CheckMove(from, to))
            {
                return false;
            }

            // Update move count and UI
            MoveCount++;
            label2.Text = MoveCount.ToString();
            label2.Update();

            // Move the disc between stacks
            int disc = from.Pop();
            to.Push(disc);

            // Enable or disable undo button based on PegB or PegC state
            if (PegB.Count > 0 || PegC.Count > 0)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }

            // Update visual representation of panels
            UpdatePanels();

            return true;
        }


        /// <summary>
        /// Attempts to move a disc from stack <paramref name="x"/> to stack <paramref name="y"/>.
        /// If the move is invalid, attempts the reverse move from <paramref name="y"/> to <paramref name="x"/>.
        /// </summary>
        /// <param name="x">The first stack involved in the move.</param>
        /// <param name="y">The second stack involved in the move.</param>
        public void MoveEither(Stack<int> x, Stack<int> y)
        {
            // Try moving from x to y; if invalid, move from y to x
            bool moved = MoveDisc(x, y);

            if (!moved)
            {
                MoveDisc(y, x);
            }
        }

        /// <summary>
        /// Checks if the puzzle has been solved.
        /// The puzzle is considered won when all discs are on PegC.
        /// </summary>
        /// <returns>
        /// True if all discs are on PegC; otherwise, false.
        /// </returns>
        public bool CheckIfWon()
        {
            // Puzzle is won if PegC contains all discs
            return PegC.Count == _discCount;
        }

        /// <summary>
        /// Automatically solves the Tower of Hanoi puzzle with a visual delay.
        /// Moves discs between pegs until all discs are on PegC.
        /// </summary>
        /// <param name="x">The first auxiliary peg stack used during solving.</param>
        /// <param name="y">The second auxiliary peg stack used during solving.</param>
        /// <param name="delay">The delay in milliseconds between moves for visualization.</param>
        public void Solve(Stack<int> x, Stack<int> y, int delay)
        {
            // Continue moving discs until the puzzle is completed
            while (PegC.Count != _discCount)
            {
                // Attempt moves from PegA to x
                MoveEither(PegA, x);
                Thread.Sleep(delay);
                if (CheckIfWon())
                {
                    break;
                }

                // Attempt moves from PegA to y
                MoveEither(PegA, y);
                Thread.Sleep(delay);
                if (CheckIfWon())
                {
                    break;
                }

                // Attempt moves from PegB to PegC
                MoveEither(PegB, PegC);
                Thread.Sleep(delay);
                if (CheckIfWon())
                {
                    break;
                }
            }
        }


        /// <summary>
        /// Event handler for the "New Puzzle" button (button1).
        /// Creates a new puzzle using the number of discs specified in the NumericUpDown control.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Start a new puzzle with the selected disc count
            NewPuzzle((int)numericUpDown1.Value);
        }


        /// <summary>
        /// Event handler triggered when a control is added to PegC's FlowLayoutPanel.
        /// Checks if the player has won the game and displays an appropriate message.
        /// </summary>
        /// <param name="sender">The FlowLayoutPanel that triggered the event.</param>
        /// <param name="e">Event arguments for the control addition.</param>
        private void FlowLayoutPanelPegC_ControlAdded(object sender, ControlEventArgs e)
        {
            // Check if PegC visually contains all discs
            if (flowLayoutPanel3.Controls.Count == _discCount)
            {
                // Ensure all discs are on PegC and other pegs are empty
                if (PegC.Count == _discCount && PegA.Count == 0 && PegB.Count == 0)
                {
                    // Check if the player completed the puzzle in the optimal number of moves
                    if (MoveCount == (int)(Math.Pow(2, _discCount) - 1))
                    {
                        MessageBox.Show("You won the Game in the optimal number of moves!!!! You're a Genius!!!!");
                    }
                    else
                    {
                        MessageBox.Show("You won the Game!!!! Hoorayyyyyy!!!!");
                    }
                }
            }
        }


        /// <summary>
        /// Event handler for the "Solve" button (button3).
        /// Automatically solves the puzzle using the current disc count and delay value.
        /// Chooses the auxiliary peg order based on whether the number of discs is even or odd.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Solve the puzzle with a delay retrieved from numericUpDown2
            if (_discCount % 2 == 0)
            {
                Solve(PegB, PegC, (int)(numericUpDown2.Value));
            }
            else
            {
                Solve(PegC, PegB, (int)(numericUpDown2.Value));
            }
        }


        /// <summary>
        /// Event handler for the "Move Left" button under Peg A (button4).
        /// Moves the top disc from PegA to PegC and records the move for undo history.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            // Move the top disc from PegA to PegC
            MoveDisc(PegA, PegC);

            // Record this manual move for undo functionality
            HistroyOfManualMoves(PegA, PegC);
        }


        /// <summary>
        /// Event handler for the "Move Right" button under Peg A (button7).
        /// Moves the top disc from PegA to PegB and records the move for undo history.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button7_Click(object sender, EventArgs e)
        {
            // Move the top disc from PegA to PegB
            MoveDisc(PegA, PegB);

            // Record this manual move for undo functionality
            HistroyOfManualMoves(PegA, PegB);
        }


        /// <summary>
        /// Event handler for the "Move Left" button under Peg B (button5).
        /// Moves the top disc from PegB to PegA and records the move for undo history.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            // Move the top disc from PegB to PegA
            MoveDisc(PegB, PegA);

            // Record this manual move for undo functionality
            HistroyOfManualMoves(PegB, PegA);
        }


        /// <summary>
        /// Event handler for the "Move Right" button under Peg B (button8).
        /// Moves the top disc from PegB to PegC and records the move for undo history.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button8_Click(object sender, EventArgs e)
        {
            // Move the top disc from PegB to PegC
            MoveDisc(PegB, PegC);

            // Record this manual move for undo functionality
            HistroyOfManualMoves(PegB, PegC);
        }


        /// <summary>
        /// Event handler for the "Move Left" button under Peg C (button6).
        /// Moves the top disc from PegC to PegB and records the move for undo history.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button6_Click(object sender, EventArgs e)
        {
            // Move the top disc from PegC to PegB
            MoveDisc(PegC, PegB);

            // Record this manual move for undo functionality
            HistroyOfManualMoves(PegC, PegB);
        }

        /// <summary>
        /// Event handler for the "Move Right" button under Peg C (button9).
        /// Moves the top disc from PegC to PegA and records the move for undo history.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button9_Click(object sender, EventArgs e)
        {
            // Move the top disc from PegC to PegA
            MoveDisc(PegC, PegA);

            // Record this manual move for undo functionality
            HistroyOfManualMoves(PegC, PegA);
        }

        /// <summary>
        /// Records a manual move of a disc between two peg stacks.
        /// Pushes the source and destination stacks onto the history stacks
        /// for undo functionality.
        /// </summary>
        /// <param name="from">The source stack of the move.</param>
        /// <param name="to">The destination stack of the move.</param>
        public void HistroyOfManualMoves(Stack<int> from, Stack<int> to)
        {
            _moveFromHistory.Push(from);
            _moveToHistory.Push(to);
        }


        /// <summary>
        /// Event handler for the "Undo" button (button2).
        /// Reverts the last manual move by popping from the move history stacks
        /// and moving the disc back to its original peg.
        /// Disables the undo button if there are no more moves to undo.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event arguments.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Check if there are any moves to undo
            if (_moveFromHistory.Count > 0)
            {
                // Retrieve the last move from history
                Stack<int> lastFrom = _moveFromHistory.Pop();
                Stack<int> lastTo = _moveToHistory.Pop();

                // Move the disc back to its original stack
                MoveDisc(lastTo, lastFrom);

                // Disable the undo button if history is now empty
                if (_moveFromHistory.Count == 0)
                {
                    button2.Enabled = false;
                }
            }
        }

    }
}

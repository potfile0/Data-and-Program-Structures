///
/// Project: Homework 1 - Tower of Hanoi
/// Author: 
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KSU.CIS300.TowerOfHanoi
{

    public partial class UserInterface : Form
    {
        public int MoveCount { get; private set; }

        public bool TestMode { get; set; }

        public Stack<int> PegA { get; set; }

        public Stack<int> PegB { get; set; }

        public Stack<int> PegC { get; set; }

        private int _discCount;


        //to keep track of the manual move, made 2 stacks that store entire stacks
        Stack<Stack<int>> moveFrom = new Stack<Stack<int>>();
        Stack<Stack<int>> moveTo = new Stack<Stack<int>>();

        public void NewPuzzle(int count)
        {
            MoveCount = 0;
            PegA.Clear();
            PegB.Clear();
            PegC.Clear();
            CleanPanel(flowLayoutPanel1);
            CleanPanel(flowLayoutPanel2);
            CleanPanel(flowLayoutPanel3);
            _discCount = count;

            for (int i = _discCount; i > 0; i--)
            {
                PegA.Push(i);
                DrawDisc(i, flowLayoutPanel1);
            }


        }
        public UserInterface()
        {
            InitializeComponent();
            PegA = new Stack<int>();
            PegB = new Stack<int>();
            PegC = new Stack<int>();
            int count = (int)numericUpDown1.Value;
            NewPuzzle(count);
        }

        private void DrawDisc(int number, FlowLayoutPanel panel)
        {
            Label disc = new Label();
            disc.Width = (int)(panel.Width / (_discCount - number + 1.25));
            Padding temp = disc.Margin;
            temp.Left = (int)((panel.Width - disc.Width) / 2);
            temp.Right = (int)((panel.Width - disc.Width) / 2);

            disc.Margin = temp;



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

        private void CleanPanel(FlowLayoutPanel panel)
        {
            Stack<Control> controls = new Stack<Control>();
            foreach (Control control in panel.Controls)
            {
                controls.Push(control);
            }
            while (controls.Count > 0)
            {
                Control x = controls.Pop();
                panel.Controls.Remove(x);
                x.Dispose();

            }
        }

       

        private bool UpdatePanelHelper(
            FlowLayoutPanel source, Stack<int> sourceStack,
            FlowLayoutPanel dest, Stack<int> destStack,
            FlowLayoutPanel alt, Stack<int> altStack)
        {
            Control temp = null;

            if (source.Controls.Count != sourceStack.Count)
            {
                if (source.Controls.Count > sourceStack.Count)
                {
                    temp = source.Controls[source.Controls.Count - 1];
                    source.Controls.RemoveAt(source.Controls.Count - 1);
                    source.Update();

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

        private void UpdatePanels()
        {
            UpdatePanelHelper(flowLayoutPanel1, PegA, flowLayoutPanel2, PegB, flowLayoutPanel3, PegC);
        }

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
                if (from.Peek() < to.Peek())
                {
                    return true;
                }
                return false;
            }
        }

        public bool MoveDisc(Stack<int> from, Stack<int> to)
        {
            if (!CheckMove(from, to))
            {
                return false;
            }

            int disc = from.Pop();
            to.Push(disc);

            MoveCount++;
            label2.Text = MoveCount.ToString();
            label2.Update();

            UpdatePanels();

            return true;
        }

        public void MoveEither(Stack<int> x, Stack<int> y)
        {
            bool moved = MoveDisc(x, y);

            if (!moved)
            {
                MoveDisc(y, x);
            }
        }
        //check to see if the tower is complete
        public bool CheckIfWon()
        {
            if (PegC.Count != numericUpDown1.Value)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public void Solve(Stack<int> x, Stack<int> y, int delay)
        {
            while (PegC.Count != numericUpDown1.Value)
            {
                MoveEither(PegA, x);
                if (CheckIfWon().Equals(true))
                {
                    break;
                }
                Thread.Sleep(delay);
                MoveEither(PegA, y);
                if (CheckIfWon().Equals(true))
                {
                    break;
                }
                Thread.Sleep(delay);
                MoveEither(PegB, PegC);
                if (CheckIfWon().Equals(true))
                {
                    break;
                }
                Thread.Sleep(delay);
            }
        }

        //new button event handler
        private void button1_Click(object sender, EventArgs e)
        {
            NewPuzzle((int)numericUpDown1.Value);
        }

        private void FlowLayoutPanelPegC_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel3.Controls.Count == _discCount)
            {
                if (PegC.Count == _discCount && PegA.Count == 0 && PegB.Count == 0)
                {
                    if (MoveCount == (int)(Math.Pow(2, _discCount) - 1))
                    {
                        MessageBox.Show("You won the Game in the optimal number of moves!!!!You're a Genius!!!!");
                    }
                    else
                    {
                        MessageBox.Show("You won the Game!!!! Hoorayyyyyy!!!!");
                    }
                }
            }

        }

        //solve button event handler
        private void button3_Click(object sender, EventArgs e)
        {
            if (_discCount % 2 == 0)
            {
                Solve(PegB, PegC, (int)(numericUpDown2.Value));
            }
            else
            {
                Solve(PegC, PegB, (int)(numericUpDown2.Value));
            }

        }

        //Move Left button under Peg A
        private void button4_Click(object sender, EventArgs e)
        {
            MoveDisc(PegA, PegC);
            HistroyOfManualMoves(PegA, PegC);
        }

        //Move Right Button under Peg A
        private void button7_Click(object sender, EventArgs e)
        {
            MoveDisc(PegA, PegB);
            HistroyOfManualMoves(PegA, PegB);
        }

        //Move Left button under Peg B
        private void button5_Click(object sender, EventArgs e)
        {
            MoveDisc(PegB, PegA);
            HistroyOfManualMoves(PegB, PegA);
        }

        //Move Right Button under Peg B
        private void button8_Click(object sender, EventArgs e)
        {
            MoveDisc(PegB, PegC);
            HistroyOfManualMoves(PegB, PegC);
        }

        //Move Left button under Peg C
        private void button6_Click(object sender, EventArgs e)
        {
            MoveDisc(PegC, PegB);
            HistroyOfManualMoves(PegC, PegB);
        }

        //Move Right Button under Peg C
        private void button9_Click(object sender, EventArgs e)
        {
            MoveDisc(PegC, PegA);
            HistroyOfManualMoves(PegC, PegA);
        }

        //to keep the history of manual move
        public void HistroyOfManualMoves(Stack<int> from, Stack<int> to)
        {
            moveFrom.Push(from);
            moveTo.Push(to);
        }
        


        //Undo button event handler
        private void button2_Click(object sender, EventArgs e)
        {
            if (moveFrom.Count > 0)
            {
                Stack<int> lastFrom = moveFrom.Pop();
                Stack<int> lastTo = moveTo.Pop();

                MoveDisc(lastTo, lastFrom);

                if (moveFrom.Count == 0)
                {
                    button2.Enabled = false;
                }
            }
        }
    }
}

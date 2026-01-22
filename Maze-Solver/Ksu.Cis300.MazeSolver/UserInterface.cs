/* UserInterface.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.Graphs;
using Ksu.Cis300.MazeLibrary;

namespace Ksu.Cis300.MazeSolver
{
    /// <summary>
    /// A GUI for a program that solves randomly-generated mazes.
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
        /// Handles a Click event on the "New Maze" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void NewClick(object sender, EventArgs e)
        {
            uxMaze.Generate();
        }

        /// <summary>
        /// Gets a graph representing the given maze. The Direction associated with each edge
        /// is the direction from the source to the destination.
        /// </summary>
        /// <param name="maze">The maze to be represented.</param>
        /// <returns>The graph representation.</returns>
        private static DirectedGraph<Cell, Direction> GetGraph(Maze maze)
        {
            DirectedGraph<Cell, Direction> graph = new DirectedGraph<Cell, Direction>();
            for (int i = 0; i < maze.MazeHeight; i++)
            {
                for (int j = 0; j < maze.MazeWidth; j++)
                {
                    Cell cell = new(i, j);
                    if (!graph.ContainsNode(cell))
                    {
                        graph.AddNode(cell);
                    }
                    for (Direction d = Direction.North; d <= Direction.West; d++)
                    {
                        if (maze.IsClear(cell, d))
                        {
                            graph.AddEdge(cell, Maze.Step(cell, d), d);
                        }
                    }
                }
            }
            return graph;
        }
    }
}

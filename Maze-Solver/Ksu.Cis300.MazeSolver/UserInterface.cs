/* UserInterface.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.Graphs;
using Ksu.Cis300.MazeLibrary;
using static System.Net.Mime.MediaTypeNames;

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

        /// <summary>
        /// method to find the shortest path to a node outside the maze
        /// </summary>
        /// <param name="graph"> graph representing maze </param>
        /// <param name="u"> the cell </param>
        /// <param name="maze"> the maze to be representated </param>
        /// <param name="paths"> the path to set </param>
        /// <returns> a final cell in the path </returns>
        private static Cell FindPath(DirectedGraph<Cell, Direction> graph, Cell u, Maze maze, out Dictionary<Cell, Cell> paths)
        {
            //paths = new Dictionary<Cell, Cell>();
            //Queue<Cell> queue = new Queue<Cell>();

            //paths[u] = u;
            //queue.Enqueue(u);

            //while (queue.Count > 0)
            //{
            //    Cell current = queue.Dequeue();
            //    foreach (Edge<Cell, Direction> edge in graph.OutgoingEdges(current))
            //    {
            //        Cell next = edge.Destination;
            //        if (!paths.ContainsKey(next))
            //        {
            //            paths[next] = current;
            //            if (!maze.IsInMaze(next))
            //            {
            //                return next;
            //            }
            //            queue.Enqueue(next);
            //        }
            //    }
            //}
            //return default;

            paths = new Dictionary<Cell, Cell>();
            Queue<Edge<Cell, Direction>> queue = new();

            paths[u] = u;

            foreach (Edge<Cell, Direction> edge in graph.OutgoingEdges(u))
            {
                queue.Enqueue(edge);
            }

            while (queue.Count > 0)
            {
           
                Edge<Cell, Direction> edge = queue.Dequeue();
                if (!paths.ContainsKey(edge.Destination))
                {
                    paths[edge.Destination] = edge.Source;
                    if (!maze.IsInMaze(edge.Destination))
                    {
                        return edge.Destination;
                    }

                    foreach (Edge<Cell, Direction> next in graph.OutgoingEdges(edge.Destination))
                    {
                        queue.Enqueue(next);
                    }
                }
            }
            return default;
        }

        /// <summary>
        /// method to draw the shortest path from u to v
        /// </summary>
        /// <param name="u"> cell to draw from </param>
        /// <param name="v"> cell to draw to </param>
        /// <param name="maze"> the maze </param>
        /// <param name="paths">the path set</param>
        /// <param name="graph"> graph representing </param>
        private static void DisplayPath(Cell u, Cell v, Maze maze, Dictionary<Cell, Cell> paths, DirectedGraph<Cell, Direction> graph)
        {
            Cell current = v;
            while (current != u)
            {
                Cell predecessor = paths[current];
                graph.TryGetEdge(predecessor, current, out Direction d);
                maze.DrawPath(predecessor, d);
                current = predecessor;
            }
        }

        /// <summary>
        /// event handler for the cell click
        /// </summary>
        /// <param name="sender"> object </param>
        /// <param name="e"></param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = Maze.GetCellFromPixel(e.Location);
            if (uxMaze.IsInMaze(cell))
            {
                uxMaze.EraseAllPaths();
                DirectedGraph<Cell, Direction> graph = GetGraph(uxMaze);
                Cell exit = FindPath(graph, cell, uxMaze, out Dictionary<Cell, Cell> paths);
                if (exit == new Cell(0, 0))
                {
                    MessageBox.Show("There is no path from this cell.");
                }
                else
                {
                    DisplayPath(cell, exit, uxMaze, paths, graph);
                }
                uxMaze.Invalidate();
            }
        }
    }
}

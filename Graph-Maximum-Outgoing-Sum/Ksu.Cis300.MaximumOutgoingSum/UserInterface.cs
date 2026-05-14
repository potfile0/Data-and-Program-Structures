using Ksu.Cis300.Graphs;
using System.Windows.Forms;

namespace Ksu.Cis300.MaximumOutgoingSum
{
    /// <summary>
    /// userinterface
    /// </summary>
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// the source node
        /// </summary>
        private const int _sourcePosition = 0;

        /// <summary>
        /// the field containing the destination node
        /// </summary>
        private const int _destinationPosition = 1;

        /// <summary>
        /// the field containing the weight of the edge
        /// </summary>
        private const int _weightPosition = 2;

        /// <summary>
        ///  a private method to read a graph from a file.
        /// </summary>
        /// <param name="filename"> file to read</param>
        /// <returns> returns the graph read</returns>
        private DirectedGraph<string, decimal> ReadGraph(string filename)
        {
            DirectedGraph<string, decimal> graph = new();

            using (StreamReader reader = new(filename))
            {
                string ?line = reader.ReadLine(); 
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string source = parts[_sourcePosition];
                    string dest = parts[_destinationPosition];
                    decimal weight = decimal.Parse(parts[_weightPosition]);
                    graph.AddEdge(source, dest, weight);
                }
            }
            return graph;
        }

        /// <summary>
        ///  a private method to find the maximum sum of edge weights from any node in a graph
        /// </summary>
        /// <param name="graph"> takes in the graph as parameter to find the sum of the edges</param>
        /// <returns> returns the decimal</returns>
        private decimal SumOfEdges(DirectedGraph<string, decimal> graph)
        {
            decimal max = 0;

            foreach (string node in graph.Nodes)
            {
                decimal sum = 0;
                foreach (Edge<string, decimal> edge in graph.OutgoingEdges(node))
                {
                    sum += edge.Data;
                }
                if (sum > max)
                {
                    max = sum;
                }
            }

            return max;
        }

        /// <summary>
        /// event handler for the read button
        /// </summary>
        /// <param name="sender"> data</param>
        /// <param name="e"> args</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        DirectedGraph<string, decimal> graph = ReadGraph(openFileDialog1.FileName);
                        decimal max = SumOfEdges(graph);
                        MessageBox.Show("Maximum sum is " + max);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

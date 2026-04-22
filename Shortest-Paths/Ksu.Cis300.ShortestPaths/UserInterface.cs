/* UserInterface.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.Graphs;
using Ksu.Cis300.PriorityQueueLibrary;
using System.Collections;

namespace Ksu.Cis300.ShortestPaths
{
    /// <summary>
    /// A GUI for a program that finds shortest paths in real-world street maps.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The current map data.
        /// </summary>
        private DirectedGraph<string, decimal> _map = new();

        /// <summary>
        /// The internet access protocol for the map server.
        /// </summary>
        private const string _mapServerScheme = "http";

        /// <summary>
        /// The host name of the map server.
        /// </summary>
        private const string _mapServerHost = "www.openstreetmap.org";

        /// <summary>
        /// The separator character for query strings.
        /// </summary>
        private const string _querySeparator = "&";

        /// <summary>
        /// The query string for the bounding box.
        /// </summary>
        private string? _bounds;

        /// <summary>
        /// An encoded comma for query strings.
        /// </summary>
        private const string _commaCode = "%2C";

        /// <summary>
        /// The 'bbox' query string.
        /// </summary>
        private const string _bbox = "bbox=";

        /// <summary>
        /// The prefix of a URL path displaying a single node.
        /// </summary>
        private const string _nodePrefix = "/node/";

        /// <summary>
        /// The text to show the units for the distance.
        /// </summary>
        private const string _distanceUnit = " miles";

        /// <summary>
        /// Delegate for making a safe cross-thread update to a button's Enabled property.
        /// </summary>
        /// <param name="c">The control to enable/disable.</param>
        /// <param name="enabled">Whether the button should be enabled.</param>
        private delegate void SafeUpdateEnabled(Control c, bool enabled);

        /// <summary>
        /// Constructs the GUI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the entire map.
        /// </summary>
        private void ShowEntireMap()
        {
            UriBuilder url = new(_mapServerScheme, _mapServerHost);
            url.Query = _bounds;
            uxMap.Load(url.Uri.ToString());
        }

        /// <summary>
        /// Sets the map bounds to the given box.
        /// </summary>
        /// <param name="box">The coordinates of the lower left corner and upper right corner
        /// of the map.</param>
        private void SetMapBounds(string[] box)
        {
            _bounds = _bbox + box[0] + _commaCode + box[1] + _commaCode + box[2] + _commaCode + box[3];
        }

        /// <summary>
        /// Reads the map data from the file with the given name.
        /// </summary>
        /// <param name="fileName">The name of the file to read.</param>
        /// <returns>A graph containing the map data.</returns>
        private DirectedGraph<string, decimal> ReadMap(string fileName)
        {
            DirectedGraph<string, decimal> map = new();
            using (StreamReader input = File.OpenText(fileName))
            {
                string? line = input.ReadLine();
                if (line == null)
                {
                    throw new IOException("The input file is empty.");
                }
                SetMapBounds(line.Split(','));
                while (!input.EndOfStream)
                {
                    line = input.ReadLine();
                    // Because input is not at end of stream, ReadLine shouldn't return null.
                    string[] fields = line!.Split(',');
                    map.AddEdge(fields[0], fields[1], Convert.ToDecimal(fields[2]));
                }
            }
            return map;
        }

        /// <summary>
        /// Handles a Click event on the "Load a map" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void LoadClick(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _map = ReadMap(uxOpenDialog.FileName);
                    ShowEntireMap();
                    uxEntireMap.Enabled = true;
                    uxFindPath.Enabled = false;
                    uxStartNode.Text = "";
                    uxEndNode.Text = "";
                    uxDistance.Text = "";
                    uxNodeList.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Show entire map" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void EntireMapClick(object sender, EventArgs e)
        {
            ShowEntireMap();
        }

        /// <summary>
        /// Gets the node currently being browsed.
        /// </summary>
        /// <returns>The node currently being browsed.</returns>
        private string GetNodeFromMap()
        {
            uxDistance.Text = "";
            uxNodeList.Items.Clear();
            string path = new Uri(uxMap.Address).AbsolutePath;
            return path.Substring(_nodePrefix.Length);
        }

        /// <summary>
        /// Enables the "Find Shortest Path" button if values are present for both nodes.
        /// </summary>
        private void EnablePathFinding()
        {
            uxFindPath.Enabled = uxStartNode.Text != "" && uxEndNode.Text != "";
        }

        /// <summary>
        /// Handles a Click event on the button for setting the start node.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void SetStartClick(object sender, EventArgs e)
        {
            uxStartNode.Text = GetNodeFromMap();
            EnablePathFinding();
        }

        /// <summary>
        /// Handles a Click event on the button for setting the end node.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void SetEndClick(object sender, EventArgs e)
        {
            uxEndNode.Text = GetNodeFromMap();
            EnablePathFinding();
        }

        /// <summary>
        /// Handles a Text Changed event on the Starting Node TextBox.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void StartNodeTextChanged(object sender, EventArgs e)
        {
            EnablePathFinding();
        }

        /// <summary>
        /// Handles a Text Changed event on the Ending Node TextBox.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void EndNodeTextChanged(object sender, EventArgs e)
        {
            EnablePathFinding();
        }

        /// <summary>
        /// Handles a Selected Index Changed event on the node list.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void NodeListSelectedIndexChanged(object sender, EventArgs e)
        {
            UriBuilder url = new(_mapServerScheme, _mapServerHost);
            url.Path = _nodePrefix + uxNodeList.SelectedItem;
            uxMap.Load(url.Uri.ToString());
        }

        /// <summary>
        /// Enables or disables the given control in a thread-safe way.
        /// </summary>
        /// <param name="c">The control to enable/disable.</param>
        /// <param name="enabled">Whether the the control should be enabled.</param>
        private void SetEnabled(Control c, bool enabled)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new SafeUpdateEnabled(SetEnabled), c, enabled);
            }
            else
            {
                c.Enabled = enabled;
            }
        }

        /// <summary>
        /// Handles an AddressChanged event on the map.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void MapAddressChanged(object sender, CefSharp.AddressChangedEventArgs e)
        {
            Uri url = new(uxMap.Address);
            if (url.Host == _mapServerHost)
            {
                bool viewingNode = url.AbsolutePath.StartsWith(_nodePrefix) &&
                    _map.ContainsNode(url.AbsolutePath.Substring(_nodePrefix.Length));
                SetEnabled(uxSetStart, viewingNode);
                SetEnabled(uxSetEnd, viewingNode);
            }
            else
            {
                SetEnabled(uxSetStart, false);
                SetEnabled(uxSetEnd, false);
                SetEnabled(uxFindPath, false);
            }
        }

        /// <summary>
        /// Displays an error message indicating that the given node is not on the map.
        /// </summary>
        /// <param name="node">The node.</param>
        private void ShowError(string node)
        {
            MessageBox.Show("Node " + node + " not in map.");
        }

        /// <summary>
        /// to compute the shortest path from u to v in map
        /// </summary>
        /// <param name="u">starting</param>
        /// <param name="v">ending</param>
        /// <param name="map">map </param>
        /// <param name="paths">paths</param>
        /// <returns>decimal computed</returns>
        private decimal ShortestPath(string u, string v, DirectedGraph<string, decimal> map, out Dictionary<string, string> paths)
        {
            paths = new Dictionary<string, string>();
            MinPriorityQueue<decimal, Edge<string, decimal>> queue = new();

            paths[u] = u;
            if (u == v)
            {
                return 0;
            }

            foreach (Edge<string, decimal> edge in map.OutgoingEdges(u))
            {
                queue.Add(edge.Data, edge);
            }
                
            while (queue.Count > 0)
            {
                decimal p = queue.MinPriority;
                Edge<string, decimal> edge = queue.RemoveMinPriorityElement();

                if (!paths.ContainsKey(edge.Destination))
                {
                    paths[edge.Destination] = edge.Source;
                    if (edge.Destination == v)
                    {
                        return p;
                    }

                    foreach (Edge<string, decimal> next in map.OutgoingEdges(edge.Destination))
                    {
                        queue.Add(p + next.Data, next);
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// to add the nodes in the path from u to v in paths to the end of the given list
        /// </summary>
        /// <param name="u">starting</param>
        /// <param name="v">ending</param>
        /// <param name="paths">paths</param>
        /// <param name="list">list</param>
        private void AddPath(string u, string v, Dictionary<string, string> paths, IList list)
        {
            Stack<string> stack = new Stack<string>();
            string current = v;

            while (current != u)
            {
                stack.Push(current);
                current = paths[current];
            }

            list.Add(u);
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }
        }

        /// <summary>
        /// event handler for the FindShortestPath button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        private void uxFindPath_Click(object sender, EventArgs e)
        {
            if (!_map.ContainsNode(uxStartNode.Text))
            {
                ShowError(uxStartNode.Text);
            }
            else if (!_map.ContainsNode(uxEndNode.Text))
            {
                ShowError(uxEndNode.Text);
            }
            else
            {
                Dictionary<string, string> paths;
                decimal len = Math.Round(ShortestPath(uxStartNode.Text, uxEndNode.Text, _map, out paths), 1);
                uxNodeList.Items.Clear();
                if (len < 0)
                {
                    uxDistance.Text = "";
                    MessageBox.Show("No path found.");
                }
                else
                {
                    uxDistance.Text = len + _distanceUnit;
                    uxNodeList.BeginUpdate();
                    AddPath(uxStartNode.Text, uxEndNode.Text, paths, uxNodeList.Items);
                    uxNodeList.EndUpdate();
                }
            }
        }
    }
}

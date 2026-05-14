using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// This is the bipartite graph we use to find a exact cover. Element lists
    /// go vertically through Next[0]/Previous[0] and subset lists go horizontally
    /// through Next[1]/Previous[1]. The header list itself is also treated like
    /// a subset-direction adjacency list which is a bit clever honestly.
    /// </summary>
    /// <typeparam name="TElement">The type we're using for element nodes.</typeparam>
    /// <typeparam name="TSubset">The type we're using for subset nodes.</typeparam>
    public class CoverGraph<TElement, TSubset>
    {
        /// <summary>
        /// Points to one of the headers in our circular header list. If there's
        /// no elements left in the graph this field doesn't really matter.
        /// </summary>
        private Header _headers;

        /// <summary>
        /// Keeps track of how many element nodes are still in the graph.
        /// </summary>
        private int _elementCount;

        /// <summary>
        /// Builds the cover graph from a list of elements, subsets, and which
        /// elements each subset is adjacent to. Throws if anything is null or
        /// if the subsets and adjacent lists don't match in size.
        /// </summary>
        /// <param name="elements">All the element nodes.</param>
        /// <param name="subsets">All the subset nodes.</param>
        /// <param name="adjacent">For each subset (same order as
        /// <paramref name="subsets"/>), the elements it's adjacent to.</param>
        public CoverGraph(IList<TElement> elements, IList<TSubset> subsets,
            IList<IList<TElement>> adjacent)
        {
            if (elements == null || subsets == null || adjacent == null)
            {
                throw new ArgumentNullException();
            }
            if (subsets.Count != adjacent.Count)
            {
                throw new ArgumentException();
            }

            Dictionary<TElement, Header> dict = InitializeElements(elements);
            InitializeSubsets(subsets, adjacent, dict);
        }

        /// <summary>
        /// Snips a cell out of a adjacency list but keeps it's next/previous
        /// pointers intact so we can put it back in the exact same spot later.
        /// </summary>
        /// <param name="cell">The cell we want to remove.</param>
        /// <param name="list">Which adjacency list to remove it from.</param>
        private void RemoveCell(GraphCell cell, AdjacencyList list)
        {
            int i = (int)list;
            cell.Previous[i].Next[i] = cell.Next[i];
            cell.Next[i].Previous[i] = cell.Previous[i];
        }

        /// <summary>
        /// Puts a cell back into the list using its own saved next/prev pointers.
        /// Basically the undo of RemoveCell, pretty straightforward.
        /// </summary>
        /// <param name="cell">The cell we want to restore.</param>
        /// <param name="list">Which adjacency list to restore it to.</param>
        private void RestoreCell(GraphCell cell, AdjacencyList list)
        {
            int i = (int)list;
            cell.Previous[i].Next[i] = cell;
            cell.Next[i].Previous[i] = cell;
        }

        /// <summary>
        /// Pulls a header out of the header list, decrements the element count,
        /// and updates _headers if we just removed the one it was pointing at.
        /// </summary>
        /// <param name="header">The header to remove.</param>
        private void RemoveHeader(Header header)
        {
            RemoveCell(header, AdjacencyList.Subset);
            _elementCount--;
            if (_headers == header)
            {
                _headers = (Header)header.Next[(int)AdjacencyList.Subset];
            }
        }

        /// <summary>
        /// Puts the header back in the list and bumps the element count back up.
        /// We don't touch _headers here since any header in the list works fine.
        /// </summary>
        /// <param name="header">The header to restore.</param>
        private void RestoreHeader(Header header)
        {
            RestoreCell(header, AdjacencyList.Subset);
            _elementCount++;
        }

        /// <summary>
        /// Sets up a header for every element, link them all into a circular
        /// doubly-linked list, and returns a dictionary so we can look up
        /// headers by element later.
        /// </summary>
        /// <param name="elements">All the element nodes.</param>
        /// <returns>A dictionary mapping each element to its header.</returns>
        private Dictionary<TElement, Header> InitializeElements(
            IList<TElement> elements)
        {
            Dictionary<TElement, Header> dict =
                new Dictionary<TElement, Header>();

            /// Using a dummy header to make building the circular list easier,
            /// we'll yank it out at the end once everything is hooked up.
            Header dummy = new Header();
            dummy.Next[(int)AdjacencyList.Subset] = dummy;
            dummy.Previous[(int)AdjacencyList.Subset] = dummy;

            foreach (TElement elem in elements)
            {
                Header h = new Header();

                /// Start the element-adjacency list for this header as just
                /// itself pointing to itself, empty circular list.
                h.Next[(int)AdjacencyList.Element] = h;
                h.Previous[(int)AdjacencyList.Element] = h;

                /// Hook h in right before the dummy in the subset list.
                h.Previous[(int)AdjacencyList.Subset] =
                    dummy.Previous[(int)AdjacencyList.Subset];
                h.Next[(int)AdjacencyList.Subset] = dummy;
                RestoreCell(h, AdjacencyList.Subset);

                dict[elem] = h;
            }

            _elementCount = elements.Count;
            _headers = (Header)dummy.Next[(int)AdjacencyList.Subset];

            /// Pull the dummy out now that we're done building the list.
            RemoveCell(dummy, AdjacencyList.Subset);

            return dict;
        }

        /// <summary>
        /// Wires up all the edges between subsets and elements. Each edge gets
        /// inserted into both the element's vertical list and the subset's
        /// horizontal list.
        /// </summary>
        /// <param name="subsets">All the subset nodes.</param>
        /// <param name="adjacent">For each subset, which elements its adjacent to.</param>
        /// <param name="dict">Maps elements to their headers.</param>
        private void InitializeSubsets(IList<TSubset> subsets,
            IList<IList<TElement>> adjacent,
            Dictionary<TElement, Header> dict)
        {
            for (int i = 0; i < subsets.Count; i++)
            {
                TSubset subset = subsets[i];
                IList<TElement> elements = adjacent[i];

                if (elements.Count == 0)
                {
                    continue;
                }

                Edge<TSubset> first = null;

                foreach (TElement elem in elements)
                {
                    Header header = dict[elem];
                    Edge<TSubset> edge = new Edge<TSubset>(header, subset);

                    /// Stick the edge at the end of the header's element list,
                    /// right before the header in the circular list.
                    edge.Previous[(int)AdjacencyList.Element] =
                        header.Previous[(int)AdjacencyList.Element];
                    edge.Next[(int)AdjacencyList.Element] = header;
                    RestoreCell(edge, AdjacencyList.Element);

                    header.EdgeCount++;

                    if (first == null)
                    {
                        /// First edge for this subset so it just points to itself.
                        edge.Next[(int)AdjacencyList.Subset] = edge;
                        edge.Previous[(int)AdjacencyList.Subset] = edge;
                        first = edge;
                    }
                    else
                    {
                        /// Otherwise insert it just before first in the subset list.
                        edge.Previous[(int)AdjacencyList.Subset] =
                            first.Previous[(int)AdjacencyList.Subset];
                        edge.Next[(int)AdjacencyList.Subset] = first;
                        RestoreCell(edge, AdjacencyList.Subset);
                    }
                }
            }
        }

        /// <summary>
        /// Goes through every other edge on the given edge's subset list and
        /// pulls them out of their element lists. We skip the given edge itself
        /// since that element is getting covered anyway. EdgeCounts get
        /// decremented as we go.
        /// </summary>
        /// <param name="given">An edge on the subset list to process.</param>
        private void RemoveSubset(Edge<TSubset> given)
        {
            GraphCell current = given.Next[(int)AdjacencyList.Subset];
            while (current != given)
            {
                Edge<TSubset> edge = (Edge<TSubset>)current;
                RemoveCell(edge, AdjacencyList.Element);
                edge.ElementHeader.EdgeCount--;
                current = current.Next[(int)AdjacencyList.Subset];
            }
        }

        /// <summary>
        /// Puts all those edges back into their element lists but in reverse
        /// order so everything undoes cleanly. This is the undo of RemoveSubset.
        /// </summary>
        /// <param name="given">The edge that was passed to RemoveSubset.</param>
        private void RestoreSubset(Edge<TSubset> given)
        {
            GraphCell current = given.Previous[(int)AdjacencyList.Subset];
            while (current != given)
            {
                Edge<TSubset> edge = (Edge<TSubset>)current;
                RestoreCell(edge, AdjacencyList.Element);
                edge.ElementHeader.EdgeCount++;
                current = current.Previous[(int)AdjacencyList.Subset];
            }
        }

        /// <summary>
        /// Covers a element node by yanking it's header out of the list and
        /// then calling RemoveSubset on every subset that was adjacent to it.
        /// </summary>
        /// <param name="header">The header of the element we want to cover.</param>
        private void CoverElement(Header header)
        {
            RemoveHeader(header);
            GraphCell current = header.Next[(int)AdjacencyList.Element];
            while (current != header)
            {
                RemoveSubset((Edge<TSubset>)current);
                current = current.Next[(int)AdjacencyList.Element];
            }
        }

        /// <summary>
        /// Undoes a prior CoverElement by restoring all the affected subsets
        /// in reverse order, then putting the header back. Order really matters
        /// here or everything breaks.
        /// </summary>
        /// <param name="header">The header of the element to uncover.</param>
        private void UncoverElement(Header header)
        {
            GraphCell current = header.Previous[(int)AdjacencyList.Element];
            while (current != header)
            {
                RestoreSubset((Edge<TSubset>)current);
                current = current.Previous[(int)AdjacencyList.Element];
            }
            RestoreHeader(header);
        }

        /// <summary>
        /// Picks a subset for our cover and covers every element it touches.
        /// All the edges except the given one are handled in the loop, then
        /// we cover the given edge's element last.
        /// </summary>
        /// <param name="given">An edge on the subset's adjacency list.</param>
        private void SelectSubset(Edge<TSubset> given)
        {
            GraphCell current = given.Next[(int)AdjacencyList.Subset];
            while (current != given)
            {
                Edge<TSubset> edge = (Edge<TSubset>)current;
                /// Advance current before covering so our pointer stays valid.
                current = current.Next[(int)AdjacencyList.Subset];
                CoverElement(edge.ElementHeader);
            }
            CoverElement(given.ElementHeader);
        }

        /// <summary>
        /// Reverses SelectSubset. We uncover the given edge's element first since
        /// it was covered last, then work backwards through the rest of the list.
        /// </summary>
        /// <param name="given">The edge that was passed to SelectSubset.</param>
        private void DeselectSubset(Edge<TSubset> given)
        {
            UncoverElement(given.ElementHeader);
            GraphCell current = given.Previous[(int)AdjacencyList.Subset];
            while (current != given)
            {
                Edge<TSubset> edge = (Edge<TSubset>)current;
                current = current.Previous[(int)AdjacencyList.Subset];
                UncoverElement(edge.ElementHeader);
            }
        }

        /// <summary>
        /// Recursively tries to find a exact cover using Knuth's Algorithm X.
        /// If we find one it stays on the stack and we return true. If not
        /// the graph gets restored to how it was before this call.
        /// </summary>
        /// <param name="stack">Where we collect the subsets that form the cover.</param>
        /// <returns>True if we found a exact cover, false otherwise.</returns>
        private bool FindCover(Stack<TSubset> stack)
        {
            if (_elementCount == 0)
            {
                return true;
            }

            /// Pick the element with the least edges to keep the branching low.
            Header best = _headers;
            GraphCell c = _headers.Next[(int)AdjacencyList.Subset];
            while (c != _headers)
            {
                Header h = (Header)c;
                if (h.EdgeCount < best.EdgeCount)
                {
                    best = h;
                }
                c = c.Next[(int)AdjacencyList.Subset];
            }

            /// Try every subset that covers this element and recurse.
            GraphCell edgeCell = best.Next[(int)AdjacencyList.Element];
            while (edgeCell != best)
            {
                Edge<TSubset> edge = (Edge<TSubset>)edgeCell;
                stack.Push(edge.Subset);
                SelectSubset(edge);
                if (FindCover(stack))
                {
                    return true;
                }
                DeselectSubset(edge);
                stack.Pop();
                edgeCell = edgeCell.Next[(int)AdjacencyList.Element];
            }

            return false;
        }

        /// <summary>
        /// Kicks off the search for a exact cover. If one is found it comes back
        /// through the out parameter, otherwise the graph stays unchanged.
        /// </summary>
        /// <param name="cover">Gets the exact cover if we found one.</param>
        /// <returns>True if a cover was found, false if there isn't one.</returns>
        public bool RemoveCover(out IEnumerable<TSubset> cover)
        {
            Stack<TSubset> stack = new Stack<TSubset>();
            bool found = FindCover(stack);
            cover = stack;
            return found;
        }
    }
}
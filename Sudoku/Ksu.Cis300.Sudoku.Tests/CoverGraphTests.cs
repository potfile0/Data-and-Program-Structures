/* CoverGraphTests.cs
 * Author: Rod Howell
 */
using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Ksu.Cis300.Sudoku.Tests
{
    /// <summary>
    /// Unit tests for the CoverGraph class.
    /// </summary>
    [TestFixture]
    public class CoverGraphTests
    {
        /// <summary>
        /// Copies the elements of the given enumerable to a List.
        /// </summary>
        /// <typeparam name="T">The type of the elements to copy.</typeparam>
        /// <param name="e">The enumerable collection of elements.</param>
        /// <returns>A list of the elements of the enumerable.</returns>
        private static List<T> ToList<T>(IEnumerable<T> e)
        {
            List<T> result = new List<T>();
            foreach (T x in e)
            {
                result.Add(x);
            }
            return result;
        }

        /// <summary>
        /// Tests finding an exact cover on a graph that has, for each pair of element nodes,
        /// a subset node adjacent to both of them. The element nodes are the n-digit integers
        /// comprised of one 1 and n-1 (possibly leading) 0s. The subset nodes are the n-digit
        /// integers comprised of two 1s and n-2 (possibly leading) 0. A subset is adjacent to
        /// each element with which it shares a digit position containing a 1. For example, if
        /// n=4, the elements are 1, 10, 100, and 1000, the subsets are 11, 101, 110, 1001, 1010, 
        /// and 1100, and the edges are {1, 11}, {1, 101}, {1, 1001}, {10, 11}, {10, 110}, {10, 1010},
        /// {100, 101}, {100, 110}, {100, 1100}, {1000, 1001}, {1000, 1010}, and {1000, 1100}.
        /// If n is even, an exact cover should be found without backtracking. It will consist of
        /// n/2 nodes whose sum is the n-digit number comprised entirely of 1s. If n is odd, no
        /// exact cover will exist.
        /// </summary>
        /// <param name="n">The number of element nodes, a nonnegative value less than 10.</param>
        private static void TestAllPairsGraph(int n)
        {
            int[] elements = new int[n];
            List<int> subsets = new List<int>();
            List<IList<int>> edges = new List<IList<int>>();
            int d = 1;
            for (int i = 0; i < n; i++)
            {
                elements[i] = d;
                for (int j = 0; j < i; j++)
                {
                    subsets.Add(elements[i] + elements[j]);
                    edges.Add(new int[] { elements[i], elements[j] });
                }
                d *= 10;
            }
            CoverGraph<int, int> g = new CoverGraph<int, int>(elements, subsets, edges);
            bool found = g.RemoveCover(out IEnumerable<int> sol);
            int sum = 0;
            int count = 0;
            foreach (int k in sol)
            {
                sum += k;
                count++;
            }
            if (n % 2 == 0)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(found, Is.True);
                    Assert.That(count * 2, Is.EqualTo(n), "The solution has the wrong size.");
                    Assert.That(sum, Is.EqualTo(d / 9), "The solution isn't an exact cover.");
                });
            }
            else
            {
                Assert.Multiple(() =>
                {
                    Assert.That(found, Is.False);
                    Assert.That(count, Is.EqualTo(0), "The solution should be empty.");
                });
            }
        }

        /// <summary>
        /// Tests error checking in the constructor.
        /// </summary>
        [Test, CancelAfter(1000)]
        [Category("A: Error Check")]
        public void ErrorCheck()
        {
            Assert.Multiple(() =>
            {
                Assert.Catch(typeof(ArgumentNullException), 
                    () => new CoverGraph<int, int>(null, new List<int>(), new List<IList<int>>()));
                Assert.Catch(typeof(ArgumentNullException), 
                    () => new CoverGraph<int, string>(new List<int>(), null, new List<IList<int>>()));
                Assert.Catch(typeof(ArgumentNullException), 
                    () => new CoverGraph<string, string>(new List<string>(), new List<string>(), null));
                Assert.Catch(typeof(ArgumentException), 
                    () => new CoverGraph<string, int>(new List<string>(), new int[] { 1 }, new List<IList<string>>()));
                Assert.DoesNotThrow(() => new CoverGraph<int, string>(new List<int>(), new List<string>(), 
                    new List<IList<int>>())); // no nodes or edges
            });
        }

        /// <summary>
        /// Tests that an exact cover is found for an empty graph.
        /// </summary>
        [Test, CancelAfter(1000)]
        [Category("B: Empty Graph")]
        public void CoverForEmpty()
        {
            CoverGraph<int, string> g = new CoverGraph<int, string>(new List<int>(), new List<string>(),
                new List<IList<int>>());
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<string> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list, Is.Empty);
            });
        }

        /// <summary>
        /// Tests a graph with a single element node but no subset nodes or edges.
        /// It does not have an exact cover, but because there are no edges, no backtracking is done.
        /// </summary>
        [Test, CancelAfter(1000)]
        [Category("C: No Edges")]
        public void NoCoverNoEdges()
        {
            CoverGraph<string, int> g = new CoverGraph<string, int>(new string[] { "A" }, new List<int>(),
                new List<IList<string>>());
            bool found = g.RemoveCover(out IEnumerable<int> sol);
            List<int> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.False);
                Assert.That(list, Is.Empty);
            });
        }

        /// <summary>
        /// Finds a cover for a graph with one element node, one subset node, and an edge connecting them.
        /// No backtracking is needed.
        /// </summary>
        [Test, CancelAfter(1000), Category("D: Single-Edge Subsets")]
        public void CoverOneEdge()
        {
            CoverGraph<int, string> g = new CoverGraph<int, string>(new int[] { 1 }, new string[] { "A" },
                new int[][] { new int[] { 1 } });
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<string> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list.Count, Is.EqualTo(1)); // The cover has one element.
                Assert.That(list[0], Is.EqualTo("A"));  // The cover.
            });
        }

        /// <summary>
        /// Finds a cover in a graph with element nodes 1 and 2, subset nodes A and B, and edges
        /// {1, A} and {2, B}. No backtracking is needed.
        /// </summary>
        [Test, CancelAfter(1000), Category("D: Single-Edge Subsets")]
        public void CoverTwoEdges()
        {
            CoverGraph<int, string> g = new CoverGraph<int, string>(new int[] { 1, 2 },
                new string[] { "A", "B" }, new int[][] { new int[] { 1 }, new int[] { 2 } });
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<string> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list, Is.EquivalentTo(new string[] { "A", "B" }));
            });
        }

        /// <summary>
        /// Finds a cover in a graph with element nodes 1 and 2, subset nodes A, B, C, and D, and 
        /// edges {1, A}, {1, B}, {2, C}, and {2, D}. No backtracking is needed.
        /// </summary>
        [Test, CancelAfter(1000), Category("D: Single-Edge Subsets")]
        public void CoverTwoElementsFourEdges()
        {
            int[] elements = new int[] { 1, 2 };
            string[] subsets = new string[] { "A", "B", "C", "D" };
            int[][] edges = new int[][] { new int[] { 1 }, new int[] { 1 }, new int[] { 2 }, new int[] { 2 } };
            CoverGraph<int, string> g = new CoverGraph<int, string>(elements, subsets, edges);
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<string> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list.Count, Is.EqualTo(2)); // 2 subsets in the cover
                Assert.That(new string[] { "A", "B" }, Is.Not.SubsetOf(list)); // Can't contain both A and B
                Assert.That(new string[] { "C", "D" }, Is.Not.SubsetOf(list)); // Can't contain both C and D
                Assert.That(list[0], Is.Not.EqualTo(list[1])); // Distinct subsets
            });
        }

        /// <summary>
        /// Finds a cover in a graph with an even number of element nodes and for each pair of elements, a
        /// subset node adjacent to both elements in the pair. A cover should be found without backtracking.
        /// Tests are done for 4 elements and 8 elements.
        /// </summary>
        /// <param name="n">The number of element nodes.</param>
        [Test, CancelAfter(1000), Category("E: All Pairs Even")]
        [TestCase(4)]
        [TestCase(8)]
        public void CoverAllPairsEven(int n)
        {
            TestAllPairsGraph(n);
        }

        /// <summary>
        /// Checks that element nodes are being considered in the correct order. The graph has 5 element nodes
        /// and 15 subset nodes. Each subset is adjacent to one element. One element is adjacent to one subset,
        /// one element is adjacent to two subsets, etc. The exact cover algorithm should first cover the element
        /// adjacent to one subset, then the node adjacent to two, etc. No backtracking is needed.
        /// </summary>
        [Test, CancelAfter(1000), Category("F: Edge Counts")]
        public void SingleEdgesOrder()
        {
            int[] elements = new int[] { 4, 2, 1, 3, 5 };
            string[] subsets = new string[] { "4A", "4B", "4C", "4D", "2A", "2B", "1A", "3A", "3B", "3C", "5A", "5B", "5C", "5D", "5F" };
            int[][] edges =
            {
                new int[] { 4 }, new int[] { 4 }, new int[] { 4 }, new int[] { 4 },
                new int[] { 2 }, new int[] { 2 },
                new int[] { 1 },
                new int[] { 3 }, new int[] { 3 }, new int[] { 3 },
                new int[] { 5 }, new int[] { 5 }, new int[] { 5 }, new int[] { 5 }, new int[] { 5 }
            };
            CoverGraph<int, string> g = new CoverGraph<int, string>(elements, subsets, edges);
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<char> list = new List<char>();
            foreach (string s in sol)
            {
                list.Add(s[0]);
            }
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list, Is.EqualTo(new char[] { '5', '4', '3', '2', '1' }));
            });
        }

        /// <summary>
        /// Checks that edge counts are being updated as subsets are removed. The graph has four element
        /// nodes. Node 1 has 1 outgoing edge, node 2 has 3, node 3 has 3, and node 4 has 4. Node 1 is therefore
        /// the first node covered. Its adjacent subset is also adjacent to node 2, so it is also covered. Node
        /// 2 is adjacent to two other subsets, which are each also adjacent to node 4; hence their removal 
        /// should reduce its edge count to 2, making it the next node selected. Its adjacent nodes have no other
        /// outgoing edges, so node 3 remains. One of its adjacent nodes is then selected to complete the exact
        /// cover. No backtracking is needed.
        /// </summary>
        [Test, CancelAfter(1000), Category("F: Edge Counts")]
        public void UpdateEdgeCounts()
        {
            int[] nodes = new int[] { 1, 2, 3, 4 };
            string[] subsets = new string[] { "1", "2A", "2B", "3A", "3B", "3C", "4A", "4B" };
            int[][] edges = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 4 },
                new int[] { 2, 4 },
                new int[] { 3 },
                new int[] { 3 },
                new int[] { 3 },
                new int[] { 4 },
                new int[] { 4 }
            };
            CoverGraph<int, string> g = new CoverGraph<int, string>(nodes, subsets, edges);
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<char> list = new List<char>();
            foreach (string s in sol)
            {
                list.Add(s[0]);
            }
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list, Is.EqualTo(new char[] { '3', '4', '1' })); // checks the order of the subsets selected.
            });
        }

        /// <summary>
        /// Tests finding a cover when backtracking is required. The only exact cover for the graph is node "B", 
        /// which is adjacent to all four element nodes. The element node with fewest outgoing edges is node 1; subset
        /// "B" is the second subset of three adjacent to this element. Hence, whichever direction the adjacency list
        /// for node 1 is traversed, an incorrect subset will be tried first.
        /// </summary>
        [Test, CancelAfter(1000), Category("G: Backtracking")]
        public void BasicBacktracking()
        {
            int[] elements = new int[] { 1, 2, 3, 4 };
            string[] subsets = new string[] { "A", "B", "C", "D", "E", "F" };
            int[][] edges = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 3 },
                new int[] { 2, 3, 4 },
                new int[] { 2, 3, 4 },
                new int[] { 2, 3, 4 }
            };
            CoverGraph<int, string> g = new CoverGraph<int, string>(elements, subsets, edges);
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<string> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list, Is.EqualTo(new string[] { "B" }));
            });
        }

        /// <summary>
        /// The only exact cover for this graph is C, G, and J. The element node with fewest outgoing edges is 1.
        /// Because C is the third of 5 outgoing edges, two others will be tried first.
        /// </summary>
        [Test, CancelAfter(1000), Category("G: Backtracking")]
        public void DeepBacktracking()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            string[] subsets = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O" };
            int[][] edges = new int[][]
            {
                new int[] { 1, 5 },
                new int[] { 1, 4 },
                new int[] { 1, 2, 3 },
                new int[] { 1, 6 },
                new int[] { 1, 7 },
                new int[] { 2, 3, 4, 5 },
                new int[] { 6, 7 },
                new int[] { 2, 3 },
                new int[] { 2, 5, 6, 7 },
                new int[] { 4, 5 },
                new int[] { 3, 4, 6, 7 },
                new int[] { 2, 4 },
                new int[] { 3, 5, 6, 7 },
                new int[] { 3, 5 },
                new int[] { 2, 4, 6, 7 }
            };
            CoverGraph<int, string> g = new CoverGraph<int, string>(elements, subsets, edges);
            bool found = g.RemoveCover(out IEnumerable<string> sol);
            List<string> list = ToList(sol);
            Assert.Multiple(() =>
            {
                Assert.That(found, Is.True);
                Assert.That(list, Is.EquivalentTo(new string[] { "C", "G", "J" }));
            });
        }

        /// <summary>
        /// Tries to find a cover a cover in a graph with an odd number of element nodes and for each pair 
        /// of elements, a subset node adjacent to both elements in the pair. Because the number of element
        /// nodes is odd and all subset nodes are adjacent to 2 element nodes, there is no exact cover. Tests
        /// are done with 3 and 9 element nodes.
        /// </summary>
        /// <param name="n">The number of element nodes.</param>
        [Test, CancelAfter(1000), Category("G: Backtracking")]
        [TestCase(3)]
        [TestCase(9)]
        public void NoCoverAllPairsOdd(int n)
        {
            TestAllPairsGraph(n);
        }
    }
}

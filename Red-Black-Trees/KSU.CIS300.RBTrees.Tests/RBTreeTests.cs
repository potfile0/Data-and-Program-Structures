using System;
using NUnit.Framework;
using KSU.CIS300.RBTrees;

namespace KSU.CIS300.RBTrees.Tests
{
    /// <summary>
    /// Tests for the red/black tree
    /// </summary>
    [TestFixture]
    public class RBTreeTests
    {
        /// <summary>
        /// Test to verify that a simple insert works
        /// </summary>
        [Test]
        [Category("A: Simple Insert")]
        public void TestSimpleInsert()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test to verify that a simple insert works, right child
        /// </summary>
        [Test]
        [Category("A: Simple Insert")]
        public void TestSimpleInsertRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(6);
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            Assert.That(tree.Root.RightChild.Data, Is.EqualTo(6));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test to verify that a simple insert works, left child
        /// </summary>
        [Test]
        [Category("A: Simple Insert")]
        public void TestSimpleInsertLeft()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            Assert.That(tree.Root.LeftChild.Data, Is.EqualTo(4));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test to verify that a simple insert works, left then right children
        /// </summary>
        [Test]
        [Category("A: Simple Insert")]
        public void TestSimpleInsertLeftRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            Assert.That(tree.Root.LeftChild.Data, Is.EqualTo(4));
            Assert.That(tree.Root.RightChild.Data, Is.EqualTo(6));
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            VerifyTree(tree);
        }

        /// <summary>
        /// Try to insert duplicate
        /// </summary>
        [Test]
        [Category("A: Simple Insert")]
        public void TestSimpleInsertLeftRightDuplicate()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            Assert.That(() => tree.Insert(6), Throws.InvalidOperationException);
        }

        /// <summary>
        /// Insert duplicate root
        /// </summary>
        [Test]
        [Category("A: Simple Insert")]
        public void TestSimpleInsertDuplicate()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            Assert.That(() => tree.Insert(5), Throws.InvalidOperationException);
        }

        /// <summary>
        /// Test left rotation
        /// </summary>
        [Test]
        [Category("B: Single Rotation")]
        public void TestRotateLeft()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            Assert.That(tree.Root.LeftChild.Data, Is.EqualTo(5));
            Assert.That(tree.Root.RightChild.Data, Is.EqualTo(7));
            Assert.That(tree.Root.Data, Is.EqualTo(6));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test right rotation
        /// </summary>
        [Test]
        [Category("B: Single Rotation")]
        public void TestRotateRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(3);
            Assert.That(tree.Root.LeftChild.Data, Is.EqualTo(3));
            Assert.That(tree.Root.RightChild.Data, Is.EqualTo(5));
            Assert.That(tree.Root.Data, Is.EqualTo(4));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test that nodes are recolered basic
        /// </summary>
        [Test]
        [Category("C: Fix Insert: Recolor")]
        public void TestRecolor()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            Assert.That(tree.Root.LeftChild.Data, Is.EqualTo(4));
            Assert.That(tree.Root.RightChild.Data, Is.EqualTo(6));
            Assert.That(tree.Root.RightChild.RightChild.Data, Is.EqualTo(8));
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test that nodes are recolored, case 2-3
        /// </summary>
        [Test]
        [Category("C: Fix Insert: Recolor")]
        public void TestRecolorRightLeftRotate()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(7); //else case 2-3 
            Assert.That(tree.Root.Data, Is.EqualTo(5));
            Assert.That(tree.Root.LeftChild.Data, Is.EqualTo(4));
            Assert.That(tree.Root.RightChild.Data, Is.EqualTo(7));
            Assert.That(tree.Root.RightChild.RightChild.Data, Is.EqualTo(8));
            Assert.That(tree.Root.RightChild.LeftChild.Data, Is.EqualTo(6));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test recolor then right rotation
        /// </summary>
        [Test]
        [Category("C: Fix Insert: Recolor")]
        public void TestRecolorRotateRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(3);
            tree.Insert(2);
            VerifyTree(tree);
        }

        /// <summary>
        /// Test rotate right then recolor
        /// </summary>
        [Test]
        [Category("C: Fix Insert: Recolor")]
        public void TestRotateRightRecolor()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);
            VerifyTree(tree);
        }

        /// <summary>
        /// Test the fix insert after recolor
        /// </summary>
        [Test]
        [Category("C: Fix Insert: Recolor")]
        public void TestRotateRightLeft()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);
            VerifyTree(tree);
        }

        /// <summary>
        /// Test finding the root in the RBTree.
        /// </summary>
        [Test]
        [Category("D: Find")]
        public void TestFindRoot()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            int result;
            if (!tree.Find(5, out result) || result != 5)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Test finding a missing value in the RBTree.
        /// </summary>
        [Test]
        [Category("D: Find")]
        public void TestFindMissing()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            int result;
            if (tree.Find(1, out result) || result != 0)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Test finding a value less than the root in the RBTree.
        /// </summary>
        [Test]
        [Category("D: Find")]
        public void TestFindLessThan()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(3);
            tree.Insert(2);
            int result;
            if (!tree.Find(3, out result) || result != 3)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Test finding a value greater than the root in the RBTree.
        /// </summary>
        [Test]
        [Category("D: Find")]
        public void TestFindGreaterThan()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(1);
            int result;
            if (!tree.Find(4, out result) || result != 4)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Test finding the minimum value in the left subtree of the RBTree.
        /// </summary>
        [Test]
        [Category("E: Find Min")]
        public void TestFindMin()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(1);
            Assert.That(tree.FindMin(tree.Root.LeftChild).Data, Is.EqualTo(1));
        }

        /// <summary>
        /// Test finding the minimum value in the right subtree of the RBTree.
        /// </summary>
        [Test]
        [Category("E: Find Min")]
        public void TestFindMinRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(1);
            Assert.That(tree.FindMin(tree.Root.RightChild).Data, Is.EqualTo(6));
        }

        /// <summary>
        /// Test simple removal of the right child in the RBTree.
        /// </summary>
        [Test]
        [Category("F: Simple Remove")]
        public void TestSimpleRemoveRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Remove(6);
            int result = 0;
            if (tree.Find(6, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test simple removal of the left child in the RBTree.
        /// </summary>
        [Test]
        [Category("F: Simple Remove")]
        public void TestSimpleRemoveLeft()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Remove(4);
            int result = 0;
            if (tree.Find(4, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removing a non-existent value from a populated tree
        /// </summary>
        [Test]
        [Category("F: Simple Remove")]
        public void TestRemoveNonExistent()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            Assert.That(() => tree.Remove(10), Is.False);
        }

        /// <summary>
        /// Test removing a value that was already removed
        /// </summary>
        [Test]
        [Category("F: Simple Remove")]
        public void TestRemoveAlreadyRemoved()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Remove(3);
            Assert.That(() => tree.Remove(3), Is.False);
        }

        /// <summary>
        /// Test removal of a parent node with a right child in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G1: Remove Parent")]
        public void TestRemoveParentRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(7);
            tree.Remove(6);
            int result = 0;
            if (tree.Find(6, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a parent node with a left child in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G1: Remove Parent")]
        public void TestRemoveParentLeft()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(6);
            tree.Remove(7);
            int result = 0;
            if (tree.Find(7, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a parent node with one child in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G1: Remove Parent")]
        public void TestRemoveParentWithOneChild()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(6);
            tree.Insert(7);
            tree.Remove(7);
            int result = 0;
            if (tree.Find(7, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a parent node with two children in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G1: Remove Parent")]
        public void TestRemoveParentWithTwoChildren()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(6);
            tree.Insert(9);
            tree.Remove(8);
            int result = 0;
            if (tree.Find(8, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a parent node in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G1: Remove Parent")]
        public void TestRemoveParent()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(6);
            tree.Insert(7);
            tree.Remove(8);
            int result = 0;
            if (tree.Find(8, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of one sibling in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveOneSibling()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(6);
            tree.Insert(9);
            tree.Remove(9);
            int result = 0;
            if (tree.Find(9, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a black sibling with a red nephew in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveBlackSiblingRedNephew()
        {
            //case 4
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);
            tree.Remove(8);
            int result = 0;
            if (tree.Find(8, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a black sibling with a red and black nephew in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveBlackSiblingRedBlackNephew()
        {
            //case 3, 4
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);
            tree.Remove(1);
            int result = 0;
            if (tree.Find(1, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a black sibling with a red nephew in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveBlackSiblingNephewRed()
        {
            //case 1
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);
            tree.Remove(2);
            int result = 0;
            if (tree.Find(2, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a black sibling with a red node in the RBTree.
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveBlackSiblingRed()
        {
            //case 1,2
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(10);
            tree.Insert(7);
            tree.Insert(13);
            tree.Insert(14);
            tree.Remove(3);
            int result = 0;
            if (tree.Find(3, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a black sibling with a red node in the RBTree (mirror case).
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveBlackSiblingRedMirror()
        {
            //case 1-2,2-2
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(2);
            tree.Insert(4);
            tree.Insert(1);
            tree.Remove(8);
            int result = 0;
            if (tree.Find(8, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of a black sibling with red and black nephews
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveBlackSiblingRedBlackNephewMirror()
        {
            //case 3-2, 4-2
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(12);
            tree.Insert(18);
            tree.Insert(9);
            tree.Insert(13);
            tree.Remove(18);
            int result = 0;
            if (tree.Find(18, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of red left sibling
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveRedLeftSibling()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);
            tree.Remove(5);
            int result = 0;
            if (tree.Find(5, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removal of right red sibling
        /// </summary>
        [Test]
        [Category("G: Fix Delete")]
        [Category("G2: Remove Sibling")]
        public void TestRemoveRedSiblingsRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(14);
            tree.Insert(1);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(13);
            tree.Remove(11);
            int result = 0;
            if (tree.Find(11, out result))
            {
                Assert.Fail();
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test finding in an empty tree
        /// </summary>
        [Test]
        [Category("H: Edge Cases")]
        public void TestFindEmptyTree()
        {
            RBTree<int> tree = new RBTree<int>();
            int result;
            Assert.That(tree.Find(5, out result), Is.False);
            Assert.That(result, Is.EqualTo(0));
        }

        /// <summary>
        /// Test removing root from a single-node tree
        /// </summary>
        [Test]
        [Category("H: Edge Cases")]
        public void TestRemoveRootSingleNode()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Remove(5);
            int result;
            Assert.That(tree.Find(5, out result), Is.False);
            Assert.That(tree.Root, Is.EqualTo(RBTree<int>.NIL));
        }

        /// <summary>
        /// Test removing root from a two-node tree (left child only)
        /// </summary>
        [Test]
        [Category("H: Edge Cases")]
        public void TestRemoveRootTwoNodeLeft()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Remove(5);
            Assert.That(tree.Root.Data, Is.EqualTo(3));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removing root from a two-node tree (right child only)
        /// </summary>
        [Test]
        [Category("H: Edge Cases")]
        public void TestRemoveRootTwoNodeRight()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(7);
            tree.Remove(5);
            Assert.That(tree.Root.Data, Is.EqualTo(7));
            VerifyTree(tree);
        }

        /// <summary>
        /// Test removing root from a three-node tree
        /// </summary>
        [Test]
        [Category("H: Edge Cases")]
        public void TestRemoveRootThreeNode()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Remove(5);
            int result;
            Assert.That(tree.Find(5, out result), Is.False);
            Assert.That(tree.Find(3, out result), Is.True);
            Assert.That(tree.Find(7, out result), Is.True);
            VerifyTree(tree);
        }

        /// <summary>
        /// Test inserting values in ascending order
        /// </summary>
        [Test]
        [Category("I: Sequential Patterns")]
        public void TestInsertAscending()
        {
            RBTree<int> tree = new RBTree<int>();
            for (int i = 1; i <= 10; i++)
            {
                tree.Insert(i);
            }
            for (int i = 1; i <= 10; i++)
            {
                int result;
                Assert.That(tree.Find(i, out result), Is.True);
                Assert.That(result, Is.EqualTo(i));
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test inserting values in descending order
        /// </summary>
        [Test]
        [Category("I: Sequential Patterns")]
        public void TestInsertDescending()
        {
            RBTree<int> tree = new RBTree<int>();
            for (int i = 10; i >= 1; i--)
            {
                tree.Insert(i);
            }
            for (int i = 1; i <= 10; i++)
            {
                int result;
                Assert.That(tree.Find(i, out result), Is.True);
                Assert.That(result, Is.EqualTo(i));
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test inserting values in an alternating pattern
        /// </summary>
        [Test]
        [Category("I: Sequential Patterns")]
        public void TestInsertAlternating()
        {
            RBTree<int> tree = new RBTree<int>();
            int[] values = { 5, 10, 0, 7, 3, 8, 2, 9, 1, 6 };
            foreach (int value in values)
            {
                tree.Insert(value);
            }
            foreach (int value in values)
            {
                int result;
                Assert.That(tree.Find(value, out result), Is.True);
                Assert.That(result, Is.EqualTo(value));
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test FindMin on the root node
        /// </summary>
        [Test]
        [Category("J: FindMin Edge Cases")]
        public void TestFindMinRoot()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            Assert.That(tree.FindMin(tree.Root).Data, Is.EqualTo(5));
        }

        /// <summary>
        /// Test FindMin after multiple deletions
        /// </summary>
        [Test]
        [Category("J: FindMin Edge Cases")]
        public void TestFindMinAfterDeletions()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(4);
            tree.Remove(1);
            Assert.That(tree.FindMin(tree.Root).Data, Is.EqualTo(3));
        }

        /// <summary>
        /// Test building a larger tree and verifying all elements
        /// </summary>
        [Test]
        [Category("L: Larger Trees")]
        public void TestLargeTreeInsert()
        {
            RBTree<int> tree = new RBTree<int>();
            int count = 50;
            for (int i = 0; i < count; i++)
            {
                tree.Insert(i);
            }
            for (int i = 0; i < count; i++)
            {
                int result;
                Assert.That(tree.Find(i, out result), Is.True);
                Assert.That(result, Is.EqualTo(i));
            }
            VerifyTree(tree);
        }

        /// <summary>
        /// Test deleting all nodes from a larger tree
        /// </summary>
        [Test]
        [Category("L: Larger Trees")]
        public void TestLargeTreeDeleteAll()
        {
            RBTree<int> tree = new RBTree<int>();
            int count = 20;
            for (int i = 0; i < count; i++)
            {
                tree.Insert(i);
            }
            for (int i = 0; i < count; i++)
            {
                tree.Remove(i);
                int result;
                Assert.That(tree.Find(i, out result), Is.False);
                if (tree.Root != RBTree<int>.NIL)
                {
                    VerifyTree(tree);
                }
            }
            Assert.That(tree.Root, Is.EqualTo(RBTree<int>.NIL));
        }

        /// <summary>
        /// Test deleting leaves first from a tree
        /// </summary>
        [Test]
        [Category("L: Larger Trees")]
        public void TestDeleteLeavesFirst()
        {
            RBTree<int> tree = new RBTree<int>();
            int[] values = { 10, 5, 15, 3, 7, 12, 17, 1, 4, 6, 8, 11, 13, 16, 18 };
            foreach (int value in values)
            {
                tree.Insert(value);
            }
            int[] leavesFirst = { 1, 4, 6, 8, 11, 13, 16, 18, 3, 7, 12, 17, 5, 15, 10 };
            foreach (int value in leavesFirst)
            {
                tree.Remove(value);
                int result;
                Assert.That(tree.Find(value, out result), Is.False);
                if (tree.Root != RBTree<int>.NIL)
                {
                    VerifyTree(tree);
                }
            }
        }

        /// <summary>
        /// Test mixed insert and delete operations
        /// </summary>
        [Test]
        [Category("L: Larger Trees")]
        public void TestMixedOperations()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Remove(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Remove(15);
            tree.Insert(20);
            tree.Insert(1);
            VerifyTree(tree);
            int[] expectedValues = { 1, 3, 7, 10, 20 };
            foreach (int value in expectedValues)
            {
                int result;
                Assert.That(tree.Find(value, out result), Is.True);
                Assert.That(result, Is.EqualTo(value));
            }
        }

        /// <summary>
        /// Test that root remains black after all insertions
        /// </summary>
        [Test]
        [Category("M: Color Properties")]
        public void TestRootAlwaysBlack()
        {
            RBTree<int> tree = new RBTree<int>();
            for (int i = 1; i <= 15; i++)
            {
                tree.Insert(i);
                Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            }
        }

        /// <summary>
        /// Test that root remains black after deletions
        /// </summary>
        [Test]
        [Category("M: Color Properties")]
        public void TestRootBlackAfterDeletions()
        {
            RBTree<int> tree = new RBTree<int>();
            for (int i = 1; i <= 10; i++)
            {
                tree.Insert(i);
            }
            for (int i = 1; i <= 9; i++)
            {
                tree.Remove(i);
                if (tree.Root != RBTree<int>.NIL)
                {
                    Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
                }
            }
        }

        /// <summary>
        /// method to verify the given tree is a true red-black tree
        /// </summary>
        /// <param name="tree">The tree to be tested</param>
        private void VerifyTree(RBTree<int> tree)
        {
            if (tree.Root.Color == NodeColor.Red)
                throw new Exception("Root must be black");
            CheckNode(tree.Root);
        }



        /// <summary>
        /// Recursive helper method to verify the given tree is a true red-black tree (assumes the original root of the tree has been checked)
        /// </summary>
        /// <param name="node">The root of the current tree</param>
        /// <returns>number of nodes</returns>
        private int CheckNode(RBTreeNode<int> node)
        {
            if (node == RBTree<int>.NIL)
                return 1;

            int left = CheckNode(node.LeftChild);
            int right = CheckNode(node.RightChild);
            if (left != right)
                throw new Exception("All paths to leaves must contain the same number of black nodes");
            if (node.Color == NodeColor.Black)
                return left + 1;
            else
            {
                if ((node.LeftChild != RBTree<int>.NIL && node.LeftChild.Color == NodeColor.Red) ||
                    (node.RightChild != RBTree<int>.NIL && node.RightChild.Color == NodeColor.Red))
                {
                    throw new Exception("A red node can only have black children");
                }
            }
            return left;

        }

    }
}

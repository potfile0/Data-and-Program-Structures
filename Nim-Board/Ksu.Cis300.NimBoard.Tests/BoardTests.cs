/* BoardTests.cs
 * Author: Josh Weese
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ksu.Cis300.NimBoard.Tests
{
    /// <summary>
    /// Unit tests for the Board class.
    /// </summary>
    [TestFixture]
    public class BoardTests
    {
        /// <summary>
        /// Tests that constructing a board with arrays of different lengths
        /// throws an ArgumentException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAConstructDifferentLengths()
        {
            Assert.That(() => new Board(new int[] { 0 }, new int[] { 2, 3 }), 
                Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        /// Tests that the constructor correctly saves the given values.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAConstructorSavesValues()
        {
            int[] values = new int[] { 2, 4, 5, 10 };
            Board b = new Board(new int[] { values[2], values[3] }, 
                new int[] { values[0], values[1] });
            List<int> retrieved = new();
            retrieved.Add(b.GetLimit(0));
            retrieved.Add(b.GetLimit(1));
            retrieved.Add(b.GetValue(0));
            retrieved.Add(b.GetValue(1));
            Assert.That(retrieved, Is.Ordered.And.EquivalentTo(values));
        }

        /// <summary>
        /// Tests that a comparison of a non-null board with null using == gives false,
        /// and that the same comparison using != is true.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEqualsOperatorNonNullWithNull()
        {
            Board b = new Board(new int[] { 5 }, new int[] { 2 });
            Assert.Multiple(() =>
            {
                Assert.That(b == null, Is.False);
                Assert.That(b != null, Is.True);
            });
        }

        /// <summary>
        /// Tests that a comparison of null with a non-null board using == gives false,
        /// and that the same comparison using != gives true.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEqualsOperatorNullWithNonNull()
        {
            Board b = new Board(new int[] { 10 }, new int[] { 4 });
            Assert.Multiple(() =>
            {
                Assert.That(null == b, Is.False);
                Assert.That(null != b, Is.True);
            });
        }

        /// <summary>
        /// Tests that a comparison of two null boards using == gives true,
        /// and that the same comparison using != gives false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEqualsOperatorNullWithNull()
        {
            Board? b1 = null;
            Board? b2 = null;
            Assert.Multiple(() =>
            {
                Assert.That(b1 == b2, Is.True);
                Assert.That(b1 != b2, Is.False);
            });
        }

        /// <summary>
        /// Tests that comparing a board with an int using the board's Equals method
        /// returns false.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEqualsMethodNonBoard()
        {
            Assert.That(new Board(new int[] { 20 }, new int[] { 3 }).Equals(5), Is.False);
        }

        /// <summary>
        /// Tests that two boards having different numbers of piles are different according to all
        /// three methods.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBLengthsDifferent()
        {
            Board b1 = new Board(new int[] { 20 }, new int[] { 2 });
            Board b2 = new Board(new int[] { 20, 10 }, new int[] { 2, 4 });
            Assert.Multiple(() =>
            {
                Assert.That(b1 == b2, Is.False);
                Assert.That(b1 != b2, Is.True);
                Assert.That(b1, Is.Not.EqualTo(b2), "b1.Equals(b2) returns true.");
            });
        }

        /// <summary>
        /// Tests that two 4-pile boards whose third piles have a different number of stones
        /// are different by all three methods.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCThirdPileDifferent()
        {
            Board b1 = new Board(new int[] { 5, 10, 15, 20 }, new int[] { 2, 4, 6, 8 });
            Board b2 = new Board(new int[] { 5, 10, 20, 20 }, new int[] { 2, 4, 6, 8 });
            Assert.Multiple(() =>
            {
                Assert.That(b1 == b2, Is.False);
                Assert.That(b1 != b2, Is.True);
                Assert.That(b1, Is.Not.EqualTo(b2), "b1.Equals(b2) returns true.");
            });
        }

        /// <summary>
        /// Tests that 2 4-pile boards whose third piles have a different limit are different
        /// by all three methods.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCThirdLimitDifferent()
        {
            Board b1 = new Board(new int[] { 5, 10, 15, 20 }, new int[] { 2, 4, 6, 8 });
            Board b2 = new Board(new int[] { 5, 10, 15, 20 }, new int[] { 2, 4, 2, 8 });
            Assert.Multiple(() =>
            {
                Assert.That(b1 == b2, Is.False);
                Assert.That(b1 != b2, Is.True);
                Assert.That(b1, Is.Not.EqualTo(b2), "b1.Equals(b2) returns true.");
            });
        }

        /// <summary>
        /// Tests that two identical boards with 3 piles are found to be equal by all three methods.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDEqual()
        {
            Board b1 = new Board(new int[] { 5, 10, 15 }, new int[] { 2, 4, 6 });
            Board b2 = new Board(new int[] { 5, 10, 15 }, new int[] { 2, 4, 6 });
            Assert.Multiple(() =>
            {
                Assert.That(b1 == b2, Is.True);
                Assert.That(b1 != b2, Is.False);
                Assert.That(b1, Is.EqualTo(b2), "b1.Equals(b2) returns false.");
            });
        }

        /// <summary>
        /// Tests that two boards with no piles are equal by all three methods.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestETwoEmptyBoards()
        {
            Board b1 = new Board(new int[0], new int[0]);
            Board b2 = new Board(new int[0], new int[0]);
            Assert.Multiple(() =>
            {
                Assert.That(b1 == b2, Is.True);
                Assert.That(b1 != b2, Is.False);
                Assert.That(b1, Is.EqualTo(b2), "b1.Equals(b2) returns false.");
            });
        }

        /// <summary>
        /// Tests that the Board constructor copies the piles array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEConstructorCopiesPiles()
        {
            int[] piles = new int[] { 4 };
            int[] limits = new int[] { 2 };
            Board b1 = new Board(piles, limits);
            piles[0] = 6;
            Board b2 = new Board(piles, limits);
            Assert.That(b1, Is.Not.EqualTo(b2));
        }

        /// <summary>
        /// Tests that the Board constructor copies the limits array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEConstructorCopiesLimits()
        {
            int[] piles = new int[] { 4 };
            int[] limits = new int[] { 2 };
            Board b1 = new Board(piles, limits);
            limits[0] = 4;
            Board b2 = new Board(piles, limits);
            Assert.That(b1, Is.Not.EqualTo(b2));
        }
    }
}

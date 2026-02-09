///
/// TestCases.cs
/// Author: Josh Weese
///
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using KSU.CIS300.TowerOfHanoi;
using System;

namespace KSU.CIS300.TowerOfHanoi.Test
{
    /// <summary>
    /// Test cases for the Tower of Hanoi program.
    /// </summary>
    [TestFixture]
    public class TestCases
    {
        /// <summary>
        /// reference to an instance of the UI.
        /// </summary>
        private UserInterface _ui;

        /// <summary>
        /// Setup the test environment.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _ui = new UserInterface();
            _ui.TestMode = true;
        }

        /// <summary>
        /// Tear down the test environment.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            if (_ui != null)
            {
                _ui.Dispose();
                _ui = null;
            }
        }

        /// <summary>
        /// Test the move between two stacks that are empty.
        /// </summary>
        [Test]
        [Category("A CheckMove")]
        public void CheckMoveFromEmpty()
        {
            Stack<int> from = new Stack<int>();
            Stack<int> to = new Stack<int>();
            bool result = _ui.CheckMove(from, to);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// Check move from a stack to an empty stack.
        /// </summary>
        [Test]
        [Category("A CheckMove")]
        public void CheckMoveToEmpty()
        {
            Stack<int> from = new Stack<int>();
            from.Push(1);
            Stack<int> to = new Stack<int>();
            bool result = _ui.CheckMove(from, to);
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Check move from a stack to a stack with a smaller disc.
        /// </summary>
        [Test]
        [Category("A CheckMove")]
        public void CheckMoveBiggerDisc()
        {
            Stack<int> from = new Stack<int>();
            from.Push(10);
            Stack<int> to = new Stack<int>();
            to.Push(5);
            bool result = _ui.CheckMove(from, to);
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// Check move from a stack to a stack with a larger disc.
        /// </summary>
        [Test]
        [Category("A CheckMove")]
        public void CheckMoveCountmallerDisc()
        {
            Stack<int> from = new Stack<int>();
            from.Push(5);
            Stack<int> to = new Stack<int>();
            to.Push(10);
            bool result = _ui.CheckMove(from, to);
            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Check that move is invalid and stacks are unchanged.
        /// </summary>
        [Test]
        [Category("B Move")]
        public void MoveInvalid()
        {
            Stack<int> from = new Stack<int>();
            from.Push(10);
            Stack<int> to = new Stack<int>();
            to.Push(5);
            bool result = _ui.MoveDisc(from, to);
            Assert.That(result, Is.False);
            Assert.That(from.Count, Is.EqualTo(1));
            Assert.That(to.Count, Is.EqualTo(1));
            Assert.That(from.Pop(), Is.EqualTo(10));
            Assert.That(to.Pop(), Is.EqualTo(5));
        }

        /// <summary>
        /// Check result of valid move
        /// </summary>
        [Test]
        [Category("B Move")]
        public void MoveValid()
        {
            Stack<int> from = new Stack<int>();
            from.Push(5);
            Stack<int> to = new Stack<int>();
            to.Push(10);
            bool result = _ui.MoveDisc(from, to);
            Assert.That(result, Is.True);
            Assert.That(_ui.MoveCount, Is.EqualTo(1));
            Assert.That(from.Count, Is.EqualTo(0));
            Assert.That(to.Count, Is.EqualTo(2));
            Assert.That(to.Pop(), Is.EqualTo(5));
            Assert.That(to.Pop(), Is.EqualTo(10));
        }

        /// <summary>
        /// Check that the disc is moved from x to y.
        /// </summary>
        [Test]
        [Category("C MoveEither")]
        public void MoveEitherX()
        {
            Stack<int> from = new Stack<int>();
            from.Push(5);
            Stack<int> to = new Stack<int>();
            to.Push(10);
            _ui.MoveEither(from, to);

            Assert.That(_ui.MoveCount, Is.EqualTo(1));
            Assert.That(from.Count, Is.EqualTo(0));
            Assert.That(to.Count, Is.EqualTo(2));
            Assert.That(to.Pop(), Is.EqualTo(5));
            Assert.That(to.Pop(), Is.EqualTo(10));
        }

        /// <summary>
        /// Check that the disc is moved from y to x.
        /// </summary>
        [Test]
        [Category("C MoveEither")]
        public void MoveEitherY()
        {
            Stack<int> x = new Stack<int>();
            x.Push(10);
            Stack<int> y = new Stack<int>();
            y.Push(5);
            _ui.MoveEither(x, y);
            Assert.That(_ui.MoveCount, Is.EqualTo(1));
            Assert.That(y.Count, Is.EqualTo(0));
            Assert.That(x.Count, Is.EqualTo(2));
            Assert.That(x.Pop(), Is.EqualTo(5));
            Assert.That(x.Pop(), Is.EqualTo(10));
        }

        /// <summary>
        /// Check that neither stack is moved when both are empty.
        /// </summary>
        [Test]
        [Category("C MoveEither")]
        public void MoveEitherNeither()
        {
            Stack<int> x = new Stack<int>();
            Stack<int> y = new Stack<int>();
            _ui.MoveEither(x, y);
            Assert.That(y.Count, Is.EqualTo(0));
            Assert.That(x.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Solve the puzzle with an even number of discs.
        /// </summary>
        [Test]
        [Category("D Solve")]
        public void SolveEven()
        {
            LoadPuzzle(6);
            _ui.Solve(_ui.PegB, _ui.PegC, 0);
            Assert.That(_ui.PegA.Count, Is.EqualTo(0));
            Assert.That(_ui.PegB.Count, Is.EqualTo(0));
            Assert.That(_ui.PegC.Count, Is.EqualTo(6));
            Assert.That(_ui.MoveCount, Is.EqualTo(Math.Pow(2, 6) - 1));
        }

        /// <summary>
        /// Solve the puzzle with an odd number of discs.
        /// </summary>
        [Test]
        [Category("D Solve")]
        public void SolveOdd()
        {
            LoadPuzzle(7);
            _ui.Solve(_ui.PegC, _ui.PegB, 0);
            Assert.That(_ui.PegA.Count, Is.EqualTo(0));
            Assert.That(_ui.PegB.Count, Is.EqualTo(0));
            Assert.That(_ui.PegC.Count, Is.EqualTo(7));
            Assert.That(_ui.MoveCount, Is.EqualTo(Math.Pow(2, 7) - 1));
        }


        /// <summary>
        /// Load a puzzle with a given number of discs.
        /// </summary>
        /// <param name="count">Number of discs to start with</param>
        private void LoadPuzzle(int count)
        {
            _ui.NewPuzzle(count);
        }

    }
}

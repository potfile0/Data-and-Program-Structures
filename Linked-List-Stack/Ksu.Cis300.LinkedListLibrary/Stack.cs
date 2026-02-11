using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    /// <summary>
    /// A public class to make stack out of linked lists
    /// </summary>
    /// <typeparam name="T">A generic data type</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// An a private field to store the top of the linked list
        /// </summary>
        private LinkedListCell<T>? _top;

        /// <summary>
        /// A property Count to keep track of the objects
        /// </summary>
        public int Count
        {
            get;set;
        }

        /// <summary>
        /// Class Push to push an object to the linked list
        /// </summary>
        /// <param name="item">The item to be pushed</param>
        public void Push(T item)
        {
            _top = new LinkedListCell<T>(item, _top);
            Count++;
        }

        /// <summary>
        /// A class peek to peek into the item in the linked list
        /// </summary>
        /// <returns>return the top object</returns>
        /// <exception cref="InvalidOperationException">Exception to show when the stack is empty</exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            return _top.Data;
        }

        /// <summary>
        /// A class pop to pop the last data in the linked list
        /// </summary>
        /// <returns>returns the data that was just popped with help of Peek we wrote earlier</returns>
        public T Pop()
        {
            T data = Peek();
            _top = _top.Next;
            Count--;
            return data;
        }
    }
}

namespace Ksu.Cis300.StackLibrary
{
    /// <summary>
    /// Implementing a generic stack
    /// </summary>
    /// <typeparam name="T">T will represent the type of elements that will be stores in the stack</typeparam>
    public class Stack<T>
    {
        /// <summary>
        /// A private constant field to store the initial array size
        /// </summary>
        private const int ArraySize = 5;

        /// <summary>
        /// a private field of type T?[] to act as variable and initialized to a new T[] whose lenght is the value of constant above
        /// </summary>
        private T?[] _stack = new T[ArraySize];

        /// <summary>
        /// a property Count with default getter and setter
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// a property Capacity with getter returning the lenght of the stack and no setter
        /// </summary>
        public int Capacity
        {
            get
            {
                int lenght = _stack.Length;
                return lenght;
            }
        }
        /// <summary>
        /// a method for the push operation 
        /// </summary>
        /// <param name="x">The object to push to the stack</param>
        public void Push(T x)
        {
            if (Count == _stack.Length)
            {
                T?[] newArray = new T[_stack.Length * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _stack[i];
                }
                _stack = newArray;
            }

            _stack[Count] = x;
            Count++;
        }

        /// <summary>
        /// a methos for the Peek operation
        /// </summary>
        /// <returns>returns the last object in the stack</returns>
        /// <exception cref="InvalidOperationException">Exception for if the stack is empty</exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return _stack[Count - 1]!;
        }
        /// <summary>
        /// a method for the pop operation
        /// </summary>
        /// <returns>returns the last object </returns>
        /// <exception cref="InvalidOperationException">an exception for when the stack is empty</exception>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            Count--;
            T value = _stack[Count];
            return value;
        }
        /// <summary>
        /// a method Clear to clear the stack, set the size of the stack to initial value and reset the count to 0
        /// </summary>
        public void Clear()
        {
            _stack = new T[ArraySize];
            Count = 0;
        }
    }
}

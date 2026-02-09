namespace Ksu.Cis300.QueueLibrary
{
    /// <summary>
    /// The class statement with parameter T
    /// </summary>
    /// <typeparam name="T">paramenter to store objects</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Initial capacity of the queue
        /// </summary>
        private const int _initialCapacity = 5;

        /// <summary>
        /// _array is the fields in which to store the elements
        /// </summary>
        private T?[] _array;

        /// <summary>
        /// _count property to keep track of count
        /// </summary>
        private int _count;

        /// <summary>
        /// _front property to keep track of front
        /// </summary>
        private int _front;

        public Queue()
        {
            _array = new T?[_initialCapacity];
            _count = 0;
            _front = 0;
        }

        /// <summary>
        /// Gets the number of elements in the queue
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Gets the capacity of the array
        /// </summary>
        public int Capacity
        {
            get { return _array.Length; }
        }


        /// <summary>
        /// Adds an element to the back of the queue
        /// </summary>
        /// <param name="x"> the object to enqueue</param>
        public void Enqueue(T x)
        {
            if (_count == _array.Length)
            {
                T?[] newArray = new T?[2 * _array.Length];

                int firstPartCount = _array.Length - _front;
                Array.Copy(_array, _front, newArray, _front, firstPartCount);

                Array.Copy(_array, 0, newArray, _array.Length, _front);

                _array = newArray;
            }

            int back = _front + _count;
            if (back >= _array.Length)
            {
                back -= _array.Length;
            }

            _array[back] = x;
            _count++;
        }


        /// <summary>
        /// Returns the element at the front of the queue
        /// </summary>
        /// <returns>returns the front of the array</returns>
        /// <exception cref="InvalidOperationException">The Queue is empty</exception>
        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The Queue is empty");
            }

            return _array[_front]!;
        }


        /// <summary>
        /// Removes and returns the element at the front of the queue
        /// </summary>
        /// <returns>returns the value</returns>
        /// <exception cref="InvalidOperationException">The queue is empty</exception>
        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The Queue is empty");
            }

            T value = _array[_front]!;
            _array[_front] = default;

            _front++;
            if (_front == _array.Length)
            {
                _front = 0;
            }

            _count--;
            return value;
        }
    }
}

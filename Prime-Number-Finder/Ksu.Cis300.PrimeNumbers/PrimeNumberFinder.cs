using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.PrimeNumbers
{
    /// <summary>
    /// A class to find list of prime number till n 
    /// </summary>
    public class PrimeNumberFinder
    {
        /// <summary>
        /// a method to create a listlink till n
        /// </summary>
        /// <param name="n">the number till which to create a list</param>
        /// <returns>returns a linkedlist for numbers till n</returns>
        public static LinkedListCell<int>? GetNumbersLessThan(int n)
        {
            if (n <= 2)
            {
                return null;
            }
            else
            {
                LinkedListCell<int>? head = new LinkedListCell<int>(2, null);
                LinkedListCell<int>? tail = head;

                for (int i = 3; i < n; i++)
                {
                    LinkedListCell<int> newNode = new LinkedListCell<int>(i, null);
                    tail.Next = newNode;
                    tail = newNode;
                }
                return head;
            }
        }

        /// <summary>
        /// a method to removes the multiples of given number from the linkedlist
        /// </summary>
        /// <param name="k"> the number supplied of which the multiples is to be removed</param>
        /// <param name="list"> the linkedlist supplied</param>
        public static void RemoveMultiples(int k, LinkedListCell<int> list)
        {
            LinkedListCell<int>? prev = list;
            LinkedListCell<int>? current = list.Next;

            while (current != null)
            {
                if (current.Data % k == 0)
                {
                    prev.Next = current.Next;
                    current = current.Next;
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            }
        }


        /// <summary>
        /// a method that combines all the method above, so we supply a number "n" and we get the linkedlist of prime nu
        /// </summary>
        /// <param name="n">The number supplied</param>
        /// <returns>a linked list with the output we want</returns>
        public static LinkedListCell<int>? GetPrimesLessThan(int n)
        {
            LinkedListCell<int>? node = GetNumbersLessThan(n);
            LinkedListCell<int>? temp = node;

            while (temp != null && temp.Data * temp.Data <= n  ) 
            {
                RemoveMultiples(temp.Data, temp);
                temp =temp.Next;

            }
            return node;

        }

    }
}

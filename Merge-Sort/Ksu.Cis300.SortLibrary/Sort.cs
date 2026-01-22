/* Sort.cs
 * Author: Josh Weese
 */
namespace Ksu.Cis300.SortLibrary
{
    /// <summary>
    /// A collection of methods for sorting ILists of ints.
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// Swaps the given locations of the given list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="i">The index of one of the elements to swap.</param>
        /// <param name="j">The index of the other element.</param>
        private static void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// Sorts the given IList using selection sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        public static void SelectionSort(IList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            int end = list.Count - 1;
            for (int i = 0; i < end; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                Swap(list, i, min);
            }
        }

        /// <summary>
        /// Sorts the given IList using insertion sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        public static void InsertionSort(IList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 1; i < list.Count; i++)
            {
                int j = i;
                int temp = list[j];
                while (j > 0 && temp < list[j - 1])
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = temp;
            }
        }
    }
}

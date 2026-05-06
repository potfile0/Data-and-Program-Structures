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

        /// <summary>
        /// Merges two adjacent sorted parts of the given IList into one sorted part.
        /// </summary>
        /// <param name="list">The list to merge.</param>
        /// <param name="start">The first index of the first sorted part.</param>
        /// <param name="len1">The number of elements in the first sorted part.</param>
        /// <param name="len2">The number of elements in the second sorted part.</param>
        private static void Merge(IList<int> list, int start, int len1, int len2)
        {
            int[] temp = new int[len1 + len2];
            int start1 = start;
            int start2 = start + len1;
            int dest = 0;
            int end1 = start2;
            int end2 = start2 + len2;
            while (start1 < end1 && start2 < end2)
            {
                if (list[start1] <= list[start2])
                {
                    temp[dest] = list[start1];
                    dest++;
                    start1++;
                }
                else
                {
                    temp[dest] = list[start2];
                    dest++;
                    start2++;
                }
            }
            while (start1 < end1)
            {
                temp[dest] = list[start1];
                dest++;
                start1++;
            }
            while (start2 < end2)
            {
                temp[dest] = list[start2];
                dest++;
                start2++;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                list[start + i] = temp[i];
            }
        }

        /// <summary>
        /// Sorts the specified portion of the given IList using Merge Sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="start">The first index of the portion to sort.</param>
        /// <param name="len">The number of elements in the portion to sort.</param>
        private static void MergeSort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int len1 = len / 2;
                int len2 = len - len1;
                MergeSort(list, start, len1);
                MergeSort(list, start + len1, len2);
                Merge(list, start, len1, len2);
            }
        }

        /// <summary>
        /// Sorts the given IList using Merge Sort.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        public static void MergeSort(IList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            MergeSort(list, 0, list.Count);
        }

        /// <summary>
        /// sorts specified portion of given list
        /// </summary>
        /// <param name="list"> give list </param>
        /// <param name="start"> the first index </param>
        /// <param name="len"> the length of portion </param>
        private static void QuickSort(IList<int> list, int start, int len)
        {
            if (len > 1)
            {
                int pivot = list[start];

                int afterL = start;
                int beforeE = start + len - 1;
                int beforeG = start + len - 1;

                while (afterL <= beforeE)
                {
                    int last = list[beforeE];

                    if (last < pivot)
                    {
                        Swap(list, beforeE, afterL);
                        afterL++;
                    }
                    else if (last == pivot)
                    {
                        beforeE--;
                    }
                    else if (last > pivot)
                    {
                        Swap(list, beforeE, beforeG);
                        beforeG--;
                        beforeE--;
                    }
                }

                ///seg L
                QuickSort(list, start, afterL - start);

                int segG = (start + len - 1) - beforeG;
                
                ///seg G
                QuickSort(list, beforeG + 1, segG);
             }
        }

        /// <summary>
        /// sorts the given list using quicksort
        /// </summary>
        /// <param name="list"> Given list </param>
        /// <exception cref="ArgumentNullException"> list is null</exception>
        public static void QuickSort(IList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            QuickSort(list, 0, list.Count);
        }
    }
}

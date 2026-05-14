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
        /// method to merge two adjacent sorted postions of list into a single sorted portion
        /// </summary>
        /// <param name="list"> given list </param>
        /// <param name="start"> where first portion begins</param>
        /// <param name="len1"> number of elements in first portion </param>
        /// <param name="len2"> number of elements in second portion </param>
        private static void Merge(IList<int> list, int start, int len1, int len2)
        {
            int[] temp = new int[len1 + len2];

            ///first
            int i = start;

            ///second
            int j = start + len1;

            ///temp
            int k = 0;

            while (i < start + len1 && j < start + len1 + len2)
            {
                if (list[i] <= list[j])
                {
                    temp[k] = list[i];
                    i++;
                }
                else
                {
                    temp[k] = list[j];
                    j++;
                }
                k++;
            }

            ///copying from 1st portion
            while (i < start + len1)
            {
                temp[k] = list[i];
                i++;
                k++;
            }

            ///second
            while (j < start + len1 + len2)
            {
                temp[k] = list[j];
                j++;
                k++;
            }

            ///temp back
            for (int m = 0; m < temp.Length; m++)
            {
                list[start + m] = temp[m];
            }
        }

        /// <summary>
        /// recursive method to sort a portion of list 
        /// </summary>
        /// <param name="list"> the given list</param>
        /// <param name="start"> where first portion begins </param>
        /// <param name="len"> elements first portion has </param>
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
        /// sorts the given list using merge sort
        /// </summary>
        /// <param name="list"> the given list</param>
        /// <exception cref="ArgumentNullException"> list null </exception>
        public static void MergeSort(IList<int> list)
        {
            if(list == null)
            {
                throw new ArgumentNullException("list null");
            }
            else
            {
                MergeSort(list, 0, list.Count);
            }
        }
    }
}
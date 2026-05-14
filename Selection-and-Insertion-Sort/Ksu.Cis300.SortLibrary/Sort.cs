namespace Ksu.Cis300.SortLibrary
{
    /// <summary>
    /// sort class
    /// </summary>
    public static class Sort
    {
        /// <summary>
        /// to swap the value at location i in list with the value in location j
        /// </summary>
        /// <param name="list"> given list </param>
        /// <param name="i"> value to swap</param>
        /// <param name="j"> value to swap with</param>
        private static void Swap(IList<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /// <summary>
        /// to sort the given list using Selection Sort
        /// </summary>
        /// <param name="list"> given list </param>
        /// <exception cref="ArgumentNullException"> list is null </exception>
        public static void SelectionSort(IList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < list.Count - 1; i++)
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
        /// implement Insertion Sort
        /// </summary>
        /// <param name="list"> given list </param>
        /// <exception cref="ArgumentNullException"> list is null</exception>
        public static void InsertionSort(IList<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 1; i < list.Count; i++)
            {
               ///first elem of unsorted portion
                int temp = list[i];

                int j = i;
                while (j > 0 && list[j - 1] > temp)
                {
                    list[j] = list[j - 1];
                    j--;
                }

                list[j] = temp;
            }
        }
    }
}

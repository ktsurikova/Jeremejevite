using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    /// <summary>
    /// provides methods for sorting arrays
    /// </summary>
    public class Sorter
    {
        #region QuickSort

        /// <summary>
        /// sorts an array using non-recursive quicksort algorithm
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <exception cref="ArgumentNullException">when array is null</exception>>
        public static void QuickSort(int[] array)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException("array is null");

            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(array.Length);

            while (stack.Count != 0)
            {
                int end = stack.Pop();
                int start = stack.Pop();
                if (end - start < 2) { continue; }

                int p = Partition(array, start, end - 1);

                stack.Push(p + 1);
                stack.Push(end);
                stack.Push(start);
                stack.Push(p);
            }
        }

        private static int Partition(int[] input, int start, int end)
        {
            int position = start + (end - start) / 2;
            int piv = input[position];
            Swap(ref input[position], ref input[end]);

            int index = start;

            for (int i = start; i < end; i++)
            {
                if (input[i] <= piv)
                {
                    Swap(ref input[i], ref input[index++]);
                }
            }

            Swap(ref input[index], ref input[end]);
            return index;
        }

        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        #endregion

        #region MergeSort

        /// <summary>
        /// sorts an array using non-recursive mergesort algorithm
        /// </summary>
        /// <param name="array">array to be sorted</param>
        /// <exception cref="ArgumentNullException">when array is null</exception>>
        public static void MergeSort(int[] array)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException("array is null");
            if (array.Length < 2) return;

            int step = 1;
            int startL, startR;

            while (step < array.Length)
            {
                startL = 0;
                startR = step;
                while (startR + step <= array.Length)
                {
                    MergeParts(array, startL, startL + step, startR, startR + step);

                    startL = startR + step;
                    startR = startL + step;
                }

                //if an array of odd length
                if (startR < array.Length)
                {
                    MergeParts(array, startL, startL + step, startR, array.Length);
                }
                step *= 2;
            }
        }

        private static void MergeParts(int[] array, int startL, int stopL,
            int startR, int stopR)
        {

            int[] right = new int[stopR - startR];
            int[] left = new int[stopL - startL];

            Array.Copy(array, startR, right, 0, right.Length);
            Array.Copy(array, startL, left, 0, left.Length);

            for (int k = startL, m = 0, n = 0; k < stopR; ++k)
            {
                if (n == right.Length)
                {
                    array[k] = left[m++];
                    continue;
                }
                if (m == left.Length)
                {
                    array[k] = right[n++];
                    continue;
                }
                if (left[m] <= right[n])
                {
                    array[k] = left[m++];
                }
                else
                {
                    array[k] = right[n++];
                }
            }
        }

        #endregion
    }
}

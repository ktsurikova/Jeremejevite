using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        #region SortingsTests

        public static IEnumerable<TestCaseData> TestDataForSortings
        {
            get
            {
                yield return new TestCaseData(new[] { 12, 11, 17, 8, 7, 11, 11, 9, 4 },
                    new[] { 4, 7, 8, 9, 11, 11, 11, 12, 17 });
                yield return new TestCaseData(new[] { 9, 5, 2, 8, 1, 7, 4, 6, 3 },
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                yield return new TestCaseData(new[] { 6, -5, 1, -10 },
                    new[] { -10, -5, 1, 6 });
            }
        }

        #region QuickSortTests

        [Test, TestCaseSource(nameof(TestDataForSortings))]
        public void QuickSort_Array_SortedArray(int[] array, int[] sortedArray)
        {
            ArrayExtension.QuickSort(array);
            Assert.AreEqual(array, sortedArray);
        }

        [Test]
        public void QuickSort_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.QuickSort(null));
        }

        #endregion

        #region MergeSortTests

        [Test, TestCaseSource(nameof(TestDataForSortings))]
        public void MergeSort_Array_SortedArray(int[] array, int[] sortedArray)
        {
            ArrayExtension.MergeSort(array);
            Assert.AreEqual(array, sortedArray);
        }

        [Test]
        public void MergeSort_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.MergeSort(null));
        }

        #endregion

        #endregion

        #region SumLeftEqualsSumRightTests

        public static IEnumerable<TestCaseData> TestDataForSumLeftEqualsSumRight
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 2, 3, 4, 3, 2, 1 }).Returns(3);
                yield return new TestCaseData(new[] { 1, 100, 50, -51, 1, 1 }).Returns(1);
                yield return new TestCaseData(new[] { 1, 4, 6, 8 }).Returns(-1);
                yield return new TestCaseData(new[] { 1, 2, 1 }).Returns(1);
                yield return new TestCaseData(new[] { 1, 2 }).Returns(-1);
                yield return new TestCaseData(new int[0]).Returns(-1);

            }
        }

        [Test, TestCaseSource(nameof(TestDataForSumLeftEqualsSumRight))]
        public int IndexOfSumLeftEqualsSumRight_Array_Index(int[] array)
        {
            return ArrayExtension.IndexOfSumLeftEqualsSumRight(array);
        }

        [Test]
        public void IndexOfSumLeftEqualsSumRight_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.IndexOfSumLeftEqualsSumRight(null));
        }

        #endregion

        #region SumOfElementFromStartToEnd (Internal)

        public static IEnumerable<TestCaseData> TestDataForSumOfElementFromStartToEnd
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 2, 3 }, 0, 3).Returns(6);
                yield return new TestCaseData(new[] { 1, 100, 50, -50, 1, 1 }, 1, 4).Returns(100);
            }
        }

        [Test, TestCaseSource(nameof(TestDataForSumOfElementFromStartToEnd))]
        public int Sum_Array_Index(int[] array, int start, int end)
        {
            return ArrayExtension.Sum(array, start, end);
        }

        #endregion

    }
}

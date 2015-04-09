using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewScenarios.DataProcessing
{
    public static class SortMethods
    {
        /// <summary>
        /// Selection
        /// Operational:
        ///  > Grabs 1st element in array/list
        ///  > Scans through array to find element with smaller key
        ///  > Swaps this with 1st element
        /// </summary>
        /// <param name="someDataInteger32"></param>
        public static void Selection (int[] someDataInteger32)
        {
            Helpers.DataProcessing.selectionRecursive(someDataInteger32, 0);
        }

        /// <summary>
        /// Insertion
        /// </summary>
        public static void Insertion()
        {
        }

        /// <summary>
        /// QuickSort 
        /// </summary>
        public static void QuickSort()
        {
        }

        /// <summary>
        /// MergeSort
        /// </summary>
        public static void MergeSort()
        {
        }
    }
}

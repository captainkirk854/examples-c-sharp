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
        /// Selection sort - recursive ..
        /// Operational:
        ///  > Grabs 1st element in array/list
        ///  > Scans through array to find element with smaller key
        ///  > Swaps this with 1st element
        ///  > Is UNSTABLE - ie indexes are output in a swapped state for same value keys
        ///  > Recursive nature effectively limits size of array that can be sorted due to stack overflow possibility ..
        /// </summary>
        /// <param name="someDataInteger32"></param>
        /// <param name="startPos"></param>
        public static void SelectionRecursive (int[] someDataInteger32, int startPos)
        {
            // Console.WriteLine(string.Join(", ", someDataInteger32));
            if (startPos < someDataInteger32.Length -1)
            {
                Helpers.DataProcessing.ArrayValueSwap(someDataInteger32, startPos, Helpers.DataProcessing.GetPositionOfLowestValue(someDataInteger32, startPos));
                SelectionRecursive(someDataInteger32, startPos + 1);
            }
          // Console.WriteLine(string.Join(", ", someDataInteger32));
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

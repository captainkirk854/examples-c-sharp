using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace InterviewScenarios
{
    public static class Run
    {
        /// <summary>
        /// Run this sort with timings in the form of clicks ..
        /// </summary>
        /// <param name="MaxArraySize"></param>
        /// <param name="ArraySizeIncrement"></param>
        public static void SelectionSortRecursive(int MaxArraySize, int ArraySizeIncrement)
        {
            // Initialise ..
            Stopwatch sw = new Stopwatch();

            int localArraySize = ArraySizeIncrement;

            // Time them ..
            while (localArraySize <= MaxArraySize -1)
            {
                // Prepare ..
                localArraySize += ArraySizeIncrement;
                int[] arrayOfInt32sToSort = Helpers.DataGenerator.ArrayOfInt32(localArraySize);
                
                // Perform sort ..
                try
                {
                    int startPos = 0;
                    sw.Restart();
                    DataProcessing.SortMethods.SelectionRecursive(arrayOfInt32sToSort, startPos);
                    sw.Stop();
                }
                catch (Exception ex)
                {
                    ex.GetType();
                }
                finally
                {                 
                    Console.WriteLine("Array of {0} element(s) took {1} tick(s) to sort using [Sort=SelectionRecursive]", localArraySize, sw.ElapsedTicks);                
                }
            }
        }
    }
}

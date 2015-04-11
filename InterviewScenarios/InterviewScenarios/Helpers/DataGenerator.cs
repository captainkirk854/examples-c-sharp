using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewScenarios.Helpers
{
    class DataGenerator
    {
        /// <summary>
        /// Generate array of random int32s of user-defined size ..
        /// </summary>
        /// <param name="ListSize"></param>
        /// <returns></returns>
        public static int[] ArrayOfInt32(int ListSize)
        {
            // Initialise ..
            int[] arrayOfInts = new int[ListSize];

            // Populate ..
            Random r = new Random();
            for (int loop = 1; loop < ListSize; loop++)
            {
                arrayOfInts[loop] = r.Next(0, ListSize);
            }

            return arrayOfInts;
        }
    }
}

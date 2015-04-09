using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewScenarios.Helpers
{
    public static class DataProcessing
    {
        /// <summary>
        /// selectionRecursive
        /// </summary>
        /// <param name="someData"></param>
        /// <param name="startPos"></param>
        public static void selectionRecursive(int[] someData, int startPos)
        {
            selectionSwap(someData, startPos, selectionGetPositionOfLowestValue(someData, startPos));
            selectionRecursive(someData, startPos);
        }

        /// <summary>
        /// selectionGetPositionOfLowestValue
        /// </summary>
        /// <param name="someData"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public static int selectionGetPositionOfLowestValue(int[] someData, int startPos)
        {
            int minPos = startPos;

            for (int loop = startPos; loop < someData.Length; loop++)
            {
                if (someData[loop] < someData[minPos]) { minPos = loop; }
            }

            return minPos;
        }

        /// <summary>
        /// selectionSwap
        /// </summary>
        /// <param name="someData"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static void selectionSwap(int[] someData, int index1, int index2)
        {
            int tmp = someData[index1];
            someData[index1] = someData[index2];
            someData[index2] = tmp;
        }
    }
}

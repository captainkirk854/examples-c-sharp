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
        /// GetPositionOfLowestValue
        /// </summary>
        /// <param name="someDataInteger32"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public static int GetPositionOfLowestValue(int[] someDataInteger32, int startPos)
        {
            int minPos = startPos;
            for (int loop = startPos; loop < someDataInteger32.Length; loop++)
            {
                if (someDataInteger32[loop] < someDataInteger32[minPos]) { minPos = loop; }
            }
            return minPos;
        }

        /// <summary>
        /// selectionSwap
        /// </summary>
        /// <param name="someDataInteger32"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static void ArrayValueSwap(int[] someDataInteger32, int index1, int index2)
        {
            int tmp = someDataInteger32[index1];
            someDataInteger32[index1] = someDataInteger32[index2];
            someDataInteger32[index2] = tmp;
        }
    }
}

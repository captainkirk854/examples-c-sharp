using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
/*
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
*/
 
namespace InterviewScenarios
{
    class Program
    {
        /// <summary>
        /// Consts ..
        /// </summary>
        const int ArrayElementMaxSize = 10000;
        const int ArrayElementIncrement = 100;
        const int StackSize = 10000000; // Override default stack size for method(s) which use recursion ...

        static void Main(string[] args)
        {          
            Thread thread = new Thread(new ThreadStart(RunMethodsLikeThisToMakeUseOfNewStackSize), StackSize);
            thread.Start();
        }

        /// <summary>
        /// Simple Wrapper Method to execute the various sorting methods for use in thread ...
        /// </summary>
        static void RunMethodsLikeThisToMakeUseOfNewStackSize()
        {
            Run.SelectionSortRecursive(ArrayElementMaxSize, ArrayElementIncrement);
            Run.DotNetSort(ArrayElementMaxSize, ArrayElementIncrement);
            Console.WriteLine("\nNous sommes fini maintenant ..");
            Console.ReadLine();
        }
    }
}
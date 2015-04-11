using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace InterviewScenarios
{
    class Program
    {
        /// <summary>
        /// Consts ..
        /// </summary>
        const int ArrayElementMaxSize = 10000;
        const int ArrayElementIncrement = 10;
        const int StackSize = 10000000; // override default stack size for any recursive methods ...

        static void Main(string[] args)
        {          
            Thread thread = new Thread(new ThreadStart(RunMethodsLikeThisToUseNewStackSize), StackSize);
            thread.Start();

            Console.WriteLine("\nNous sommes fini ..");
            Console.ReadLine();
        }

        /// <summary>
        /// Simple Wrapper Method to execute the various sorting methods for use in thread ...
        /// </summary>
        static void RunMethodsLikeThisToUseNewStackSize()
        {
            Run.SelectionSortRecursive(ArrayElementMaxSize, ArrayElementIncrement);
        }
    }
}
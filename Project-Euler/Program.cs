using Project_Euler.Helpers;
using Project_Euler.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Project_Euler.Helpers.UsefulFunctions;

namespace Project_Euler
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                System.Diagnostics.Stopwatch watch1 = new Stopwatch();
                watch1.Start();

                Console.WriteLine(Problem14LongestCollatzSequence.GetNum1());

                watch1.Stop();
                Console.WriteLine(watch1.ElapsedMilliseconds);



                System.Diagnostics.Stopwatch watch2 = new Stopwatch();
                watch2.Start();

                Console.WriteLine(Problem14LongestCollatzSequence.GetNum2());

                watch2.Stop();
                Console.WriteLine(watch2.ElapsedMilliseconds);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 2
    /// </summary>
    static class Problem2EvenFibonacciNumbers
    {
        /// <summary>
        /// Returns the answer to problem 2.
        /// </summary>
        /// <returns> The sum of even Fibonacci numbers below 4000000. </returns>
        public static int GetSum()
        {
            return GetEvenFibonacciNumbers().Sum();
        }

        private static List<int> GetEvenFibonacciNumbers()
        {
            List<int> evenNumbers = new List<int>();

            int num1 = 1, num2 = 2; //Beginning of Fibonacci sequnce
            while (num2 <= 4000000)
            {
                if (num2 % 2 == 0)
                {
                    evenNumbers.Add(num2);
                }

                int temp = num2; //Moving num1 and num2 to the next place in the sequence
                num2 += num1;
                num1 = temp;
            }

            return evenNumbers;
        }
    }
}

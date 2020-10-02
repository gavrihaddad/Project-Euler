using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem2EvenFibonacciNumbers
    {
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

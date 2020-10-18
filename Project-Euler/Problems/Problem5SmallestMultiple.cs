using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Euler.Helpers.UsefulFunctions;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 5.
    /// </summary>
    static class Problem5SmallestMultiple
    {
        /// <summary>
        /// Returns the answer to problem 5.
        /// </summary>
        /// <returns> The smallest number that is divisible by all the numbers from 1 to 20. </returns>
        public static long GetSmallestMultiple()
        {
            long[] factors = GetResultPrimeFactors();
            long result = 1;

            for (int i = 2; i < factors.Length; i++)
            {
                if (factors[i] != 0)
                {
                    result *= (int)Math.Pow(i, factors[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the prime factors of the answer.
        /// </summary>
        /// <returns>
        /// An array that contains the prime factors of the answer.
        /// In the i'th place, is the number of times that the answewr is divisible by i.
        /// </returns>
        public static long[] GetResultPrimeFactors()
        {
            long[] primeFactors = new long[21];

            for (int i = 2; i <= 20; i++)
            {
                byte[] currentFactors = GetPrimeFactors(i);

                for (int j = 2; j < currentFactors.Length; j++)
                {
                    if (primeFactors[j] < currentFactors[j])
                    {
                        primeFactors[j] = currentFactors[j];
                    }
                }
            }
            
            return primeFactors;
        }
    }
}

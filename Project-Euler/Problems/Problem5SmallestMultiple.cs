using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem5SmallestMultiple
    {
        public static long GetSmallestMultiple()
        {
            long[] factors = GetResultPrimeFactors();
            long result = 1;

            for (int i = 2; i < factors.Length; i++)
            {
                if (factors[i] != 0)
                {
                    result *= ((int)Math.Pow(i, factors[i]));
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the prime factors of the answer.
        /// </summary>
        public static long[] GetResultPrimeFactors()
        {
            long[] primeFactors = new long[21];

            for (int i = 2; i <= 20; i++)
            {
                long[] currentFactors = UsfulFunctions.GetPrimeFactors(i);

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

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
            Dictionary<long, int> factors = GetResultPrimeFactors();
            long result = 1;

            foreach(var prime in factors)
            {
                result *= (int)Math.Pow(prime.Key, factors[prime.Key]);
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
        private static Dictionary<long, int> GetResultPrimeFactors()
        {
            Dictionary<long, int> primeFactors = new Dictionary<long, int>();

            for (int i = 2; i <= 20; i++)
            {
                Dictionary<long, int> currentFactors = GetPrimeFactors(i);

                foreach(var prime in currentFactors)
                {
                    try
                    {
                        if (primeFactors[prime.Key] < currentFactors[prime.Key])
                        {
                            primeFactors[prime.Key] = currentFactors[prime.Key];
                        }
                    }
                    catch (Exception)  // This prime was not added yet.
                    {

                        primeFactors.Add(prime.Key, currentFactors[prime.Key]);
                    }
                }
            }
            
            return primeFactors;
        }
    }
}
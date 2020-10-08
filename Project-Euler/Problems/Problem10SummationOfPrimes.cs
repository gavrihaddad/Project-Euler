using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 10.
    /// </summary>
    class Problem10SummationOfPrimes
    {
        private static List<long> primes;

        static Problem10SummationOfPrimes()
        {
            primes = new List<long>
            {
                2
            };
        }

        /// <summary>
        /// The answer to problem 10.
        /// </summary>
        /// <returns> The sum of all the primes bellow two million </returns>
        public static long GetSum()
        {
            for (int i = 3; i < 2000000; i += 2)  
            {
                bool isPrime = UsefulFunctions.IsPrimeFast(i, primes);

                if (isPrime == true)
                {
                    primes.Add(i);
                }
            }

            return primes.Sum();
        }
    }
}

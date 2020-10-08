using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Euler.UsefulFunctions;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 7.
    /// </summary>
    static class Problem710001stPrime
    {
        private static readonly long[] primes;

        static Problem710001stPrime()
        {
            primes = new long[10001];
            primes[0] = 2;
        }

        /// <summary>
        /// Returns the answer to problem 7.
        /// </summary>
        /// <returns> The 10001st prime. </returns>
        public static long Get10001stPrime()
        {
            long numToCheck = 3;
            long currentPrimeIndex = 1;

            while (primes[10000] == 0)
            {                
                bool isPrime = IsPrimeFast(numToCheck, primes);

                if (isPrime == true)
                {
                    primes[currentPrimeIndex] = numToCheck;
                    currentPrimeIndex++;
                }

                numToCheck += 2;
            }

            return primes[10000];
        }
    }
}

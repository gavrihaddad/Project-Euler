using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem710001stPrime
    {
        private static long[] primes;

        static Problem710001stPrime()
        {
            primes = new long[10001];
            primes[0] = 2;
        }

        public static long Get10001stPrime()
        {
            long numToCheck = 3;
            long currentPrimeIndex = 1;
            bool isPrime = false;

            while (primes[10000] == 0)
            {
                foreach(long currentPrime in primes)
                {
                    if (currentPrime == 0 || currentPrime > Math.Sqrt(numToCheck))
                    {
                        isPrime = true;
                        break;
                    }
                    else if (numToCheck % currentPrime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime == true)
                {
                    primes[currentPrimeIndex] = numToCheck;
                    currentPrimeIndex++;
                }

                numToCheck++;
            }

            return primes[10000];
        }
    }
}

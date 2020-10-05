using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 3.
    /// </summary>
    static class Problem3LargestPrimeFactor
    {
        /// <summary>
        /// Returns the answer to problem 3.
        /// </summary>
        /// <returns> The largets prime factor of 600851475143. </returns>
        public static long GetLargestPrimeFactor()
        {
            long num = 600851475143;
            long result = 0;

            if (UsefulFunctions.Divide(ref num, 2) != 0)
            {
                result = 2;
            }

            for (long i = 3; i <= num; i += 2) 
            {
                if (num % i == 0 && UsefulFunctions.IsPrime(i))
                {
                    UsefulFunctions.Divide(ref num, i);
                }

                if (num == 1)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}

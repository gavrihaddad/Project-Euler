using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem3LargestPrimeFactor
    {
        public static long GetLargestPrimeFactor()
        {
            long num = 600851475143;
            long result = 0;

            for (long i = 2; i <= num; i++)
            {
                if (UsefulFunctions.IsPrime(i) && num % i == 0)
                {
                    num /= i;

                    if (num == 1)
                    {
                        result = i;
                        break;
                    }

                    i--; //Because we want to check if num is divisible by i more than one time.
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// This class contains functions that are usful for more than 1 problem,
    /// and usful extention methods.
    /// </summary>
    public static class UsfulFunctions
    {
        public static bool IsPrime(long num)
        {
            if (num == 1)
            {
                return false;
            }

            for (long i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPalindrome(long num)
        {
            string numString = num.ToString();
            string numReversedString = numString.ReverseString();

            return numString == numReversedString;
        }

        public static string ReverseString(this String str)
        {
            string result = "";

            foreach(char c in str)
            {
                result = string.Concat(c, result);
            }

            return result;
        }

        /// <summary>
        /// Returns the prime factors of num.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>
        /// An array that contains the prime factors of num.
        /// In the i'th place, is the number of times that num is divisible by i.
        /// <returns>
        public static long[] GetPrimeFactors(long num)
        {
            long[] primeFactors = new long[num + 1];

            for (int i = 2; i <= Math.Floor(Math.Sqrt(num)) + 1; i++) 
            {
                if (num == 1)
                {
                    break;
                }
                if (IsPrime(num)) 
                {
                    primeFactors[num]++;
                    return primeFactors;
                }

                if (num % i == 0)
                {
                    long temp = num;

                    if(IsPrime(i))
                    {
                        primeFactors[i]++;

                        num /= i;
                    }
                    if (IsPrime(temp / i)) 
                    {
                        primeFactors[temp / i]++;

                        num /= (temp / i);
                    }

                    i--;
                }
            }

            return primeFactors;
        }
    }
}

using Project_Euler.Problems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    /// <summary>
    /// This class contains functions that are usful for more than 1 problem,
    /// and usful extention methods.
    /// </summary>
    public static class UsefulFunctions
    {
        /// <summary>
        /// Checks if a given number is prime.
        /// </summary>
        /// <param name="num"> The number to check. </param>
        /// <returns> True if num is prime, false otherwise. </returns>
        public static bool IsPrime(long num)
        {
            if (num == 1)                       // 1 is not prime.
            {
                return false;
            }
            if (num == 2)                       // 2 is prime.
            {
                return true;
            }
            if (num % 2 == 0)                   // Even numbers are not prime.
            {
                return false;
            }

            // Checking posible dividers (num is odd so we don't need to check for even dividers).
            for (long i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if a given number is prime, based on the primes before it
        /// (Allows a padding of zeroes in the end).
        /// </summary>
        /// <param name="num"> The number to check. </param>
        /// <param name="primes"> All the primes before num. </param>
        /// <returns> True if num is prime, false otherwise. </returns>
        public static bool IsPrimeFast(long num, long[] primes)
        {
            if (num == 1)
            {
                return false;
            }

            foreach (long prime in primes)
            {
                if (prime == 0 || prime > Math.Sqrt(num))
                {
                    return true;
                }
                if (num % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if a given number is prime, based on the primes before it
        /// (Allows a padding of zeroes in the end).
        /// </summary>
        /// <param name="num"> The number to check. </param>
        /// <param name="primes"> All the primes before num. </param>
        /// <returns> True if num is prime, false otherwise. </returns>
        public static bool IsPrimeFast(long num, List<long> primes)
        {
            if (num == 1)
            {
                return false;
            }

            foreach (long prime in primes)
            {
                if (prime == 0 || prime > Math.Sqrt(num))
                {
                    return true;
                }
                if (num % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }
    
        /// <summary>
        /// Checks if a given number is a palindrome.
        /// </summary>
        /// <param name="num"> The number to check. </param>
        /// <returns> True if num is a palindrome, false otherwise. </returns>
        public static bool IsPalindrome(long num)
        {
            string numString = num.ToString();
            string numReversedString = numString.ReverseString();

            return numString == numReversedString;
        }

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="str"> The string to reverse. </param>
        /// <returns> A new string that is made from
        /// str's characters from end to beginning. </returns>
        public static string ReverseString(this String str)
        {
            string result = "";

            foreach (char c in str)
            {
                result = string.Concat(c, result);
            }

            return result;
        }

        /// <summary>
        /// Returns the prime factors of a given number.
        /// </summary>
        /// <param name="num"> The number to factor. </param>
        /// <returns>
        /// An array that contains the prime factors of num.
        /// In the i'th place, is the number of times that num is divisible by i.
        /// <returns>
        public static Dictionary<long, int> GetPrimeFactors(long num)
        {
            Dictionary<long, int> primeFactors = new Dictionary<long, int>();
            long temp1 = num;

            for (int i = 2; i <= Math.Sqrt(temp1); i++)
            {
                if (num == 1)
                {
                    break;
                }
                if (IsPrime(num))
                {
                    primeFactors.Add(num, 1);
                    return primeFactors;
                }

                if (num % i == 0)
                {
                    if (i == num / i)
                    {
                        primeFactors.Add(i, Divide(ref num, i));
                    }
                    else
                    {
                        long temp2 = num;
                        if(IsPrime(i))
                        {
                            primeFactors.Add(i, Divide(ref num, i));
                        }
                        if (IsPrime(temp2 / i))
                        {
                            primeFactors.Add(temp2 / i, Divide(ref num, temp2 / i));
                        }
                    }
                }
            }

            return primeFactors;
        }

        /// <summary>
        /// Returns the prime factors of a given number.
        /// </summary>
        /// <param name="num"> The number to factor. </param>
        /// <returns>
        /// An array that contains the prime factors of num.
        /// In the i'th place, is the number of times that num is divisible by i.
        /// <returns>
        public static Dictionary<long, int> GetPrimeFactorsFast(long num, long[] primes)
        {
            Dictionary<long, int> primeFactors = new Dictionary<long, int>();
  
            foreach(long prime in primes)
            {
                if (num == 1) 
                {
                    break;
                }
                if (num % prime == 0)
                {
                    primeFactors.Add(prime, Divide(ref num, prime));
                }
            }

            return primeFactors;
        }

        /// <summary>
        /// Uses a formula to return the sum of the squers sequence up to a certain point.
        /// </summary>
        /// <param name="limit"> The last item in the squers sequence
        /// that will be includsed in the sum. </param>
        /// <returns> The sum of 1^2 + 2^2 + 3^2 +...+ limit^2 </returns>
        public static int SumOfSquersSequence(int limit)
        {
            return (limit * (limit + 1) * (2 * limit + 1)) / 6;
        }

        /// <summary>
        /// Calculates the sum of a given arithmetic sequence.
        /// </summary>
        /// <param name="beginning"> The first item in the sequence. </param>
        /// <param name="limit"> The index of the last array in the sequence. </param>
        /// <param name="difference"> The difference between two adjacent items of the sequence. </param>
        /// <returns> The sum of the sequence. </returns>
        public static int SumOfArithmeticSequence(int beginning, int limit, int difference)
        {
            return (limit * (2 * beginning + difference * (limit - 1))) / 2;
        }

        /// <summary>
        /// Divides num by divider as many times as possible.
        /// </summary>
        /// <param name="num"> The number to divide. </param>
        /// <param name="divider"> The number to divide num by. </param>
        /// <returns> The number of times num could be divided by divider. 
        /// Zero if num is not divisible by divisor. </returns>
        public static int Divide(ref long num, long divider)
        {
            int result = 0;

            while (num % divider == 0)
            {
                num /= divider;
                result++;
            }

            return result;
        }
    }
}

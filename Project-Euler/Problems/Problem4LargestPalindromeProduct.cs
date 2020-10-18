using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Euler.Helpers.UsefulFunctions;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 4.
    /// </summary>
    static class Problem4LargestPalindromeProduct
    {
        /// <summary>
        /// Returns the answer to problem 4.
        /// </summary>
        /// <returns> The largest product of two 3-digit numbers that is a palindrome. </returns>
        public static int GetLargestPalindromeProduct()
        {
            int largestPalindrome = 0;

            for (int i = 999; i >= 100; i--) 
            {
                for (int j = i; j >= 100; j--)
                {
                    if (i * j <= largestPalindrome) 
                    {
                        break;
                    }
                    if (IsPalindrome(i * j))
                    {
                        largestPalindrome = i * j;
                    }
                }
            }

            return largestPalindrome;
        }
    }
}
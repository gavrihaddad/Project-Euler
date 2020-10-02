using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem4LargestPalindromeProduct
    {
        public static int GetLargestPalindromeProduct()
        {
            List<int> palindromes = new List<int>();

            for (int i = 100; i < 1000; i++) 
            {
                for (int j = 100; j < 1000; j++)
                {
                    if (UsfulFunctions.IsPalindrom(i * j))
                    {
                        palindromes.Add(i * j);
                    }
                }
            }

            return palindromes.Max();
        }
    }
}
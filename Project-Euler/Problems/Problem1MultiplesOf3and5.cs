using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem1MultiplesOf3and5
    {
        /// <summary>
        /// Solves problem 1
        /// </summary>
        /// <returns> The sum of multiples of 3 or 5 bellow 1000 </returns>
        public static int GetSum()
        {
            return GetMultiplesOf3and5().Sum();
        }

        private static List<int> GetMultiplesOf3and5()
        {
            List<int> Multiples = new List<int>();

            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) 
                {
                    Multiples.Add(i);
                }

            }

            return Multiples;
        }
    }
}
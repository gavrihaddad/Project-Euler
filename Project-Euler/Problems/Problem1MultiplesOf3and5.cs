using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 1.
    /// </summary>
    static class Problem1MultiplesOf3and5
    {
        private static readonly int limit = 1000;

        /// <summary>
        /// Returns the answer to problem 1.
        /// </summary>
        /// <returns> The sum of multiples of 3 or 5 bellow 1000 </returns>
        public static int GetSum()
        {
            return GetMultiplesOf3and5().Sum();
        }

        private static List<int> GetMultiplesOf3and5()
        {
            List<int> Multiples = new List<int>();

            for (int i = 3; i < limit; i += 3) 
            {
                Multiples.Add(i);
            }
            for (int i = 5; i < limit; i += 5)
            {
                Multiples.Add(i);
            }
            for (int i = 15; i < limit; i += 15) 
            {
                Multiples.Remove(i);
            }

            return Multiples;
        }
    }
}
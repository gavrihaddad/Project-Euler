using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 9.
    /// </summary>
    class Problem9SpecialPythagoreanTriplet
    {
        /// <summary>
        /// Returns the answer to problem 9.
        /// </summary>
        /// <returns> The mult of the 3 numbers a,b,c that are a Pythagorean Triplet and add up to 1000. </returns>
        public static int GetMult()
        {
            int result = 0;

            for (int a = 1; a < 333; a++)  //a=333 => minb=334 => minc=335 => a+b+c=1001 => no point to continue.
            {
                for (int b = a + 1; b < 500; b++) //b=500 => minc=501 => b+c=1001 => no point to continue.
                {
                    int c = 1000 - a - b;

                    if (c <= b) //The triplet is a < b < c => no point to continue.
                    {
                        break;
                    }

                    if (IsPythagoreanTriplet(a, b, c))
                    {
                        return a * b * c;
                    }
                }
            }

            return result;
        }

        private static bool IsPythagoreanTriplet(int a, int b, int c)
        {
            return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    public static class Problem15LatticePaths
    {
        /// <summary>
        /// The algorithm is very simple.
        /// Moveing from the top left corner to the bottom right corner
        /// of a 20x20 grid takes 40 steps - 20 in the right direction,
        /// and 20 in the down direction. All we have to do, is to find out
        /// how many options we have to place 20 downs in the
        /// 40-steps sequence (the rights will then be automatically
        /// placed in the remaining places).
        /// Choosing 20 places out of 40 perfectlly matches the
        /// N chhose K formula in combinatorics, which is 40!/(20!*20!).
        /// The first 20 elements in the numerator are reduced by the
        /// first 20! in the denominator, and then we are left with
        /// 21*22*...*40/20!, and that is what we calculate.
        /// </summary>
        /// <returns></returns>
        public static long GetAnswer()
        {
            long answer = 1;

            for (int i = 21, j = 1; i <= 40; i++, j++) 
            {
                answer *= i;
                answer /= j;
            }

            return answer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project_Euler.Helpers.UsefulFunctions;

namespace Project_Euler.Problems
{
    /// <summary>
    /// Solves problem 6.
    /// </summary>
    static class Problem6SumSquareDifference
    {
        /// <summary>
        /// Retruns the answer to problem 6.
        /// </summary>
        /// <returns>
        /// The difference between the squer of the sum of the 1-100 range,
        /// and the sum of the squers of 1-100. 
        /// </returns>
        public static int GetDifference()
        {
            return (int)Math.Pow(SumOfArithmeticSequence(1, 100, 1), 2) - 
                                 SumOfSquersSequence(100);
        }
    }
}

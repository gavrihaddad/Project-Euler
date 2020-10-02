using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    static class Problem6SumSquareDifference
    {
        public static int GetDifference()
        {
            return (int)Math.Pow(UsefulFunctions.SumOfArithmeticSequence(1, 100, 1), 2) - 
                                 UsefulFunctions.SumOfSquersSequence(100);
        }
    }
}

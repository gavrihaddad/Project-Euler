using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// This class contains functions that are usful for more than 1 problem.
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
    }
}

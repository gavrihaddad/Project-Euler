using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    public static class Problem14LongestCollatzSequence
    {
        private static readonly List<int> candidates = Enumerable.Range(2, 9).ToList();


        #region Brute force

        public static int GetNum1()
        {
            int result = 0;
            int maxLength = 0;

            for (int i = 500001; i <= 1000000; i++)
            {
                long num = i;
                int length = 0;

                while (num != 1)
                {
                    length++;

                    num = GetNext(num);
                }

                if (maxLength < length)
                {
                    maxLength = length;
                    result = i;
                }
            }

            return result;

            long GetNext(long num)
            {
                if (num % 2 == 0)
                {
                    return num / 2;
                }
                else
                {
                    return num * 3 + 1;
                }
            }
        }

        #endregion
    }
}

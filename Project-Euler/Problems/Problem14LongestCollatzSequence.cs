using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    public static class Problem14LongestCollatzSequence
    {
        #region Brute force

        public static int GetNum1()
        {
            int result = 0;
            int maxLength = 0;

            // All the numbers from 1 to 500000 can be multiplied by 2
            // a certain amount of times and end up in an even number in
            // the 500001-1000000 range, therfore they cannot have the
            // longest sequence (because the coresponding number is even,
            // so the next step will be to divide it by 2, and so on until
            // we get to the number we started from in the 1-500000 range).
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
        }

        #endregion


        public static int GetNum2()
        {
            Dictionary<long, int> lengths = new Dictionary<long, int>();

            int result = 0;
            int maxLength = 0;

            // Look in GetNum1 for an explenation.
            for (int i = 500001; i <= 1000000; i++)
            {
                long num = i;
                int length = 0;
                List<long> trail = new List<long>();

                while (num != 1)
                {
                    if (lengths.ContainsKey(num))
                    {
                        length += lengths[num];

                        for (int j = 0; j < trail.Count; j++)
                        {
                            lengths[trail[j]] += lengths[num];
                        }

                        break;
                    }


                    length++;

                    trail.Add(num);
                    for (int j = 0; j < trail.Count; j++)
                    {
                        if (lengths.ContainsKey(trail[j]))
                        {
                            lengths[trail[j]]++;
                        }
                        else
                        {
                            lengths.Add(trail[j], 1);
                        }
                    }

                    num = GetNext(num);
                }

                if (length > maxLength) 
                {
                    maxLength = length;
                    result = i;
                }
            }

            return result;
        }

        private static long GetNext(long num)
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
}

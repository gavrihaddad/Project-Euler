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


        #region Memory Based Algorithm

        public static int GetNum2()
        {
            Dictionary<long, MyList<long>> trails = new Dictionary<long, MyList<long>>();

            int result = 0;
            int maxLength = 0;

            // Like in the first solution we could start at 500001,
            // but testing shows that it actually works faster like that,
            // because it rules out the lower numbers faster.
            for (int i = 1; i <= 1000000; i++)
            {
                long num = i;
                trails.Add(i, new MyList<long>());

                while (num != 1)
                {
                    if (trails.ContainsKey(num) && trails[num].MyCount != 0)
                    {
                        trails[i].MyCount = trails[num].MyCount;

                        break;
                    }

                    trails[i].Add(num);

                    num = GetNext(num);
                }

                if (trails[i].MyCount > maxLength)
                {
                    maxLength = trails[i].MyCount;
                    result = i;
                }
            }

            return result;
        }

        private class MyList<T> : List<T>
        {
            private int myCount = 0;

            /// <summary>
            /// This property is used to control the Count property of List<T>.
            /// It allows you to change Count without changing the actual number
            /// of items in the List<T>, which is very useful in this
            /// particular method.
            /// </summary>
            public int MyCount
            {
                get => myCount + Count;
                set => myCount = value;
            }
        }

        #endregion

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
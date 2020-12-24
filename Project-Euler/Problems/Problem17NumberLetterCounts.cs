using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    public static class Problem17NumberLetterCounts
    {
        private static Dictionary<int, string> numbersLengths;

        static Problem17NumberLetterCounts()
        {
            numbersLengths = new Dictionary<int, string>
            {
                {1,  "one" },
                {2,  "two" },
                {3,  "three" },
                {4,  "four" },
                {5,  "five" },
                {6,  "six" },
                {7,  "seven" },
                {8,  "eight" },
                {9,  "nine" },
                {10, "ten" },

                {11, "eleven" },
                {12, "twelve" },
                {13, "thirteen" },
                {14, "fourteen" },
                {15, "fifteen" },
                {16, "sixteen" },
                {17, "seventeen" },
                {18, "eighteen" },
                {19, "nineteen" },

                {20, "twenty" },
                {30, "thirty" },
                {40, "forty" },
                {50, "fifty" },
                {60, "sixty" },
                {70, "seventy" },
                {80, "eighty" },
                {90, "ninety" },

                {100, "hundred" },
                {1000, "thousand" }
            };
        }



        public static int GetLength()
        {
            return OneTo999 + numbersLengths[1].Length
                            + numbersLengths[1000].Length;
        }

        private static int OneTo999
        {
            get
            {
                int lenght = OneTo99;

                for (int i = 1; i <= 9; i++)
                {
                    lenght += (numbersLengths[i].Length + 
                               numbersLengths[100].Length) * 100 +
                               "and".Length * 99 + OneTo99;
                }

                return lenght;
            }
        }

        private static int OneTo99
        {
            get
            {
                int lenght = 0;

                for (int i = 1; i <= 19; i++)
                {
                    lenght += numbersLengths[i].Length;
                }

                for (int i = 20; i <= 90; i += 10)
                {
                    lenght += numbersLengths[i].Length * 10 + OneTo9;
                }

                return lenght;
            }
        }

        private static int OneTo9
        {
            get
            {
                int length = 0;
                for (int i = 1; i <= 9; i++)
                {
                    length += numbersLengths[i].Length;
                }

                return length;
            }
        }
    }
}

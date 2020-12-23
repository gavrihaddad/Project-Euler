using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    public static class Problem16PowerDigitSum
    {
        public static int SumOfDigits()
        {
            int result = 0;

            string num = "1";
            for (int i = 0; i < 1000; i++)
            {
                num = multByTwo(num);
            }

            foreach (char digit in num)
            {
                result += int.Parse(digit.ToString());
            }

            return result;
        }

        private static string multByTwo(string num)
        {
            string result = "";
            int carry = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                int digitMult = int.Parse(num[i].ToString()) * 2;
                int digitResult = digitMult % 10 + carry;
                carry = digitMult / 10;

                result = string.Concat(digitResult.ToString(), result);
            }

            if (carry != 0)
            {
                result = string.Concat(carry.ToString(), result);
            }
            return result;
        }
    }
}

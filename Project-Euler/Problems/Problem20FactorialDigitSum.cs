using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Problems
{
    public static class Problem20FactorialDigitSum
    {
        public static int GetFactorialDigitSum()
        {
            List<int> numbers = Enumerable.Range(1, 100).ToList();

            string factorial = MultList(numbers);
            int sum = 0;
            for (int i = 0; i < factorial.Length; i++)
            {
                sum += int.Parse(factorial[i].ToString());
            }

            return sum;
        }

        private static string MultList(List<int> nums)
        {
            if (nums.Count == 1)
            {
                return nums[0].ToString();
            }
            else
            {
                return Mult(nums[0].ToString(), MultList(nums.GetRange(1, nums.Count - 1)));
            }
        }

        private static string Mult(string num1, string num2)
        {
            if (num1.Length < num2.Length)
            {
                string temp = num1;
                num1 = num2;
                num2 = temp;
            }

            List<string> subMults = new List<string>();

            for (int i = num2.Length - 1; i >= 0; i--)
            {
                int carry = 0;
                string subMult = new string('0', num2.Length - 1 - i);
                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    int mult = int.Parse(num2[i].ToString()) * int.Parse(num1[j].ToString());
                    int res = (mult % 10 + carry) % 10;

                    subMult = res.ToString() + subMult;

                    carry = mult / 10 + (mult % 10 + carry) / 10;
                }

                if (carry != 0)
                {
                    subMult = carry + subMult;
                }

                subMults.Add(subMult);
            }

            return SumList(subMults);
        }

        private static string SumList(List<string> nums)
        {
            if (nums.Count == 1)
            {
                return nums[0];
            }
            else
            {
                return Sum(nums[0], SumList(nums.GetRange(1, nums.Count - 1)));
            }
        }

        private static string Sum(string num1, string num2)
        {
            if (num1.Length < num2.Length)
            {
                string temp = num1;
                num1 = num2;
                num2 = temp;
            }

            while (num2.Length < num1.Length)
            {
                num2 = '0' + num2;
            }

            int carry = 0;
            string sum = "";
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int subSum = int.Parse(num1[i].ToString()) + int.Parse(num2[i].ToString());
                int res = (subSum % 10 + carry) % 10;

                sum = res + sum;

                carry = (subSum + carry) / 10;
            }

            if (carry != 0)
            {
                sum = carry + sum;
            }

            return sum;
        }
    }
}
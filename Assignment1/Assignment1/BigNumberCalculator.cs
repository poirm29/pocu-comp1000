using System;
using System.Text;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public BigNumberCalculator(int bitCount, EMode mode)
        {
        }

        public static string GetOnesComplementOrNull(string num)
        {
            if (!num.StartsWith("0b"))
            {
                return null;
            }
            if (num == "0b")
            {
                return null;
            }
            for (int i = 2; i < num.Length; i++)
            {
                if (!(num[i] == '0' || num[i] == '1'))
                {
                    return null;
                }
            }

            StringBuilder sb = new StringBuilder("0b",num.Length);

            for (int i = 2; i < num.Length; i++)
            {
                if (num[i] == '0')
                {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }
            }

            string numOnesComplement = sb.ToString();

            return numOnesComplement;
        }

        public static string GetTwosComplementOrNull(string num)
        {
            if (!num.StartsWith("0b"))
            {
                return null;
            }
            if (num == "0b")
            {
                return null;
            }
            for (int i = 2; i < num.Length; i++)
            {
                if (!(num[i] == '0' || num[i] == '1'))
                {
                    return null;
                }
            }

            StringBuilder sb = new StringBuilder("0b", num.Length);

            for (int i = 2; i < num.Length; i++)
            {
                if (num[i] == '0')
                {
                    sb.Append('1');
                }
                else
                {
                    sb.Append('0');
                }
            }

            int count = 0;
            for (int i = sb.Length - 1; i > 1; i--)
            {
                if (sb[i] == '1')
                {
                    count++;
                }
                else
                {
                    sb.Replace('1', '0', i, sb.Length - 1);
                }
            }

            string numTwosComplement = sb.ToString();

            return numTwosComplement;
        }

        public static string ToBinaryOrNull(string num)
        {
            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            return null;
        }

        public static string ToHexOrNull(string num)
        {
            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }
    }
}
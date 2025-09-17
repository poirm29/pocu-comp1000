using System;
using System.Collections.Generic;
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

            return sb.ToString();
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

            for (int i = sb.Length - 1; i > 1; i--)
            {
                if (sb[i] == '1')
                {
                    sb[i] = '0';
                }
                else
                {
                    sb[i] = '1';
                    break;
                }
            }

            return sb.ToString();
        }

        public static string ToBinaryOrNull(string num)
        {
            if (num.StartsWith("0b"))
            {
                if (num == "0b")
                {
                    return null;
                }

                else
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(num[i] == '0' || num[i] == '1'))
                        {
                            return null;
                        }
                    }
                }

                return num;
            }

            else if (num.StartsWith("0x"))
            {
                if (num == "0x")
                {
                    return null;
                }

                else
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(('0' <= num[i] && num[i] <= '9') || ('A' <= num[i] && num[i] <= 'F')))
                        {
                            return null;
                        }
                    }
                }

                StringBuilder sb = new StringBuilder("0b", num.Length * 4);

                for (int i = 2; i < num.Length; i++)
                {
                    string convertedBinaryToken = HexNumDictionary(num[i]);

                    sb.Append(convertedBinaryToken);
                }

                return sb.ToString(); 
            }

            else
            {
                int decNum = 0;

                if (!int.TryParse(num, out decNum))
                {
                    return null;
                }

                if (decNum >= 0)
                {
                    StringBuilder sb = new StringBuilder();

                    int remainder = 0;
                    while (true)
                    {
                        if (decNum == 1)
                        {
                            sb.Append('1');
                            break;
                        }
                        remainder = decNum % 2;
                        if (remainder == 1)
                        {
                            sb.Append('1');
                        }
                        else
                        {
                            sb.Append('0');
                        }
                        decNum = decNum / 2;
                    }

                    sb.Append('0');
                    sb.Append('b');
                    sb.Append('0');

                    string reversedResult = sb.ToString();

                    StringBuilder resultSb = new StringBuilder();

                    for (int i = reversedResult.Length - 1; i >= 0; i--)
                    {
                        resultSb.Append(reversedResult[i]);
                    }

                    return resultSb.ToString();
                }

                else
                {
                    decNum = ~decNum;
                    decNum += 1;

                    StringBuilder sb = new StringBuilder();

                    int remainder = 0;
                    while (true)
                    {
                        if (decNum == 1)
                        {
                            sb.Append('1');
                            break;
                        }
                        remainder = decNum % 2;
                        if (remainder == 1)
                        {
                            sb.Append('1');
                        }
                        else
                        {
                            sb.Append('0');
                        }
                        decNum = decNum / 2;
                    }

                    sb.Append('0');
                    sb.Append('b');
                    sb.Append('0');

                    string reversedResult = sb.ToString();

                    StringBuilder resultSb = new StringBuilder();

                    for (int i = reversedResult.Length - 1; i >= 0; i--)
                    {
                        resultSb.Append(reversedResult[i]);
                    }

                    string result = GetTwosComplementOrNull(resultSb.ToString());

                    return result;
                }
            }
        }

        public static string ToDecimalOrNull(string num)
        {
            if (num.StartsWith("0b"))
            {
                if (num == "0b")
                {
                    return null;
                }

                else
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(num[i] == '0' || num[i] == '1'))
                        {
                            return null;
                        }
                    }
                }

                if (num[2] == '0')
                {
                    int result = 0;
                    int twoMltiplier = 1;

                    for (int i = num.Length - 1; i >= 0; i--)
                    {
                        if (num[i] == '1')
                        {
                            result += twoMltiplier;
                        }
                        twoMltiplier *= 2;
                    }

                    return result.ToString();
                }
                else
                {
                    string twosComplentNum = GetTwosComplementOrNull(num);

                    int result = 0;
                    int twoMltiplier = 1;

                    for (int i = num.Length - 1; i >= 0; i--)
                    {
                        if (num[i] == '1')
                        {
                            result += twoMltiplier;
                        }
                        twoMltiplier *= 2;
                    }

                    result = ~result;
                    result = result + 1;

                    return result.ToString();
                }
            }

            else if (num.StartsWith("0x"))
            {
                if (num == "0x")
                {
                    return null;
                }

                else
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(('0' <= num[i] && num[i] <= '9') || ('A' <= num[i] && num[i] <= 'F')))
                        {
                            return null;
                        }
                    }
                }

                string binaryString = ToBinaryOrNull(num);

                return ToDecimalOrNull(binaryString);
            }

            else
            {
                return num;
            }
        }

        public static string ToHexOrNull(string num)
        {
            if (num.StartsWith("0b"))
            {
                if (num == "0b")
                {
                    return null;
                }

                else
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(num[i] == '0' || num[i] == '1'))
                        {
                            return null;
                        }
                    }
                }

                StringBuilder sb = new StringBuilder("0x", num.Length);
            }
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

        public static string HexNumDictionary(char num)
        {
            Dictionary<char, string> HexDictionary = new Dictionary<char, string>()
            {
                {'0', "0000"},
                {'1', "0001"},
                {'2', "0010"},
                {'3', "0011"},
                {'4', "0100"},
                {'5', "0101"},
                {'6', "0110"},
                {'7', "0111"},
                {'8', "1000"},
                {'9', "1001"},
                {'A', "1010"},
                {'B', "1011"},
                {'C', "1100"},
                {'D', "1101"},
                {'E', "1110"},
                {'F', "1111"}
            };

            string result = "";

            if (HexDictionary.TryGetValue(num, out result))
            {
                return result;
            }

            return null;
        }

        public static char BinNumDictionary(string num)
        {
            Dictionary<string, char> HexDictionary = new Dictionary<string, char>()
            {
                {"0000", '0'},
                {"0001", '1'},
                {"0010", '2'},
                {"0011", '3'},
                {"0100", '4'},
                {"0101", '5'},
                {"0110", '6'},
                {"0111", '7'},
                {"1000", '8'},
                {"1001", '9'},
                {"1010", 'A'},
                {"1011", 'B'},
                {"1100", 'C'},
                {"1101", 'D'},
                {"1110", 'E'},
                {"1111", 'F'}
            };

            char result = ' ';

            if (HexDictionary.TryGetValue(num, out result))
            {
                return result;
            }

            return 'X';
        }
    }
}
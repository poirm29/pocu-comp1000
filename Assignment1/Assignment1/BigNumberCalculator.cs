using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public int BitCount;
        public EMode Mode;
        public BigNumberCalculator(int bitCount, EMode mode)
        {
            BitCount = bitCount;
            Mode = mode;
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
            if (!IsItValidNumFormat(num))
            {
                return null;
            }
            
            if (num.StartsWith("0b"))
            {
                return num;
            }

            else if (num.StartsWith("0x"))
            {
                StringBuilder sb = new StringBuilder("0b");

                for (int i = 2; i < num.Length; i++)
                {
                    string convertedBinaryToken = HexNumDictionary(num[i]);

                    sb.Append(convertedBinaryToken);
                }
                return sb.ToString(); 
            }

            else
            {
                StringBuilder binSb = new StringBuilder("0b");
                StringBuilder divideNumSb = new StringBuilder();

                string positiveNum;
                bool bPostive = true;

                if (num[0] == '-')
                {
                    positiveNum = num.Remove(0, 1);

                    bPostive = false;
                }
                else
                {
                    positiveNum = num;
                }

                DivideRecursive(positiveNum, divideNumSb, binSb);

                binSb.Insert(2, 0);

                if (!bPostive)
                {
                    return GetTwosComplementOrNull(binSb.ToString());
                }
                else
                {
                    return binSb.ToString();
                }
            }
        }

        public static string ToDecimalOrNull(string num)
        {
            if (!IsItValidNumFormat(num))
            {
                return null;
            }

            if (num.StartsWith("0b"))
            {
                bool bPositive = true;
                string positiveNum;

                if (num[2] == '1')
                {
                    bPositive = false;
                }

                if (!bPositive)
                {
                    positiveNum = GetTwosComplementOrNull(num);
                }

                StringBuilder sb = new StringBuilder();

                string multipliedNum ="1";
                int multiplyCount = 0;
                string sumOfNum = "0";

                for (int i = num.Length - 1; i > 2; i--)
                {
                    if (num[i] == '1')
                    {
                        if (i == num.Length - 1)
                        {
                            multipliedNum = "1";
                        }
                        else
                        {
                            for (int j = 0; j < multiplyCount; j++)
                            {
                                MultiplyTwoString(multipliedNum, sb);

                                multipliedNum = sb.ToString();
                            }
                        }
                        sb.Clear();
                        AddString(sumOfNum, multipliedNum, sb);

                        sumOfNum = sb.ToString();
                    }

                    multipliedNum = "1";
                    sb.Clear();
                    multiplyCount++;
                }

                if(!bPositive)
                {
                    sumOfNum = "-" + sumOfNum;
                }

                return sumOfNum;
            }

            else if (num.StartsWith("0x"))
            {
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
            if (!IsItValidNumFormat(num))
            {
                return null;
            }

            if (num.StartsWith("0b"))
            {
                StringBuilder sb = new StringBuilder("0x");

                int count = 0;
                int sumOfBits = 0;
                int twoMltiplier = 1;

                char hexChar = ' ';

                if (num[2] == '1')
                {
                    for (int i = num.Length - 1; i > 1; i--)
                    {
                        if (count < 3 && i == 2)
                        {
                            while (count < 4)
                            {
                                sumOfBits += twoMltiplier;

                                hexChar = HexNumDictionary(sumOfBits);

                                twoMltiplier *= 2;
                                count++;
                            }
                            sb.Insert(2, hexChar);
                            break;
                        }

                        else if (num[i] == '1')
                        {
                            sumOfBits += twoMltiplier;
                            twoMltiplier *= 2;
                            count++;
                        }

                        else
                        {
                            twoMltiplier *= 2;
                            count++;
                        }

                        if (count == 4)
                        {
                            hexChar = HexNumDictionary(sumOfBits);
                            sb.Insert(2, hexChar);

                            count = 0;
                            sumOfBits = 0;
                            twoMltiplier = 1;
                        }


                    }

                    return sb.ToString();
                }

                else if (num.StartsWith("0x"))
                {
                    return num;
                }

                else
                {
                    for (int i = num.Length - 1; i > 1; i--)
                    {
                        if (count < 4 && i == 2)
                        {
                            hexChar = HexNumDictionary(sumOfBits);
                            sb.Insert(2, hexChar);

                            break;
                        }

                        else if (num[i] == '1')
                        {
                            sumOfBits += twoMltiplier;
                            twoMltiplier *= 2;
                            count++;
                        }

                        else
                        {
                            twoMltiplier *= 2;
                            count++;
                        }

                        if (count == 4)
                        {
                            hexChar = HexNumDictionary(sumOfBits);
                            sb.Insert(2, hexChar);

                            count = 0;
                            sumOfBits = 0;
                            twoMltiplier = 1;
                        }
                    }

                    return sb.ToString();
                }
            }

            else
            {
                string binNum = ToBinaryOrNull(num);

                return ToHexOrNull(binNum);
            }
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            if (!IsInputInBitCount(num1, BitCount) || !IsInputInBitCount(num2, BitCount))
            {
                bOverflow = false;
                return null;
            }

            string binNum1StartWith0b = ToBinaryOrNull(num1);
            string binNum2StartWith0b = ToBinaryOrNull(num2);

            StringBuilder num1Sb = new StringBuilder();
            StringBuilder num2Sb = new StringBuilder();

            for (int i = 2; i < binNum1StartWith0b.Length; i++)
            {
                num1Sb.Append(binNum1StartWith0b[i]);
            }
            for (int i = 2; i < binNum2StartWith0b.Length; i++)
            {
                num2Sb.Append(binNum2StartWith0b[i]);
            }

            if (num1Sb.Length > num2Sb.Length)
            {
                while (num1Sb.Length > num2Sb.Length)
                {
                    num2Sb.Insert(0, num2Sb[0]);
                }
            }
            else
            {
                while (num2Sb.Length > num1Sb.Length)
                {
                    num1Sb.Insert(0, num1Sb[0]);
                }
            }

            string binNum1 = num1Sb.ToString();
            string binNum2 = num2Sb.ToString();

            StringBuilder addResultSb = new StringBuilder();

            int carryNum = 0;
            int digitNum = 0;

            int previousLastCarryNum = 0;

            bOverflow = false;

            for (int i = binNum1.Length - 1; i >= 0; i--)
            {
                digitNum = binNum1[i] ^ binNum2[i];

                digitNum += carryNum;

                if (digitNum == 2)
                {
                    digitNum = 0;
                }

                if (binNum1[i] == '1' && binNum2[i] == '1')
                {
                    carryNum = 1;
                }
                else if (binNum1[i] == '1' && carryNum == 1)
                {
                    carryNum = 1;
                }
                else if (binNum2[i] == '1' && carryNum == 1)
                {
                    carryNum = 1;
                }
                else
                {
                    carryNum = 0;
                }

                if (digitNum == 0)
                {
                    addResultSb.Insert(0, '0');
                }
                else
                {
                    addResultSb.Insert(0, '1');
                }

                if (i == 1)
                {
                    previousLastCarryNum = carryNum;
                }
            }

            bool bCarried1 = false;
            bool bCarried2 = true;
            if (previousLastCarryNum == 1)
            {
                bCarried1 = true;
            }
            else
            {
                bCarried1 = false;
            }

            if (carryNum == 1)
            {
                bCarried2 = true;
            }
            else
            {
                bCarried2 = false;
            }

            bOverflow = bCarried1 ^ bCarried2;

            StringBuilder sb = new StringBuilder("0b");

            switch (Mode)
            {
                case EMode.Decimal:
                    for (int i = 0; i < addResultSb.Length; i++)
                    {
                        sb.Append(addResultSb[i]);
                    }

                    return ToDecimalOrNull(sb.ToString());
                case EMode.Binary:
                    for (int i = 0; i < addResultSb.Length; i++)
                    {
                        sb.Append(addResultSb[i]);
                    }

                    return sb.ToString();
            }

            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public static string HexNumDictionary(char num)
        {
            Dictionary<char, string> hexDictionary = new Dictionary<char, string>()
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

            if (hexDictionary.TryGetValue(num, out result))
            {
                return result;
            }

            return null;
        }

        public static char HexNumDictionary(int num)
        {
            Dictionary<int, char> hexDictionary = new Dictionary<int, char>()
            {
                {0, '0'},
                {1, '1'},
                {2, '2'},
                {3, '3'},
                {4, '4'},
                {5, '5'},
                {6, '6'},
                {7, '7'},
                {8, '8'},
                {9, '9'},
                {10, 'A'},
                {11, 'B'},
                {12, 'C'},
                {13, 'D'},
                {14, 'E'},
                {15, 'F'}
            };

            char result = ' ';

            if (hexDictionary.TryGetValue(num, out result))
            {
                return result;
            }

            return ' ';
        }

        public static bool IsItValidNumFormat(string num)
        {
            if (num.StartsWith("0b"))
            {
                if (num.Length >= 3)
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(num[i] == '0' || num[i] == '1'))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            else if (num.StartsWith("0x"))
            {
                if (num.Length >= 3)
                {
                    for (int i = 2; i < num.Length; i++)
                    {
                        if (!(('0' <= num[i] && num[i] <= '9') || ('A' <= num[i] && num[i] <= 'F')))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            else if (num.StartsWith('-'))
            {
                if (num.Length >= 2)
                {
                    if (num[1] != '0')
                    {
                        for (int i = 1; i < num.Length; i++)
                        {
                            if (!(48 <= num[i] && num[i] <= 57)) // each element '0' ~ '9'check
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }

            else
            {
                if (num.Length >= 1)
                {
                    if (!num.StartsWith('0'))
                    {
                        for (int i = 0; i < num.Length; i++)
                        {
                            if (!(48 <= num[i] && num[i] <= 57)) // each element '0' ~ '9'check
                            {
                                return false;
                            }
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsInputInBitCount(string num, int bitCount)
        {
            string binNum = ToBinaryOrNull(num);

            if (binNum.Length - 2 > bitCount)
            {
                return false;
            }

            return true;
        }

        public static void DivideRecursive(string num, StringBuilder dividedNumSb, StringBuilder binSb)
        {
            if (dividedNumSb.ToString() == "1")
            {
                binSb.Insert(2, "1");

                return;
            }

            int eachDigit = 0;
            int eachQuotient = 0;
            int eachRemainder = 0;

            dividedNumSb.Clear();

            if (num[0] != '-')
            {
                for (int i = 0; i < num.Length; i++)
                {
                    const int DEVISOR_TWO = 2;

                    eachDigit = num[i] - 48;

                    if (eachRemainder == 1)
                    {
                        eachDigit += 10;
                    }

                    eachQuotient = eachDigit / DEVISOR_TWO;
                    eachRemainder = eachDigit % DEVISOR_TWO;

                    if (!(i == 0 && eachQuotient == 0))
                    {
                        dividedNumSb.Append(eachQuotient);
                    }
                }

                binSb.Insert(2, eachRemainder.ToString());
            }
            DivideRecursive(dividedNumSb.ToString(), dividedNumSb, binSb);
        }

        public static void MultiplyTwoString(string num, StringBuilder multipliedSb)
        {
            const int MULTIPLY_NUM = 2;
            const int ASCII_TO_NUM = 48;

            multipliedSb.Clear();

            int roundNum = 0;
            int digitNum = 0;
            int multipliedNum = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                digitNum = num[i] - ASCII_TO_NUM;

                multipliedNum = digitNum * MULTIPLY_NUM + roundNum;

                if (digitNum >= 5)
                {
                    roundNum = 1;
                    if (i != 0)
                    {
                        multipliedNum -= 10;
                    }
                }
                else
                {
                    roundNum = 0;
                }

                multipliedSb.Insert(0, multipliedNum.ToString());
            }

            return;
        }

        public static void AddString(string num1, string num2, StringBuilder resultSb)
        {
            const int ASCII_TO_NUM = 48;

            resultSb.Clear();

            string longNum = num1;
            string shortNum = num2;

            if (num1.Length > num2.Length)
            {
            }
            else
            {
                longNum = num2;
                shortNum = num1;
            }

            resultSb.Append(shortNum);

            for (int i = 0; i < longNum.Length - shortNum.Length; i++)
            {
                resultSb.Insert(0, '0');
            }

            string fillUpZeroShortNum = resultSb.ToString();

            resultSb.Clear();

            int round = 0;
            int shortLength = 0;
            int longLength = 0;

            shortLength = shortNum.Length;
            longLength = longNum.Length;


            int digitNum1 = 0;
            int digitNum2 = 0;
            int sumOfDigit = 0;

            for (int i = longNum.Length - 1; i >= 0; i--)
            {
                digitNum1 = longNum[i] - ASCII_TO_NUM;
                digitNum2 = fillUpZeroShortNum[i] - ASCII_TO_NUM;

                sumOfDigit = digitNum1 + digitNum2 + round;

                if (sumOfDigit >= 10)
                {
                    round = 1;
                    if (i != 0)
                    {
                        sumOfDigit -= 10;
                    }
                }
                else
                {
                    round = 0;
                }
                resultSb.Insert(0, sumOfDigit.ToString());
            }

            return;
        }
    }
}
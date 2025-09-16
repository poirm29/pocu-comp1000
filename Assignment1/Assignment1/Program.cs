using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {   
            string num1 = "0b0100101101";
            string num2 = "koihjowr";
            string num3 = "0b";
            string num4 = "0b3";
            string num5 = "0x1F";
            string num6 = "0b10000000000";
            string num7 = "0b10000100000";
            string num8 = "5463456";
            string num9 = "00002";
            string num10 = "12F";

            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num1));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num2));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num3));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num4));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num5));
            Console.WriteLine("---------------- Test GetOnesComplementOrNull");
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num1));
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num2));
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num3));
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num4));
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num5));
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num6));
            Console.WriteLine(BigNumberCalculator.GetTwosComplementOrNull(num7));
            Console.WriteLine("---------------- Test GetTwosComplementOrNull");
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull(num1));
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull(num5));
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull(num8));
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull(num9));
            Console.WriteLine(BigNumberCalculator.ToBinaryOrNull(num10));
            Console.WriteLine("---------------- Test ToBinaryOrNull");
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull(num1));
            Console.WriteLine(BigNumberCalculator.ToDecimalOrNull(num5));
            Console.WriteLine("---------------- Test ToDecimalOrNull");
        }
    }
}
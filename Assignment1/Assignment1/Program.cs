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
            string num5 = "0x1";

            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num1));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num2));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num3));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num4));
            Console.WriteLine(BigNumberCalculator.GetOnesComplementOrNull(num5));
        }
    }
}

using System.Diagnostics;
using System;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            string num1 = "0b110101111";

            StringBuilder sb = new StringBuilder();

            string result = BigNumberCalculator.ToDecimalOrNull(num1);

            Console.WriteLine(result);
        }
    }
}
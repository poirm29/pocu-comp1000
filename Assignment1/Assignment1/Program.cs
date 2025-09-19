using System.Diagnostics;
using System;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "12948108495853200423094230984230948203948230942329";
            string b = "954540509283509284029349023480293840923840923580924684309683096834096545835305";

            StringBuilder sb = new StringBuilder();

            BigNumberCalculator.AddString(a, b, sb);

            string result = sb.ToString();

            Console.WriteLine(result);
        }
    }
}
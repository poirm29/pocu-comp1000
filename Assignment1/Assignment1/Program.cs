using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("98126759182561928581230928130213131231251029571209571205124") == "98126759182561928581230928130213131231251029571209571205124");
            Debug.Assert(BigNumberCalculator.ToDecimalOrNull("-98126759182561928581230928130213131231251029571209571205124") == "-98126759182561928581230928130213131231251029571209571205124");
        }
    }
}
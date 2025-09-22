using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiSet first = new MultiSet();

            string element1 = "aand";
            string element2 = "kakaoa";

            first.Add(element1);
            first.Add(element2);

            Console.WriteLine($"First element is {first.ToList()[0]}");
            Console.WriteLine($"Second element is {first.ToList()[1]}");

            first.Remove(element1);

            Console.WriteLine($"After remove First element is {first.ToList()[0]}");


        }
    }
}

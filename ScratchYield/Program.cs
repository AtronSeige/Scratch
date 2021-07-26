using System;
using System.Collections.Generic;

namespace ScratchYield
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach(var s in GetNext1())
            //{
            //    Console.WriteLine(s);
            //}

            //foreach (var i in GetNext2())
            //{
            //    Console.WriteLine(i.ToString());
            //}

            foreach (var i in GetNext3())
            {
                Console.WriteLine(i.ToString());
            }

            Console.ReadLine();
        }

        private static IEnumerable<string> GetNext1()
        {
            yield return "One";
            yield return "Two";
            yield return "Three";
            yield return "Four";
            yield return "Five";
            yield return "Six";
        }

        private static IEnumerable<int> GetNext2()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
        }

        private static IEnumerable<int> GetNext3()
        {
            var i = 1;

            while (i < 10)
            {
                yield return i++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchRandom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //for (int i = 1; i < 11; i++)
            //{
            //	Console.WriteLine("Min: {0} Max: {1}", GetMinInt32(i), GetMaxInt32(i));
            //}
            //Console.WriteLine("Min: {0} Max: {1}", GetMin(2), GetMax(2));
            //Console.WriteLine("Min: {0} Max: {1}", GetMin(3), GetMax(3));
            //Console.WriteLine("Min: {0} Max: {1}", GetMin(4), GetMax(4));
            //Console.WriteLine("Min: {0} Max: {1}", GetMin(5), GetMax(5));

            //Console.WriteLine(RandomNumberStr(100));
            //Console.WriteLine(RandomNumberInt32(10));
            //Console.WriteLine(LoopRandom(100));

            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());
            //System.Threading.Thread.Sleep(100);
            //Console.WriteLine(RandomBool());

            TestExtension();
            TestExtension2();

            RandomWordGenerator.Test();

            Console.ReadLine();
        }

        public static bool RandomBool()
        {
            Random r = new Random();

            int x = r.Next(1, 3);

            return x == 1;
        }

        public static string RandomNumberStr(int charCount)
        {
            if (charCount == 0) throw new ArgumentOutOfRangeException();

            Random r = new Random();

            StringBuilder ret = new StringBuilder();

            while (ret.Length < charCount)
            {
                ret.Append(r.Next());
            }

            //return the length that was requested.
            return ret.ToString(0, charCount);
        }

        public static int RandomNumberInt32(int charCount)
        {
            if (charCount == 0) throw new ArgumentOutOfRangeException();
            if (charCount > 10) throw new ArgumentOutOfRangeException("Int32 can never be more than 10 numbers");

            Random r = new Random();

            return r.Next(GetMinInt32(charCount), GetMaxInt32(charCount));
        }

        private static int GetMinInt32(int charCount)
        {
            if (charCount == 0) throw new ArgumentOutOfRangeException();

            return Convert.ToInt32(Math.Pow(10, charCount - 1));
        }

        private static int GetMaxInt32(int charCount)
        {
            if (charCount == 0) throw new ArgumentOutOfRangeException();

            try
            {
                return Convert.ToInt32(Math.Pow(10, charCount) - 1);
            }
            catch
            {
                return Int32.MaxValue;
            }
        }

        private static void TestExtension()
        {
            var lst = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            Console.WriteLine(lst.Random());
            Console.WriteLine(lst.Random());
            Console.WriteLine(lst.Random());
            Console.WriteLine(lst.Random());
            Console.WriteLine(lst.Random());
            Console.WriteLine(lst.Random());
            Console.WriteLine(lst.Random());


        }

        private static void TestExtension2()
        {
            Console.WriteLine("TestExtension2");

            var lst = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            Console.WriteLine(lst.Random2());
            Console.WriteLine(lst.Random2());
            Console.WriteLine(lst.Random2());
            Console.WriteLine(lst.Random2());
            Console.WriteLine(lst.Random2());
            Console.WriteLine(lst.Random2());
            Console.WriteLine(lst.Random2());


        }
    }
}

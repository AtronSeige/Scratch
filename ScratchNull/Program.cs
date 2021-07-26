using System;

namespace ScratchNull
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = null;
            int? i = null;
            decimal? d = null;
            object o = null;
            DateTime? dt = null;

            //AreNullsEqual(s, i, d, o, dt);
            //HaveType(s, i, d, o, dt);

            ShorthandTest();

            Console.Write("Done. Press enter to continue.");
            Console.ReadLine();
        }



        private static void ShorthandTest()
        {
            string nullA = null;
            string nullB = null;
            string valueA = "Hi";
            string valueB = "Bye";

            var tmp = nullA + valueA;
            tmp = valueA + nullA;

            BothHaveValueOrBothNull(nullA, nullB);
            BothHaveValueOrBothNull(valueA, nullB);
            BothHaveValueOrBothNull(nullA, valueB);
            BothHaveValueOrBothNull(valueA, valueB);

        }

        private static void BothHaveValueOrBothNull(string a, string b)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Testing a [{a}], b [{b}]");
            if (a == null && b == null)
            {
                Console.WriteLine("both are null");
            }

            if (a != null && b == null)
            {
                Console.WriteLine("b are null");
            }

            if (a == null && b != null)
            {
                Console.WriteLine("a are null");
            }

            if (a != null && b != null)
            {
                Console.WriteLine("both are not null");
            }

            Console.WriteLine("---Shorthand---");
            if (a == null & b == null)
            {
                Console.WriteLine("[sh] both are null or not null");
            }
            else
            {
                Console.WriteLine("[sh] either is null");
            }

            //This check is for if BOTH are null
            //if (a == null & b == null)
            //{
            //    Console.WriteLine("[sh] both are null");
            //}
            //else
            //{
            //    Console.WriteLine("[sh] one or both has a value");
            //}
        }

        private static void HaveType(string s, int? i, decimal? d, object o, DateTime? dt)
        {

            //Console.WriteLine($"string type : [{s.GetType().ToString()}]"); //Error, null ref
            //Console.WriteLine($"int? type : [{i.GetType().ToString()}]"); //Error, null ref
            //Console.WriteLine($"decimal? type : [{d.GetType().ToString()}]"); //Error, null ref
            //Console.WriteLine($"object type : [{o.GetType().ToString()}]"); //Error, null ref
            //Console.WriteLine($"datetime? type : [{dt.GetType().ToString()}]"); //Error
        }

        private static void AreNullsEqual(string s, int? i, decimal? d, object o, DateTime? dt)
        {

            Console.WriteLine($"Is string equal to object : [{s == o}]"); //True
            Console.WriteLine($"Is int equal to decimal : [{i == d}]");  //True
            Console.WriteLine($"Is decimal equal to int : [{d == i}]"); //True

            //Console.WriteLine($"Is string equal to datetime? : [{ s == dt }]"); //Not allowed
            //Console.WriteLine($"Is string equal to int? : [{ s == i }]"); //Not allowed
            //Console.WriteLine($"Is string equal to decimal? : [{ s == d }]"); //Not allowed
            //Console.WriteLine($"Is int equal to object : [{i == o}]");  //Not allowed
            //Console.WriteLine($"Is decimal equal to object : [{d == o}]"); //Not allowed
            //Console.WriteLine($"Is int equal to datetime : [{i == dt}]"); //Not allowed
            //Console.WriteLine($"Is decimal equal to datetime : [{d == dt}]"); //Not allowed

            //Console.WriteLine($"Is datetime equal to int : [{ dt == i}]"); //Not allowed
            //Console.WriteLine($"Is datetime equal to object : [{ dt == d}]"); //Not allowed
            //Console.WriteLine($"Is datetime equal to object : [{ dt == o}]"); //Not allowed




        }

        //Get the type, even if the object is null
        private static Type GetRealType<T>(T obj)
        {
            Type t;

            if (obj == null)
                t = typeof(T);
            else
                t = obj.GetType();

            return t;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ScratchType
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<string>();
            int b = 0;
            var c = 99M;
            var d = 500D;
            object e = new object();
            object f = new object();
            f = 1;

            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());
            Console.WriteLine(c.GetType());
            Console.WriteLine(d.GetType());
            Console.WriteLine(e.GetType());
            Console.WriteLine(f.GetType());

            Console.WriteLine($"Type b[int:0] == f[object:1] ? {b.GetType() == f.GetType()}");

            ClassA ca = new ClassA();
            ClassB cb = new ClassB();
            ClassC cc = new ClassC();

            Console.WriteLine(ca.GetType());
            Console.WriteLine(cb.GetType());
            Console.WriteLine(cc.GetType());

            Console.WriteLine($"Compare CA and CC {ca.GetType() == cc.GetType()}");

            Console.ReadLine();
        }
    }

    class ClassA
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }

    class ClassB
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }

    class ClassC : ClassA
    {

    }
}

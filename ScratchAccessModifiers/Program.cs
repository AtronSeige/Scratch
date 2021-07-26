using ScratchAccessModifiers_Lib1;
using ScratchAccessModifiers_Lib2;
using System;

namespace ScratchAccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test1();
            Test2();

            OptParam1("", val3: 5);
        }

        private static void Test2()
        {
            var pc2 = new PublicClass2();
            pc2.publicName = "PublicName from 1";
            pc2.PublicName2 = "PublicName from 2";

            pc2.PublicMethod();//from pc1
        }

        private static void Test1()
        {
            var pc1 = new PublicClass();
            pc1.publicName = "PublicName";
            pc1.PublicMethod();

            //var ic1 = new InternalClass();

            var dpc1 = new DerivedPublicClass();
            dpc1.publicName = "DerivedPublicClass";
            dpc1.PublicMethod();

            //var rc = new ReferenceClass

        }

        private static void OptParam1(string val1, int val2 = 0, int val3 = 1)
        {

        }
    }
}

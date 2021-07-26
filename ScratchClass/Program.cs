using System;
using System.Collections.Generic;

namespace ScratchClass
{
	class Program
	{
        static void Main(string[] args)
        {
            //InheritanceTest();

            InnerClassTest();

            Console.ReadLine();
        }

        private static void InnerClassTest()
        {
            var cic = new ClassInClass();
            cic.SayHi();

            var ic1 = new ClassInClass.InnerClass1(1, "Jaco");
            ic1.SayHi();

            var ic2 = new ClassInClass.InnerClass2(new DateTime(2018, 01, 28));
            ic2.SayHi();
        }

        private static void InheritanceTest()
        {
            test1 t = new test1();

            Console.WriteLine("First {0}", t.IsTrue);
            t.IsTrue = false;
            Console.WriteLine("Altered {0}", t.IsTrue);

            test1 t1 = new test1();
            test2 t2 = new test2();

            Console.WriteLine(t1.GetType().FullName);

            test t0 = t1;
            Console.WriteLine(t0.GetType().FullName);

            if (t0 is test1)
            {
                Console.WriteLine("Test1");
            }
            else
            {
                Console.WriteLine("Note test 1");
            }

            TestType(t1);
        }

        public static void TestType(test t0)
        {
            if (t0 is test1)
            {
                Console.WriteLine("Test1" + ((test1)t0).secret);
            }
            else
            {
                Console.WriteLine("Note test 1");
            }
        }
    }

    public class test
    {
        public bool IsTrue { get { return _true; } set { } }
        private bool _true = true;

        private List<test> _tests;
        public List<test> tests
        {
            get
            {
                return _tests;
            }
            set
            {

            }
        }
    }

    public class test1 : test
    {
        public string secret = "bubbles";
    }

    public class test2 : test
    {

    }

    public class ClassInClass
    {
        public void SayHi()
        {
            Console.WriteLine($"Hi from ClassInClass. The time is {DateTime.Now.ToShortTimeString()}");
        }

        public class InnerClass1
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public InnerClass1(int id, string name)
            {
                this.Id = id;
                this.Name = name;
            }

            public void SayHi()
            {
                Console.WriteLine($"Hi from InnerClass1. My id is {this.Id} and my name is {this.Name}");
            }
        }

        public class InnerClass2
        {
            public Guid uId { get; set; }
            public DateTime SomeDate { get; set; }

            public InnerClass2(DateTime someDate)
            {
                this.uId = Guid.NewGuid();
                this.SomeDate = someDate;
            }

            public void SayHi()
            {
                Console.WriteLine($"Hi from InnerClass1. My uId is {this.uId} and the date is {this.SomeDate.ToShortDateString()}");
            }

        }
    }

}
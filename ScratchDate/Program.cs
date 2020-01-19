using System;

namespace ScratchDate
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartDate = new DateTime(1979, 01, 28);
            DateTime EndDate = DateTime.Now;

            Console.WriteLine("Jaco was born on  " + StartDate.ToShortDateString());
            Console.WriteLine("The date today is " + EndDate.ToShortDateString());
            Console.WriteLine("Thus he has lived " + (EndDate - StartDate).Days + " days");

            Console.WriteLine("Thus he has lived " + Convert.ToInt32((EndDate - StartDate).TotalDays) + " days");

            TestDate();

            TestDayOfWeeks();

            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        private static void TestDayOfWeeks()
        {
            Console.WriteLine($"Today is [{DateTime.Today}] and the day is [{DateTime.Today.DayOfWeek}] ");
        }

        static void TestDate()
        {
            DateTime dt = new DateTime(2019, 06, 12, 13, 54, 52);

            DateTime now = DateTime.Now;
            Console.WriteLine("Compare NOW");
            Console.WriteLine("Compare now == " + (dt.Date == now)); //FALSE
            Console.WriteLine("Compare now.Date == " + (dt.Date == now.Date)); //TRUE
            Console.WriteLine("Compare now > " + (dt.Date > now)); //FALSE
            Console.WriteLine("Compare now.date > " + (dt.Date > now.Date)); //FALSE
            Console.WriteLine("Compare now < " + (dt.Date < now)); //TRUE
            Console.WriteLine("Compare now.date < " + (dt.Date < now.Date)); //FALSE


            DateTime today = DateTime.Today;
            Console.WriteLine("Compare TODAY");
            Console.WriteLine("Compare today == " + (dt.Date == today)); //TRUE
            Console.WriteLine("Compare today.Date == " + (dt.Date == today.Date)); //TRUE
            Console.WriteLine("Compare today > " + (dt.Date > today)); //FALSE
            Console.WriteLine("Compare today.date > " + (dt.Date > today.Date)); //FALSE
            Console.WriteLine("Compare today < " + (dt.Date < today)); //FALSE
            Console.WriteLine("Compare today.date < " + (dt.Date < today.Date)); //FALSE

        }
    }
}

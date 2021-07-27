using System;
using System.Xml;

namespace ScratchDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartDate = new DateTime(1979, 01, 28);
            DateTime EndDate = DateTime.Now;

            //Console.WriteLine("Jaco was born on  " + StartDate.ToShortDateString());
            //Console.WriteLine("The date today is " + EndDate.ToShortDateString());
            //Console.WriteLine("Thus he has lived " + (EndDate - StartDate).Days + " days");

            //Console.WriteLine("Thus he has lived " + Convert.ToInt32((EndDate - StartDate).TotalDays) + " days");

            //TestDate();

            //TestDayOfWeeks();

            //TestTime();

            ConvertToW3CFormat();

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

        static void TestTime()
		{
            var operatingHoursStart = TimeSpan.Parse("07:00:00");
            var operatingHoursEnd = TimeSpan.Parse("19:30:00");

            Console.WriteLine(operatingHoursStart.ToString());

            if (DateTime.Now.TimeOfDay < operatingHoursStart)
            {
                Console.WriteLine("Less");
            }
            else
            {
                Console.WriteLine("More");
            }


            Console.WriteLine(operatingHoursEnd.ToString());

            if (DateTime.Now.TimeOfDay < operatingHoursEnd)
            {
                Console.WriteLine("Less");
            }
            else
            {
                Console.WriteLine("More");
            }

            FormatTime();
        }

        private static void FormatTime()
        {
            var now = DateTime.Now.TimeOfDay;

            Console.WriteLine(now);
            Console.WriteLine(now.ToString());
            Console.WriteLine(now.ToString(@"hh\:mm\:ss"));
        }

        private static void ConvertToW3CFormat()
		{
            DateTime dt = DateTime.Now;
            
            Console.WriteLine("Formated DateTime ToString         : " + dt.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz"));
            Console.WriteLine("XmlConvert ToString (UTC)          : " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc));
            Console.WriteLine("XmlConvert ToString (RoundtripKind): " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.RoundtripKind));
            Console.WriteLine("XmlConvert ToString (Local)        : " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Local));
            Console.WriteLine("XmlConvert ToString (Unspecified)  : " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Unspecified));

        }
    }
}

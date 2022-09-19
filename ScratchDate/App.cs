using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ScratchDateTime {
	class App {

		public App() {
			
		}

		public void Run() {
			DateTime StartDate = new DateTime(1979, 01, 28);
			DateTime EndDate = DateTime.Now;

			//Console.WriteLine("Jaco was born on  " + StartDate.ToShortDateString());
			//Console.WriteLine("The date today is " + EndDate.ToShortDateString());
			//Console.WriteLine("Thus he has lived " + (EndDate - StartDate).Days + " days");

			//Console.WriteLine("Thus he has lived " + Convert.ToInt32((EndDate - StartDate).TotalDays) + " days");

			//TestDate();

			//TestDayOfWeeks();

			//TestTime();

			//ConvertToW3CFormat();

			//TestUTCStringTodate();
			//TestXMLDate();
			//TestUnivarsalDate();

			//Test_TryParseExact("dd-MM-yyyy", "02-05-2020");
			//Test_TryParseExact("dd-MM-yyyy", "02/05/2020");
			//Test_TryParseExact("dd-MM-yyyy", "2020-05-02");
			//Test_TryParseExact("dd-MM-yyyy", "10-15-2020");

			//TestDifferenceInSeconds();

			//TestDifferentFormats();

			TestDelay();
		}

		private void TestDifferenceInSeconds() {
			DateTime start = DateTime.Now.AddSeconds(-10);
			
			double diffInSeconds = (start - DateTime.Now).TotalSeconds;

			Console.WriteLine($"Date diff in seconds {diffInSeconds}");
		}

		private static void TestDayOfWeeks() {
			Console.WriteLine($"Today is [{DateTime.Today}] and the day is [{DateTime.Today.DayOfWeek}] ");
		}

		static void TestDate() {
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

		static void TestTime() {
			var operatingHoursStart = TimeSpan.Parse("07:00:00");
			var operatingHoursEnd = TimeSpan.Parse("19:30:00");

			Console.WriteLine(operatingHoursStart.ToString());

			if (DateTime.Now.TimeOfDay < operatingHoursStart) {
				Console.WriteLine("Less");
			} else {
				Console.WriteLine("More");
			}


			Console.WriteLine(operatingHoursEnd.ToString());

			if (DateTime.Now.TimeOfDay < operatingHoursEnd) {
				Console.WriteLine("Less");
			} else {
				Console.WriteLine("More");
			}

			FormatTime();
		}

		private static void FormatTime() {
			var now = DateTime.Now.TimeOfDay;

			Console.WriteLine(now);
			Console.WriteLine(now.ToString());
			Console.WriteLine(now.ToString(@"hh\:mm\:ss"));
		}

		private static void ConvertToW3CFormat() {
			DateTime dt = DateTime.Now;

			Console.WriteLine("Formated DateTime ToString         : " + dt.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz"));
			Console.WriteLine("XmlConvert ToString (UTC)          : " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc));
			Console.WriteLine("XmlConvert ToString (RoundtripKind): " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.RoundtripKind));
			Console.WriteLine("XmlConvert ToString (Local)        : " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Local));
			Console.WriteLine("XmlConvert ToString (Unspecified)  : " + XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Unspecified));

		}

		private void TestUnivarsalDate() {
			string testdate = "2021-07-14T08:42:03.66+10:00";

			DateTime dt = DateTime.Parse(testdate);

			Console.WriteLine($"[{dt.ToString()}] as UniversalDate [{dt.ToUniversalTime()}]");
		}

		private void Test_TryParseExact(string format, string value) {

			DateTime dateOfBirth;
			if (DateTime.TryParseExact(value,
										format,
										System.Globalization.CultureInfo.InvariantCulture,
										System.Globalization.DateTimeStyles.None, out dateOfBirth)) {
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"DateTime TryParseExact Passed: [{value}|{format}] > [{dateOfBirth}]");
			} else {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"DateTime TryParseExact Failed: [{value}|{format}]", ConsoleColor.Red);
			}
		}

		private void TestUTCStringTodate() {
			string W3C_Date = "2021-07-14T08:42:03.66+10:00";

			DateTime dt = DateTime.Parse(W3C_Date);

			Console.WriteLine($"[{W3C_Date}] to date is [{dt.ToString()}]");


		}

		private void TestXMLDate() {
			// NOTE: The date is in W3C format. It is not the same as the UTC date.
			string xml = "<xmltest><Name>Jaco</Name><Birthday>2021-07-14T08:42:03.66+10:00</Birthday><IsHappy>true</IsHappy></xmltest>";

			xmltest x = new xmltest();
			// Transform the xml into an object that can be used.
			XmlSerializer xsResponse = new XmlSerializer(typeof(xmltest));
			using (StringReader tr = new StringReader(xml)) {
				using (XmlReader xr = XmlReader.Create(tr)) {
					x = (xmltest)xsResponse.Deserialize(xr);
				}
			}

			Console.WriteLine($"Name: {x.Name}");
			Console.WriteLine($"Birthday: {x.Birthday.ToString()}");
			Console.WriteLine($"IsHappy: {x.IsHappy}");

		}

		private void TestDifferentFormats() {

			//// create date time 2008-03-09 16:05:07.123
			//DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);

			//String.Format("{0:y yy yyy yyyy}", dt);  // "8 08 008 2008"   year
			//String.Format("{0:M MM MMM MMMM}", dt);  // "3 03 Mar March"  month
			//String.Format("{0:d dd ddd dddd}", dt);  // "9 09 Sun Sunday" day
			//String.Format("{0:h hh H HH}", dt);  // "4 04 16 16"      hour 12/24
			//String.Format("{0:m mm}", dt);  // "5 05"            minute
			//String.Format("{0:s ss}", dt);  // "7 07"            second
			//String.Format("{0:f ff fff ffff}", dt);  // "1 12 123 1230"   sec.fraction
			//String.Format("{0:F FF FFF FFFF}", dt);  // "1 12 123 123"    without zeroes
			//String.Format("{0:t tt}", dt);  // "P PM"            A.M. or P.M.
			//String.Format("{0:z zz zzz}", dt);  // "-6 -06 -06:00"   time zone

			//// month/day numbers without/with leading zeroes
			//String.Format("{0:M/d/yyyy}", dt);  // "3/9/2008"
			//String.Format("{0:MM/dd/yyyy}", dt);  // "03/09/2008"

			//// day/month names
			//String.Format("{0:ddd, MMM d, yyyy}", dt);  // "Sun, Mar 9, 2008"
			//String.Format("{0:dddd, MMMM d, yyyy}", dt);  // "Sunday, March 9, 2008"

			//// two/four digit year
			//String.Format("{0:MM/dd/yy}", dt);  // "03/09/08"
			//String.Format("{0:MM/dd/yyyy}", dt);  // "03/09/2008"


			DateTime now = DateTime.Now;
			//Date: Wed, 19 Jan 2022 21:44:32 GMT
			Console.WriteLine(now.ToString("ddd, dd MMM yyyy HH:mm:ss"));

		}

		public class xmltest {
			public string Name { get; set; }
			public DateTime? Birthday { get; set; }

			public bool IsHappy { get; set; }
		}

		private void TestDelay() {
			DateTime startTime = DateTime.Now;
			Console.WriteLine($"Starting at {DateTime.Now.Subtract(startTime).TotalMilliseconds}");

			while (DateTime.Now.Subtract(startTime).TotalMilliseconds < 1000) {
				Console.WriteLine($"A second has not passed yet, only {DateTime.Now.Subtract(startTime).TotalMilliseconds}");
			}

			Console.WriteLine($"A second has passed!");
		}
	}
}

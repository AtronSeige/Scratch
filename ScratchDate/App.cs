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

			TestDifferenceInSeconds();
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

		public class xmltest {
			public string Name { get; set; }
			public DateTime? Birthday { get; set; }

			public bool IsHappy { get; set; }
		}

	}
}

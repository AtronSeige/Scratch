using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScratchString
{
	class Program
	{
		/*
		 * Testing various things that strings do.
		 */



		static void Main(string[] args)
		{
			var str = "";
			Join(str);
			Join2(str);

			var chars = new List<char> { 'H', 'E', 'L', 'L', 'O', ' ', 'W', 'O', 'R', 'L', 'D' };
			JoinListChar(chars);
			JoinListChar2(chars);

			Console.WriteLine($"CapitalizeStart : {CapitalizeStart("thIs is a test", true)}");
			Console.WriteLine($"CapitalizeStart : {CapitalizeStart("1", true)}");
			Console.WriteLine($"CapitalizeStart : {CapitalizeStart(null)}");
			Console.WriteLine($"CapitalizeStart : {CapitalizeStart("")}");
			Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord("thIs is a test", true)}");
			Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord("g", true)}");
			Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord(null)}");
			Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord("")}");

			CompareStrings("test", "test");
			CompareStrings("TEST", "test");

			Console.WriteLine(RemoveAllNonAlphaNumeric("NothingRemoved"));
			Console.WriteLine(RemoveAllNonAlphaNumeric("Space Should Be Removed"));
			Console.WriteLine(RemoveAllNonAlphaNumeric("There1Should2Be3No4Numbers"));
			Console.WriteLine(RemoveAllNonAlphaNumeric("Special|Chars$Should+Not!Show"));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));
			Console.WriteLine(RemoveAllNonAlphaNumeric(""));

			Console.WriteLine(CamelCase("THIS IS A TEST"));
			TestLocations();

			DifferentDecimalTString();
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();


			DifferentDateTimeToString();
			NullTest();

			TestEquality();

			TestSplit();
			TestDictionary();
			TestContains();

			BoolToString();

			TestReplace();

			TestSubstringAndIndexOf();

			TestNulls();

			TestPadding();

			TestAddNullToString();

			TestGetValue();

			Console.WriteLine("All done. Press any key...");

			Console.ReadLine();
		}

		static void Join(string str)
		{
			string outp = "";

			foreach (var i in str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				if (outp.Length > 0)
					outp += ",";
				outp += "'" + i + "'";
			}

			Console.WriteLine($"Join : {outp}");
		}

		static void Join2(string str)
		{
			string outp = String.Empty;

			if (!String.IsNullOrEmpty(str))
			{
				outp = "'" + String.Join("','", str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) + "'";
			}


			Console.WriteLine($"Join2 : {outp}");
		}

		static void JoinListChar(List<char> chars)
		{
			var str = "";
			for (int k = 0; k < chars.Count; k++)
				str += chars[k];


			Console.WriteLine($"JoinListChar : {str}");
		}

		static void JoinListChar2(List<char> chars)
		{
			Console.WriteLine($"JoinListChar : {String.Join("", chars)}");
		}

		static string CapitalizeStart(string str, bool lowerCaseRestOfWord = false)
		{
			if (str == null)
			{
				//throw new ArgumentNullException("str");
				return "Null will cause issues, don't do that";
			}

			if (str.Length > 0)
				str = str.Substring(0, 1).ToUpper() + (lowerCaseRestOfWord ? str.Substring(1).ToLower() : str.Substring(1));

			return str;
		}

		static string CapitalizeEachWord(string str, bool lowerCaseRestOfWord = false)
		{
			if (str == null)
			{
				//throw new ArgumentNullException("str");
				return "Null will cause issues, don't do that";
			}

			var newstr = new StringBuilder();
			foreach (var w in str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
				newstr.Append(CapitalizeStart(w, lowerCaseRestOfWord) + ' ');

			//do not return the last char
			return newstr.ToString().Substring(0, newstr.Length > 0 ? newstr.Length - 1 : 0);
		}

		static void CompareStrings(string str1, string str2)
		{
			Console.WriteLine($"Comparing {str1} against {str2}");
			Console.WriteLine("\tCurrentCulture " + str1.Equals(str2, StringComparison.CurrentCulture));
			Console.WriteLine("\tCurrentCultureIgnoreCase " + str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase));
			Console.WriteLine("\tInvariantCulture " + str1.Equals(str2, StringComparison.InvariantCulture));
			Console.WriteLine("\tInvariantCultureIgnoreCase " + str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase));
			Console.WriteLine("\tOrdinal " + str1.Equals(str2, StringComparison.Ordinal));
			Console.WriteLine("\tOrdinalIgnoreCase " + str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
			Console.WriteLine();
		}

		private static void TestNulls()
		{
			string empty = "";
			string whitespace = " ";
			string sNull = null;

			Console.WriteLine($"IsNullOrEmpty with empty returned {String.IsNullOrEmpty(empty)}");
			Console.WriteLine($"IsNullOrEmpty with whitespace returned {String.IsNullOrEmpty(whitespace)}");
			Console.WriteLine($"IsNullOrEmpty with sNull returned {String.IsNullOrEmpty(sNull)}");

			Console.WriteLine($"IsNullOrWhiteSpace with empty returned {String.IsNullOrWhiteSpace(empty)}");
			Console.WriteLine($"IsNullOrWhiteSpace with whitespace returned {String.IsNullOrWhiteSpace(whitespace)}");
			Console.WriteLine($"IsNullOrWhiteSpace with sNull returned {String.IsNullOrWhiteSpace(sNull)}");
		}

		private static void TestPadding()
		{
			Console.WriteLine(String.Empty.PadLeft(3, '0'));
			Console.WriteLine("0".PadLeft(3, '0'));
			Console.WriteLine("1".PadLeft(3, '0'));
			Console.WriteLine("11".PadLeft(3, '0'));
			Console.WriteLine("99".PadLeft(3, '0'));
			Console.WriteLine("100".PadLeft(3, '0'));
			Console.WriteLine("999".PadLeft(3, '0'));
			Console.WriteLine("1001".PadLeft(3, '0'));
			Console.WriteLine("9999".PadLeft(3, '0'));
			Console.WriteLine("888888".PadLeft(3, '0'));
		}

		public static string CamelCase(string input)
		{
			return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
		}

		public string UppercaseFirst(string s)
		{
			char[] a = s.ToCharArray();
			a[0] = char.ToUpper(a[0]);
			return new string(a);
		}

		public static string RemoveAllNonAlphaNumeric(string input)
		{
			return RemoveAllNonAlphas(RemoveAllNumerics(RemoveAllWhiteSpace(input)));
		}

		public static string RemoveAllNumerics(string input)
		{
			return Regex.Replace(input, @"\d", "");
		}

		public static string RemoveAllWhiteSpace(string input)
		{
			return Regex.Replace(input, @"\s", "");
		}

		public static string RemoveAllNonAlphas(string input)
		{
			return Regex.Replace(input, @"\W", "");
		}

		public static void DifferentDecimalTString()
		{
			decimal value = 16325.62M;
			string specifier;

			//' Use standard numeric format specifiers.
			specifier = "G";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			//' Displays:    G: 16325.62
			specifier = "C";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			//' Displays:    C: $16,325.62
			specifier = "E04";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			//' Displays:    E04: 1.6326E+004
			specifier = "F";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			//' Displays:    F: 16325.62
			specifier = "N";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			//' Displays:    N: 16,325.62
			specifier = "P";
			Console.WriteLine("{0}: {1}", specifier, (value / 10000).ToString(specifier));
			//' Displays:    P: 163.26 % 

			//' Use custom numeric format specifiers.
			specifier = "0,0.000";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			//' Displays:    0,0.000: 16,325.620
			specifier = "#,#.00#;(#,#.00#)";
			Console.WriteLine("{0}: {1}", specifier, (value * -1).ToString(specifier));
			//' Displays:    #,#.00#;(#,#.00#): (16,325.62)
			specifier = "#,##0.0000000";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier, CultureInfo.InvariantCulture));
			//' Displays:    #,#.00#;(#,#.00#): (16,325.62)

		}

		public static void DifferentDateTimeToString()
		{
			DateTime value = DateTime.Now;

			string specifier;

			//' Use standard numeric format specifiers.
			specifier = "d";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));

			specifier = "D";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));

			specifier = "f";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));

			specifier = "F";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "g";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "G";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "M";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "O";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "R";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "s";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "t";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "T";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "u";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "U";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));
			specifier = "Y";
			Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier));


		}

		public static void NullTest()
		{
			string s1 = "one";
			string sEmpty = "";
			string snull = null;

			string output = s1;
			output += sEmpty ?? "empty";
			output += snull ?? "null";
			output += s1;

			Console.WriteLine(output);


		}

		public static void TestLocations()
		{
			string s1 = "1234";
			string s2 = "90";

			string test = "1234567890";

			Console.WriteLine(test.Substring(s1.Length, test.Length - s1.Length - s2.Length));

			//expecing 5678

		}

		public static void TestEquality()
		{
			Console.WriteLine("abc == abc : " + ("abc" == "abc"));
			Console.WriteLine("ABC == abc : " + ("ABC" == "abc"));
			//Console.WriteLine("abc" == "ABC");

			Console.WriteLine("abc equals abc : " + ("abc".Equals("abc")));
			Console.WriteLine("ABC equals abc : " + ("ABC".Equals("abc")));

			Console.WriteLine("abc equals abc : " + ("abc".Equals("abc", StringComparison.CurrentCultureIgnoreCase)));
			Console.WriteLine("ABC equals abc : " + ("ABC".Equals("abc", StringComparison.CurrentCultureIgnoreCase)));
		}

		public static void TestSplit()
		{
			string s1 = "Jaco1";
			string s2 = "Jaco1\\Hamilton2";
			string s3 = "Jaco1\\Hamilton2\\Attwell3";
			string s4 = "Jaco1\\Hamilton2\\Attwell3\\";

			Console.WriteLine(s1.Split('\\').Last());
			Console.WriteLine(s2.Split('\\').Last());
			Console.WriteLine(s3.Split('\\').Last());
			Console.WriteLine(s4.Split('\\').Where(x => x != String.Empty).Last());
		}

		public static void TestDictionary()
		{
			Dictionary<string, string> d = new Dictionary<string, string>();
			d.Add("b", "2");
			d.Add("e", "5");
			d.Add("a", "1");
			d.Add("i", "9");
			d.Add("c", "3");
			d.Add("f", "6");
			d.Add("h", "8");
			d.Add("d", "4");
			d.Add("g", "7");

			foreach (var kvp in d)
			{
				Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
			}
		}

		public static void TestContains()
		{
			string s1 = "Test";
			string s2 = "test";
			string s3 = "TEST";

			Console.WriteLine(s1.Contains("Test"));
			Console.WriteLine(s2.Contains("Test"));
			Console.WriteLine(s3.Contains("Test"));
		}

		public static void BoolToString()
		{
			bool t = true;
			bool f = false;

			Console.WriteLine(t);
			Console.WriteLine(f);

		}

		public static void TestReplace()
		{
			string instring = "[[Replaceme]] World";
			string notinstring = "Replaceme World";

			Console.Write(instring.Replace("[[Replaceme]]", "Hello"));
			Console.Write(notinstring.Replace("[[Replaceme]]", "Good bye"));
		}

		public static void TestSubstringAndIndexOf()
		{
			string test = "SBA40N203515   ;10;000;6805   ";

			Console.WriteLine("Substring 0 indexof first ; {0}", test.Substring(0, test.IndexOf(';')));
			Console.WriteLine("Substring from first ; (add one to skip the ;) {0}", test.Substring(test.IndexOf(';') + 1));

			int start = test.IndexOf(';') + 1;
			int end = test.IndexOf(';', test.IndexOf(';') + 1);
			int total = end - start;

			Console.WriteLine("Get the value between the first and second ; {0}", test.Substring(test.IndexOf(';') + 1, (test.IndexOf(';', test.IndexOf(';') + 1)) - (test.IndexOf(';') + 1)));


		}

		public static void TestAddNullToString()
		{
			string s1 = "value";
			string snull = null;

			Console.WriteLine(s1 + snull);

		}

		public static void TestGetValue()
		{
			string teststring = "APP=SomeApp;  NAME = Name Here;SITETYPE   =   ABC;   USER   =    Driver   ;IP=Add IP Name Here;  PROJECT   = Bubbles  ";

			if (teststring.GetValue("APP") != "SomeApp") throw new Exception();
			if (teststring.GetValue("NAME") != "Name Here") throw new Exception();
			if (teststring.GetValue("SITETYPE") != "ABC") throw new Exception();
			if (teststring.GetValue("USER") != "Driver") throw new Exception();
			if (teststring.GetValue("IP") != "Add IP Name Here") throw new Exception();
			if (teststring.GetValue("PROJECT") != "Bubbles") throw new Exception();
			if (teststring.GetValue("Test") != "") throw new Exception();
		}



	}
}

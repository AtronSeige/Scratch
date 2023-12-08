using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;

namespace ScratchString {
	class App {

		public App() {

		}

		public void Run() {
			//string str = "";
			//Join(str);
			//Join2(str);

			//List<char> chars = new List<char> { 'H', 'E', 'L', 'L', 'O', ' ', 'W', 'O', 'R', 'L', 'D' };
			//JoinListChar(chars);
			//JoinListChar2(chars);

			//Console.WriteLine($"CapitalizeStart : {CapitalizeStart("thIs is a test", true)}");
			//Console.WriteLine($"CapitalizeStart : {CapitalizeStart("1", true)}");
			//Console.WriteLine($"CapitalizeStart : {CapitalizeStart(null)}");
			//Console.WriteLine($"CapitalizeStart : {CapitalizeStart("")}");
			//Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord("thIs is a test", true)}");
			//Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord("g", true)}");
			//Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord(null)}");
			//Console.WriteLine($"CapitalizeEachWord : {CapitalizeEachWord("")}");

			//CompareStrings("test", "test");
			//CompareStrings("TEST", "test");



			//Console.WriteLine(CamelCase("THIS IS A TEST"));
			//TestLocations();

			//DifferentDecimalTString();
			//Console.WriteLine(); Console.WriteLine(); Console.WriteLine();


			//DifferentDateTimeToString();
			//NullTest();

			//TestEquality();

			//TestSplit();
			//TestDictionary();
			//TestContains();

			//BoolToString();

			//TestReplace();

			TestSubstringAndIndexOf();

			//TestNulls();

			//TestPadding();

			//TestAddNullToString();

			//TestGetValue();

			//TestStringAsMath("(2+5) * s");

			////NullCastTest();
			////NonASCII7Char();
			//SubstringLen();

			//NameSurnameTest();

			//Console.WriteLine(ToTitleCase("mrs"));
			//Console.WriteLine(ToTitleCase("Miss"));
			//Console.WriteLine(ToTitleCase("MR"));
			//Console.WriteLine(ToTitleCase("mR"));
			//Console.WriteLine(ToTitleCase("MisS"));
			//Console.WriteLine(ToTitleCase("m"));
			//Console.WriteLine(ToTitleCase("M"));

			TestHTMLSafe();
		}

		private void NullCastTest() {
			string s = string.Empty;

			if ((object)s == null) {
				Console.WriteLine("string is null");
			} else {
				Console.WriteLine("string is not null");
			}


			if (string.IsNullOrEmpty(s)) {
				Console.WriteLine("string is null");
			} else {
				Console.WriteLine("string is not null");
			}
		}


		private void NonASCII7Char() {
			string x;
			Encoding enc = Encoding.UTF8;
			x = "Jaco";
			Console.WriteLine(x + (HasNonASCIIChars(x, enc) ? " has invalid chars" : " does not have invalid chars"));
			x = "123";
			Console.WriteLine(x + (HasNonASCIIChars(x, enc) ? " has invalid chars" : " does not have invalid chars"));
			x = "asdf";
			Console.WriteLine(x + (HasNonASCIIChars(x, enc) ? " has invalid chars" : " does not have invalid chars"));
			x = "WERT";
			Console.WriteLine(x + (HasNonASCIIChars(x, enc) ? " has invalid chars" : " does not have invalid chars"));
			x = "@#$";
			Console.WriteLine(x + (HasNonASCIIChars(x, enc) ? " has invalid chars" : " does not have invalid chars"));
			x = "LÄN";
			Console.WriteLine(x + (HasNonASCIIChars(x, enc) ? " has invalid chars" : " does not have invalid chars"));

		}
		private bool HasNonASCIIChars(string str, Encoding enc) {
			Console.WriteLine($"{enc.GetByteCount(str)} vs {str.Length}");
			//return (enc.GetByteCount(str) != str.Length);
			return (str.Length != Encoding.UTF8.GetByteCount(str));
		}

		private void SubstringLen() {
			string siteURL = null; // "https://www.harrolds.com.au";
			if (siteURL.EndsWith("/")) {
				siteURL = siteURL.Substring(0, siteURL.Length - 1);
			}

			Console.WriteLine(siteURL);
		}

		void Join(string str) {
			string outp = "";

			foreach (var i in str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
				if (outp.Length > 0)
					outp += ",";
				outp += "'" + i + "'";
			}

			Console.WriteLine($"Join : {outp}");
		}

		void Join2(string str) {
			string outp = String.Empty;

			if (!String.IsNullOrEmpty(str)) {
				outp = "'" + String.Join("','", str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) + "'";
			}


			Console.WriteLine($"Join2 : {outp}");
		}

		void JoinListChar(List<char> chars) {
			var str = "";
			for (int k = 0; k < chars.Count; k++)
				str += chars[k];


			Console.WriteLine($"JoinListChar : {str}");
		}

		void JoinListChar2(List<char> chars) {
			Console.WriteLine($"JoinListChar : {String.Join("", chars)}");
		}

		string CapitalizeStart(string str, bool lowerCaseRestOfWord = false) {
			if (str == null) {
				//throw new ArgumentNullException("str");
				return "Null will cause issues, don't do that";
			}

			if (str.Length > 0)
				str = str.Substring(0, 1).ToUpper() + (lowerCaseRestOfWord ? str.Substring(1).ToLower() : str.Substring(1));

			return str;
		}

		string CapitalizeEachWord(string str, bool lowerCaseRestOfWord = false) {
			if (str == null) {
				//throw new ArgumentNullException("str");
				return "Null will cause issues, don't do that";
			}

			var newstr = new StringBuilder();
			foreach (var w in str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
				newstr.Append(CapitalizeStart(w, lowerCaseRestOfWord) + ' ');

			//do not return the last char
			return newstr.ToString().Substring(0, newstr.Length > 0 ? newstr.Length - 1 : 0);
		}

		void CompareStrings(string str1, string str2) {
			Console.WriteLine($"Comparing {str1} against {str2}");
			Console.WriteLine("\tCurrentCulture " + str1.Equals(str2, StringComparison.CurrentCulture));
			Console.WriteLine("\tCurrentCultureIgnoreCase " + str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase));
			Console.WriteLine("\tInvariantCulture " + str1.Equals(str2, StringComparison.InvariantCulture));
			Console.WriteLine("\tInvariantCultureIgnoreCase " + str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase));
			Console.WriteLine("\tOrdinal " + str1.Equals(str2, StringComparison.Ordinal));
			Console.WriteLine("\tOrdinalIgnoreCase " + str1.Equals(str2, StringComparison.OrdinalIgnoreCase));
			Console.WriteLine();
		}

		private void TestNulls() {
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

		private void TestPadding() {
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

		public string CamelCase(string input) {
			return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
		}

		public string UppercaseFirst(string s) {
			char[] a = s.ToCharArray();
			a[0] = char.ToUpper(a[0]);
			return new string(a);
		}

		public string ToTitleCase(string s) {
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
		}

		public void DifferentDecimalTString() {
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

		public void DifferentDateTimeToString() {
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

		public void NullTest() {
			string s1 = "one";
			string sEmpty = "";
			string snull = null;

			string output = s1;
			output += sEmpty ?? "empty";
			output += snull ?? "null";
			output += s1;

			Console.WriteLine(output);


		}

		public void TestLocations() {
			string s1 = "1234";
			string s2 = "90";

			string test = "1234567890";

			Console.WriteLine(test.Substring(s1.Length, test.Length - s1.Length - s2.Length));

			//expecing 5678

		}

		public void TestEquality() {
			Console.WriteLine("abc == abc : " + ("abc" == "abc"));
			Console.WriteLine("ABC == abc : " + ("ABC" == "abc"));
			//Console.WriteLine("abc" == "ABC");

			Console.WriteLine("abc equals abc : " + ("abc".Equals("abc")));
			Console.WriteLine("ABC equals abc : " + ("ABC".Equals("abc")));

			Console.WriteLine("abc equals abc : " + ("abc".Equals("abc", StringComparison.CurrentCultureIgnoreCase)));
			Console.WriteLine("ABC equals abc : " + ("ABC".Equals("abc", StringComparison.CurrentCultureIgnoreCase)));
		}

		public void TestSplit() {
			string s1 = "Jaco1";
			string s2 = "Jaco1\\Hamilton2";
			string s3 = "Jaco1\\Hamilton2\\Attwell3";
			string s4 = "Jaco1\\Hamilton2\\Attwell3\\";

			Console.WriteLine(s1.Split('\\').Last());
			Console.WriteLine(s2.Split('\\').Last());
			Console.WriteLine(s3.Split('\\').Last());
			Console.WriteLine(s4.Split('\\').Where(x => x != String.Empty).Last());

			s1 = "tech@isams.net;jaco.hamilton-attwell@estaronline.com;Francis.Rapadas@estaronline.com;ashleigh.gilluley@harrolds.com.au;";
			string[] arrS1 = s1.Split(';');
			foreach (string s in arrS1) {
				Console.WriteLine($"Value [{s}]");
			}
		}

		public void TestDictionary() {
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

			foreach (var kvp in d) {
				Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
			}
		}

		public void TestContains() {
			string s1 = "Test";
			string s2 = "test";
			string s3 = "TEST";

			Console.WriteLine(s1.Contains("Test"));
			Console.WriteLine(s2.Contains("Test"));
			Console.WriteLine(s3.Contains("Test"));
		}

		public void BoolToString() {
			bool t = true;
			bool f = false;

			Console.WriteLine(t);
			Console.WriteLine(f);

		}

		public void TestReplace() {
			string instring = "[[Replaceme]] World";
			string notinstring = "Replaceme World";

			Console.Write(instring.Replace("[[Replaceme]]", "Hello"));
			Console.Write(notinstring.Replace("[[Replaceme]]", "Good bye"));
		}

		public void TestSubstringAndIndexOf() {
			string test = "SBA40N203515   ;10;000;6805   ";

			// These should fail.
			try {
				Console.WriteLine("Substring 0 to text len + 1 {0}", test.Substring(0, test.Length + 1));
				Console.WriteLine("Substring 0 to text len + 100 {0}", test.Substring(0, test.Length + 100));
			} catch (ArgumentOutOfRangeException e) {
				Console.WriteLine(e.ToString());
			}
			Console.WriteLine("Substring 0 indexof first ; {0}", test.Substring(0, test.IndexOf(';')));
			Console.WriteLine("Substring from first ; (add one to skip the ;) {0}", test.Substring(test.IndexOf(';') + 1));

			int start = test.IndexOf(';') + 1;
			int end = test.IndexOf(';', test.IndexOf(';') + 1);
			int total = end - start;

			Console.WriteLine("Get the value between the first and second ; {0}", test.Substring(test.IndexOf(';') + 1, (test.IndexOf(';', test.IndexOf(';') + 1)) - (test.IndexOf(';') + 1)));


		}

		public void TestAddNullToString() {
			string s1 = "value";
			string snull = null;

			Console.WriteLine(s1 + snull);

		}

		public void TestGetValue() {
			string teststring = "APP=SomeApp;  NAME = Name Here;SITETYPE   =   ABC;   USER   =    Driver   ;IP=Add IP Name Here;  PROJECT   = Bubbles  ";

			if (teststring.GetValue("APP") != "SomeApp") throw new Exception();
			if (teststring.GetValue("NAME") != "Name Here") throw new Exception();
			if (teststring.GetValue("SITETYPE") != "ABC") throw new Exception();
			if (teststring.GetValue("USER") != "Driver") throw new Exception();
			if (teststring.GetValue("IP") != "Add IP Name Here") throw new Exception();
			if (teststring.GetValue("PROJECT") != "Bubbles") throw new Exception();
			if (teststring.GetValue("Test") != "") throw new Exception();
		}

		public void TestStringAsMath(string mathString) {
			try {

				DataTable dt = new DataTable();
				object result = dt.Compute(mathString, "");

				Console.WriteLine("Result: " + result);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		public void NameSurnameTest() {
			string value = "";
			(string first, string last) result = SplitNameSurnameBySpace(value);
			Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			value = "Jaco";
			result = SplitNameSurnameBySpace(value);
			Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			value = "Jaco Test";
			result = SplitNameSurnameBySpace(value);
			Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			value = "Jaco Test Test2";
			result = SplitNameSurnameBySpace(value);
			Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			value = null;
			result = SplitNameSurnameBySpace(value);
			Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			//value = "";
			//result = SplitNameSurnameBySpace(value);
			//Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			//value = "";
			//result = SplitNameSurnameBySpace(value);
			//Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			//value = "";
			//result = SplitNameSurnameBySpace(value);
			//Console.WriteLine($"First [{result.first}] Last [{result.last}]");

			//value = "";
			//result = SplitNameSurnameBySpace(value);
			//Console.WriteLine($"First [{result.first}] Last [{result.last}]");
		}

		private (string first, string last) SplitNameSurnameBySpace(string fullname) {

			if (string.IsNullOrWhiteSpace(fullname)) return ("","");

			if (fullname.Contains(" ")) {
				int space = fullname.LastIndexOf(" ");
				string lastname = fullname.Substring(space+ 1);
				string firstname = fullname.Substring(0, space);
				
				return (firstname, lastname);
			} else {
				return (fullname, "");
			}
		}


		private void TestHTMLSafe() {

			string html = "<this>value</this>";

			Console.WriteLine(html);
			Console.WriteLine(HttpUtility.HtmlEncode(html));
		}
	}
}

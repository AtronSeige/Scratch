﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ScratchRegex {
	class App {

		public App() {

		}

		public void Run() {
			StringTests();

			//ReplaceTests();

			//DateTests();

			//Console.WriteLine(RemoveAllNonAlphaNumeric("NothingRemoved"));
			//Console.WriteLine(RemoveAllNonAlphaNumeric("Space Should Be Removed"));
			//Console.WriteLine(RemoveAllNonAlphaNumeric("There1Should2Be3No4Numbers"));
			//Console.WriteLine(RemoveAllNonAlphaNumeric("Special|Chars$Should+Not!Show"));

			Console.ReadLine();
		}


		private void ReplaceTests() {
			string test = "this1is2a3test";
			ReplaceTest(test, "[0-9]", "_");

			test = "012-356-ABC-9999-abc";
			ReplaceTest(test, "[^0-9]", "_");

			test = "012-356-ABC-9999-abc";
			ReplaceTest(test, "[a-zA-Z]", "_");

			test = "012-356-ABC-9999-abc";
			ReplaceTest(test, "[^a-zA-Z]", "_");

			test = "012-356-ABC-9999-abc";
			ReplaceTest(test, "[0-9a-zA-Z]", "_");

			test = "012-356-ABC-9999-abc";
			ReplaceTest(test, "[^0-9a-zA-Z]", "_");

		}

		private static void ReplaceTest(string initialValue, string pattern, string replacementValue) {
			Console.WriteLine($"Replacing [{pattern}] in [{initialValue}] with [{replacementValue}] resulted in [{Regex.Replace(initialValue, pattern, replacementValue)}]");
		}

		private static void StringTests() {
			//StringTest("this is a test", "is");
			//StringTest("mercury.file.name", "^[Mercury|Nedbank]", RegexOptions.IgnoreCase);
			//StringTest("nedbank.file.name", "^[Mercury|Nedbank]");
			//StringTest("test.file.name", "^[Mercury|Nedbank]");
			//StringTest("test.mercury.name", "^[Mercury|Nedbank]");
			//StringTest("this is a test", "is", true);
			//StringTest("this is a test", "green", false);
			//StringTest("123456789012", "^[0-9]{12}", true);
			//StringTest("123456789012.pain.001.20181212122302.xml", "^[0-9]{12}.pain.001.20[1-9][0-9][0-1][0-9][0-3][0-9][0-2][0-9][0-5][0-9][0-5][0-9].xml", true);
			//StringTest("000000000001.pain.001.20181213073234.xml", "^[0-9]{12}.pain.001.20[1-9][0-9][0-1][0-9][0-3][0-9][0-2][0-9][0-5][0-9][0-5][0-9].xml", true);
			//StringTest("JACO", "(DO_NOT_COMMIT|JACO|DONOTCOMMIT)", true, RegexOptions.IgnoreCase);
			//StringTest("HI", "(DO_NOT_COMMIT|JACO|DONOTCOMMIT)", false, RegexOptions.IgnoreCase);
			//StringTest("this is a DONOTCOMMIT test of the warning system", "(DO_NOT_COMMIT|JACO|DONOTCOMMIT)", true, RegexOptions.IgnoreCase);
			//StringTest("this is a DO NOT COMMIT test of the warning system", "(DO_NOT_COMMIT|JACO|DONOTCOMMIT)", false, RegexOptions.IgnoreCase);

			string jacoPattern = "(DO_NOT_COMMIT|JACO|DONOTCOMMIT)";
			StringTest("JACO", jacoPattern, true, RegexOptions.IgnoreCase);
			StringTest("Developer: JACO H.", jacoPattern, false, RegexOptions.IgnoreCase);
			StringTest("TODO JACO Help with this", jacoPattern, true, RegexOptions.IgnoreCase);

			string ignoreJacoPattern = "(jaco h.)";

			StringTest("JACO", ignoreJacoPattern, false, RegexOptions.IgnoreCase);
			StringTest("Developer: JACO H.", ignoreJacoPattern, true, RegexOptions.IgnoreCase);
			StringTest("TODO JACO Help with this", ignoreJacoPattern, false, RegexOptions.IgnoreCase);
		}

		private static void StringTest(string toTest, string pattern, bool expectPass, RegexOptions options = RegexOptions.None) {
			var match = Regex.IsMatch(toTest, pattern, options);
			var result = match ? "match" : "no match";


			Console.ForegroundColor = match == expectPass ? ConsoleColor.Green : ConsoleColor.Red;
			Console.WriteLine($"Matching [{toTest}] with [{pattern}] resulted in [{result}]");
			Console.ResetColor();
		}

		private static void DateTests() {
			string yyyyMMdd = "^20\\d\\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])$";
			Console.WriteLine("DateTest: Expected Pass");
			DateTest("20180101", yyyyMMdd, true);
			DateTest("20181231", yyyyMMdd, true);
			DateTest("20181201", yyyyMMdd, true);
			Console.WriteLine("DateTest: Expected Fail");
			DateTest("00001201", yyyyMMdd, false);
			DateTest("20181300", yyyyMMdd, false);
			DateTest("20181233", yyyyMMdd, false);

			string HHmmss = "^([0-1][0-9]|2[0-4])[0-5][0-9][0-5][0-9]$";
			Console.WriteLine("DateTest: Expected Pass");
			DateTest("000000", HHmmss, true);
			DateTest("235959", HHmmss, true);
			DateTest("240000", HHmmss, true);
			Console.WriteLine("DateTest: Expected Fail");
			DateTest("206700", HHmmss, false);
			DateTest("204090", HHmmss, false);
			DateTest("999999", HHmmss, false);

			string yyMMddHHmmss = "^" + (yyyyMMdd + HHmmss).Replace("^", "").Replace("$", "") + "$";
			Console.WriteLine("DateTest: Expected Pass");
			DateTest("20180101000000", yyMMddHHmmss, true);
			DateTest("20180601244242", yyMMddHHmmss, true);
			DateTest("20181231235959", yyMMddHHmmss, true);

			Console.WriteLine("DateTest: Expected Fail");
			DateTest("00001201000000", yyMMddHHmmss, false);
			DateTest("20181300000000", yyMMddHHmmss, false);
			DateTest("20181233000000", yyMMddHHmmss, false);
			DateTest("00001201206700", yyMMddHHmmss, false);
			DateTest("20181300204090", yyMMddHHmmss, false);
			DateTest("20181233999999", yyMMddHHmmss, false);


		}

		private static void DateTest(string toTest, string pattern, bool expectPass, RegexOptions options = RegexOptions.None) {
			var match = Regex.IsMatch(toTest, pattern, options);
			var result = match ? "match" : "no match";

			Console.ForegroundColor = match == expectPass ? ConsoleColor.Green : ConsoleColor.Red;
			Console.WriteLine($"Matching [{toTest}] with [{pattern}] resulted in [{result}]");
			Console.ResetColor();
		}

		public string RemoveAllNonAlphaNumeric(string input) {
			return RemoveAllNonAlphas(RemoveAllNumerics(RemoveAllWhiteSpace(input)));
		}

		public string RemoveAllNumerics(string input) {
			return Regex.Replace(input, @"\d", "");
		}

		public string RemoveAllWhiteSpace(string input) {
			return Regex.Replace(input, @"\s", "");
		}

		public string RemoveAllNonAlphas(string input) {
			return Regex.Replace(input, @"\W", "");
		}

	}
}
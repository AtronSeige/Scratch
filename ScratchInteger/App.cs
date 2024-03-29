﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchInteger {
	class App {
		public App() {

		}

		public void Run() {
			//TestMod();

			TestFloorCeiling();



			//this.NullableInt();
			//this.StringToInt();
			////Compare();
			//GetNext5(1);
			//GetNext5(12);
			//GetNext5(14);
			//GetNext5(15);
			//GetNext5(18);
			//GetNext5(100);

			//TestTryParse();
			//TestIncrement();
		}

		private void TestFloorCeiling() {

			decimal itemCount = 1;
			decimal itemsPerPage = 10;

			Console.WriteLine($"Plain: {itemCount / itemsPerPage}");
			Console.WriteLine($"Floor: {Math.Floor(itemCount/itemsPerPage)}");
			Console.WriteLine($"Ceiling: {Math.Ceiling(itemCount / itemsPerPage)}");


		}

		private static void TestMod() {
			int i = 0;
			int mod = i % 10;
			Console.WriteLine($"Mod for ({i}) is {mod}");

			i = 5;
			mod = i % 10;
			Console.WriteLine($"Mod for ({i}) is {mod}");

			i = 10;
			mod = i % 10;
			Console.WriteLine($"Mod for ({i}) is {mod}");

			i = 15;
			mod = i % 10;
			Console.WriteLine($"Mod for ({i}) is {mod}");

			i = 19;
			mod = i % 10;
			Console.WriteLine($"Mod for ({i}) is {mod}");
		}

		private void TestIncrement() {
			int count = 1;
			for (int i = 0; i < 10; i++) {
				Console.WriteLine($"Increment Test {count++}");
			}
		}

		private void TestTryParse() {

			int i = 666;
			string value = "zero";
			Console.WriteLine($"Parse testing for \"{value}\" and {i}");
			if (!int.TryParse(value, out i)) {
				Console.WriteLine($"Parse failed for {value}, the value of i is {i}");
			} else {
				Console.WriteLine($"Parse succeeded for {value}, the value of i is {i}");
			}

			//i = 0;
			//value = "0";
			//if (!int.TryParse(value, out i)) {
			//	Console.WriteLine($"Parse failed for {value}");
			//} else {
			//	Console.WriteLine($"Parsing {value} returned {i}");
			//}

			//// Immediately check the value after the parse
			//i = 0;
			//value = "-1";
			//if (!int.TryParse(value, out i) || i <= 0) {
			//	Console.WriteLine($"Parse failed for {value} or returned less that 0 ({i})");
			//} else {
			//	Console.WriteLine($"Parsing {value} returned {i}");
			//}

		}

		private void NullableInt() {
			try {
				int? x = null;
				Console.WriteLine(x);
				Console.WriteLine((int)x);
				x = 1;
				Console.WriteLine(x);
				Console.WriteLine((int)x);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		private void StringToInt() {
			int x = 0;
			if (int.TryParse("2,147,483,647", out x)) {
				Console.WriteLine("Parse succeeded");
			} else {
				Console.WriteLine("Parse failed");
			}

			x = 0;
			if (int.TryParse("2147483647", out x)) {
				Console.WriteLine("Parse succeeded");
			} else {
				Console.WriteLine("Parse failed");
			}

			Console.WriteLine("2147483647 to int becomes " + x.ToString());

		}

		private static void GetNext5(int v) {
			var div = v % 5;

			Console.WriteLine(div);
		}

		private static void Compare() {
			int i1 = 1;
			int? i2 = null;
			Console.WriteLine($"1 == null : {i1 == i2}");
			i2 = 1;
			Console.WriteLine($"1 == 1 : {i1 == i2}");
			i2 = 2;
			Console.WriteLine($"1 == 2 : {i1 == i2}");
			Console.WriteLine();


			i2 = null;
			Console.WriteLine($"1 > null : {i1 > i2}");
			i2 = 1;
			Console.WriteLine($"1 > 1 : {i1 > i2}");
			i2 = 2;
			Console.WriteLine($"1 > 2 : {i1 > i2}");
			Console.WriteLine();


			i2 = null;
			Console.WriteLine($"1 >= null : {i1 >= i2}");
			i2 = 1;
			Console.WriteLine($"1 >= 1 : {i1 >= i2}");
			i2 = 2;
			Console.WriteLine($"1 >= 2 : {i1 >= i2}");
			Console.WriteLine();


			i2 = null;
			Console.WriteLine($"1 < null : {i1 < i2}");
			i2 = 1;
			Console.WriteLine($"1 < 1 : {i1 < i2}");
			i2 = 2;
			Console.WriteLine($"1 < 2 : {i1 < i2}");
			Console.WriteLine();



			i2 = null;
			Console.WriteLine($"1 <= null : {i1 <= i2}");
			i2 = 1;
			Console.WriteLine($"1 <= 1 : {i1 <= i2}");
			i2 = 2;
			Console.WriteLine($"1 <= 2 : {i1 <= i2}");


		}
	}
}

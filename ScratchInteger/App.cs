using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchInteger {
	class App {
		public App() {

		}

		public void Run() {
			this.NullableInt();
			this.StringToInt();
			//Compare();
			GetNext5(1);
			GetNext5(12);
			GetNext5(14);
			GetNext5(15);
			GetNext5(18);
			GetNext5(100);
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

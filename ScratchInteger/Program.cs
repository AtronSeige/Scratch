using System;

namespace ScratchInteger
{
	class Program
	{
		static void Main(string[] args)
		{

			//Compare();
			GetNext5(1);
			GetNext5(12);
			GetNext5(14);
			GetNext5(15);
			GetNext5(18);
			GetNext5(100);

			Console.ReadLine();
		}

		private static void GetNext5(int v)
		{
			var div = v % 5;

			Console.WriteLine(div);
		}

		private static void Compare()
		{
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

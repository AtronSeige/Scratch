using System;

namespace ScratchDecimal
{
    class Program
    {
		static void Main(string[] args)
		{
			decimal d = 1254m;
			Console.WriteLine(d);

			RoundTest(244385.964912281m);
			RoundTest(244385.96491228m);
			RoundTest(244385.9649122m);
			RoundTest(244385.964912m);
			RoundTest(244385.96491m);
			RoundTest(244385.9649m);
			RoundTest(244385.964m);
			RoundTest(244385.96m);

			VATTestFromExcl(244385.97m);
			Console.WriteLine();
			VATTestFromExclWithRoudning(244385.97m);

			Console.ReadLine();
		}


		private static void RoundTest(decimal d)
		{
			Console.WriteLine($"Roundtest {d}");

			Console.WriteLine(Math.Round(d, 4));
			Console.WriteLine(Math.Round(d, 3));
			Console.WriteLine(Math.Round(d, 2));
			Console.WriteLine(Math.Round(d, 1));


		}

		private static void VATTestFromExcl(decimal excl)
		{
			Console.WriteLine("No Rounding during calc");
			Console.WriteLine($"EXCL : {excl}");
			var vat = excl * 0.14m;
			Console.WriteLine($"VAT  :  {vat}");
			var total = excl + vat;
			Console.WriteLine($"Total: {total}");
		}

		private static void VATTestFromExclWithRoudning(decimal excl)
		{
			Console.WriteLine("Rounding during calc");
			Console.WriteLine($"EXCL : {Math.Round(excl, 2)}");
			var vat = Math.Round(excl * 0.14m, 2);
			Console.WriteLine($"VAT  :  {Math.Round(vat, 2)}");
			var total = Math.Round(excl + vat, 2);
			Console.WriteLine($"Total: {Math.Round(total, 2)}");
		}
	}
}

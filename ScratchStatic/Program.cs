using System;

namespace ScratchStatic
{
	class Program
	{
		static void Main(string[] args)
		{
			//Class1Test();
			Class2Test();

			Console.ReadLine();

		}

		private static void Class1Test()
		{
			Console.WriteLine(Class1.i);

			var c = new Class1();

			Console.WriteLine(c.j);

			Class1.i = 666;

			Console.WriteLine(Class1.i);

			Console.WriteLine(c.something());

			Console.WriteLine(Class1.i);
		}

		private static void Class2Test()
		{
			Console.WriteLine(Class2.i);

			//var c = new Class2();

			//Console.WriteLine(c.j);

			Class2.i = 666;

			Console.WriteLine(Class2.i);

			Console.WriteLine(Class2.something());

			Console.WriteLine(Class2.i);
			Console.WriteLine(Class2.j);
		}
	}
}

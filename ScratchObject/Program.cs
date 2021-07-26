using System;
using System.Collections.Generic;

namespace ScratchObject
{
	class Program
	{
		static void Main(string[] args)
		{
			var c = new Class1();
			Console.WriteLine(c.GetType().Name);
			test(c);

			var l = new List<Class1>();
			Console.WriteLine(l.GetType().Name);
			testList(l);


			Console.ReadLine();
		}

		static void test(object o)
		{
			Console.WriteLine(o.GetType().Name);
		}

		static void testList(object o)
		{
			Console.WriteLine(o.GetType().GetGenericArguments()[0].Name);
		}
	}
}

using System;

namespace ScratchBoolean
{
	class Program
	{
		static void Main(string[] args)
		{
			OnlySetFalse();


			//         if (Test1() && Test2())
			//{
			//	Console.WriteLine("True");
			//}
			//else
			//{
			//	Console.WriteLine("False");
			//}

			Console.ReadLine();
		}

		static bool Test1()
		{
			return false;
		}

		static bool Test2()
		{
			return true;
		}


		static void OnlySetFalse()
		{
			var result = true;

			result = result && false;
			result = result && true;

			result = result && false;
			result = result && true;
			//result = false;
			//result = true;



			Console.WriteLine("Result values is " + result.ToString());
		}
	}
}

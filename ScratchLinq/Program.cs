using ScratchLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchLinq
{
	class Program
	{
		static void Main(string[] args)
		{
			//var cars = Car.GenerateList();
			//GroupByTest(cars);

			TestRandom();

			Console.ReadLine();

		}

		private static void GroupByTest(List<Car> cars)
		{
			//show a list of unique Makes
			foreach (var make in cars.GroupBy(g => g.Make))
			{
				Console.WriteLine($"{make.Key} has {make.Count()} cars");

				foreach (var car in make)
				{
					Console.WriteLine($"\t{car.Model}");
				}
			}
		}

		private static void TestRandom()
		{
			var list1 = new List<int>() { 1, 2, 3, 4 };
			var result = list1.Where(i => i > 3).ToList();

			foreach (var item in list1)
			{
				Console.WriteLine(item);
			}
			list1.Add(5);
			foreach (var item in list1)
			{
				Console.WriteLine(item);
			}
		}
	}
}

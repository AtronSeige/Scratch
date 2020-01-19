using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ScratchAnonymousTypes
{
    class Program
    {
		static void Main(string[] args)
		{
			//var l = Car.GenerateList();

			////anon
			//var anon = l.Select( x=> new { blp = x.Make, ewrt = x.Model });
			//anon.ToList().ForEach(x => Console.WriteLine($"{x.blp} {x.ewrt}"));

			//var anon2 = l.Select(x => new { make = x.Make, ewrt = x.Model });
			//anon2.ToList().ForEach(x => Console.WriteLine($"{x.make} {x.ewrt}"));

			//var make = "MK";
			//var model = "MDL";
			//dynamic d = new ExpandoObject();
			//d[make] = "make here";
			//d[model] = "model here";

			//var exp = l.Select(x => new  { d[make] = x.Make });

			TestExpando();

			Console.ReadLine();


		}

		private static void TestExpando()
		{

			var cars = Car.GenerateList();
			//we will get this from the CL
			var oldproperties = new List<String>() { "Make", "Model", "ReleaseYear" };
			var newproperties = new List<String>() { "MK", "MMDL", "YR" };

			//what we want to give to ePPlus
			var exp = new List<ExpandoObject>();

			foreach (var c in cars)
			{
				var expando = new ExpandoObject();
				IDictionary<string, object> mapProps = expando;

				var cp = c.GetType().GetProperties();

				for (int i = 0; i < oldproperties.Count(); i++)
				{
					mapProps.Add(newproperties[i], cp.Where(x => x.Name == oldproperties[i]).First().GetValue(c));
				}

				exp.Add(expando);
			}

			//foreach(var o in exp)
			//{
			//	Console.WriteLine(o.);
			//}
			//exp.ForEach(x => Console.WriteLine($"{x.MK}"));

		}
	}

	public class Car
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int ReleaseYear { get; set; }

		public Car(string make, string model, int releaseYear)
		{
			this.Make = make;
			this.Model = model;
			this.ReleaseYear = releaseYear;
		}

		internal static List<Car> GenerateList()
		{
			var result = new List<Car>();

			result.Add(new Car("Toyota", "Carolla", 1950));
			result.Add(new Car("Toyota", "Yaris", 2000));
			result.Add(new Car("Toyota", "Hilux", 1990));
			result.Add(new Car("Nissan", "Juke", 2010));
			result.Add(new Car("Nissan", "Trail Blazer", 1995));
			result.Add(new Car("Nissan", "Micra", 2018));
			result.Add(new Car("BMW", "M3", 1980));
			result.Add(new Car("BMW", "X5", 2008));
			result.Add(new Car("BMW", "M6", 2003));
			result.Add(new Car("Merc", "S Class", 2001));


			return result;
		}
	}
}

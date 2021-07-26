using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchLinq.Models
{
	public class Car
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int ReleaseYear { get; set; }
		public int Rating { get; set; }

		public Car(string make, string model, int releaseYear, int rating)
		{
			this.Make = make;
			this.Model = model;
			this.ReleaseYear = releaseYear;
			this.Rating = rating;
		}

		public static List<Car> GenerateList(int repeats = 1)
		{
			var result = new List<Car>();

			for (int i = 0; i < repeats; i++)
			{
				result.Add(new Car("Toyota", "Carolla", 1950, 9));
				result.Add(new Car("Toyota", "Yaris", 2000, 6));
				result.Add(new Car("Toyota", "Hilux", 1990, 3));
				result.Add(new Car("Nissan", "Juke", 2010, 10));
				result.Add(new Car("Nissan", "Trail Blazer", 1995, 4));
				result.Add(new Car("Nissan", "Micra", 2018, 2));
				result.Add(new Car("BMW", "M3", 1980, 6));
				result.Add(new Car("BMW", "X5", 2008, 7));
				result.Add(new Car("BMW", "M6", 2003, 5));
				result.Add(new Car("Merc", "S Class", 2001, 8));
			}

			return result;
		}
	}
}

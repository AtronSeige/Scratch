using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchRandom {
	public static class Extentions {
		//Function to get a random number 
		private static readonly Random rnd = new Random();
		private static readonly object syncLock = new object();


		public static int RandomNumber(int min, int max) {
			lock (syncLock) { // synchronize
				return rnd.Next(min, max);
			}
		}


		public static T Random<T>(this IEnumerable<T> source) {
			//if not data, return null (default)
			if (source == null || !source.Any()) return default(T);

			lock (syncLock) { // synchronize
				return source.ElementAt(rnd.Next(0, source.Count() - 1));
			}
		}

		public static T Random2<T>(this IEnumerable<T> source) {
			//if not data, return null (default)
			if (source == null || !source.Any()) return default(T);

			return source.OrderBy(x => rnd.NextDouble()).Take(1).Single();

		}

	}
}

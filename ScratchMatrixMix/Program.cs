using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchMatrixMix {
	internal class Program {
		static void Main(string[] args) {

			List<string> values = new List<string> { "one", "two", "three", "four" };

			// The width of the array
			int columnCount = values.Count;
			// The height of the array
			int rowCount = columnCount * columnCount;
			string[,] matrix = new string[columnCount, rowCount];

			int x = 0;
			int count = 0;
			foreach (string value in values) {
				for (int y = 0; y < rowCount; y++) {
					matrix[x, y] = value;
					x++;
					if (x == columnCount) {
						x = 0;
					}
				}
				count++;
				x = count;
			}

			for (int i = 0; i < rowCount; i++) {
				string s = string.Empty;
				for (int j = 0; j < columnCount; j++) {
					s += matrix[j, i];
				}
				Console.WriteLine($"{i}. {s}");
			}

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}

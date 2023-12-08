using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// See also: https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer

namespace ScratchPermutations {
	internal class PermutateString {

		private List<string> incomingValues;
		private List<string> permutatedValues;

		public PermutateString(List<string> valuesToPermutate) {
			incomingValues = valuesToPermutate;
		}

		//static void Main(string[] args) {
		//	PrintResult(
		//		Permute(new int[] { 1, 2, 3 })
		//	);

		//	Console.ReadLine();
		//}

		internal IList<IList<string>> Permute() {
			List<IList<string>> list = new List<IList<string>>();
			return DoPermute(0, incomingValues.Count - 1, list);
		}

		internal IList<IList<string>> DoPermute(int start, int end, IList<IList<string>> list) {
			if (start == end) {
				// We have one of our possible n! solutions,
				// add it to the list.
				list.Add(new List<string>(incomingValues));
			} else {
				for (int i = start; i <= end; i++) {
					Swap(incomingValues[start], incomingValues[i]);
					DoPermute(start + 1, end, list);
					Swap(incomingValues[start], incomingValues[i]);
				}
			}

			return list;
		}

		internal void Swap(string a, string b) {
			string temp = a;
			a = b;
			b = temp;
		}

		internal void PrintResult(IList<IList<string>> lists) {
			Console.WriteLine("[");
			foreach (IList<string> list in lists) {
				Console.WriteLine($"    [{string.Join(",", list)}]");
			}
			Console.WriteLine("]");
		}
	}
}

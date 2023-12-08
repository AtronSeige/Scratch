using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Source: https://chadgolden.com/blog/finding-all-the-permutations-of-an-array-in-c-sharp

namespace ScratchPermutations {
	internal class Program {
		static void Main(string[] args) {
			PrintResult(
				Permute(new int[] { 1, 2, 3 })
			);

			PermutateString ps = new PermutateString(new List<string> { "one", "two", "three", "four" });
			IList<IList<string>> result = ps.Permute();
			ps.PrintResult( result );

			Console.ReadLine();
		}

		static IList<IList<int>> Permute(int[] nums) {
			var list = new List<IList<int>>();
			return DoPermute(nums, 0, nums.Length - 1, list);
		}

		static IList<IList<int>> DoPermute(int[] nums, int start, int end, IList<IList<int>> list) {
			if (start == end) {
				// We have one of our possible n! solutions,
				// add it to the list.
				list.Add(new List<int>(nums));
			} else {
				for (int i = start; i <= end; i++) {
					Swap(ref nums[start], ref nums[i]);
					DoPermute(nums, start + 1, end, list);
					Swap(ref nums[start], ref nums[i]);
				}
			}

			return list;
		}

		static void Swap(ref int a, ref int b) {
			int temp = a;
			a = b;
			b = temp;
		}

		static void PrintResult(IList<IList<int>> lists) {
			Console.WriteLine("[");
			foreach (IList<int> list in lists) {
				Console.WriteLine($"    [{string.Join(",", list)}]");
			}
			Console.WriteLine("]");
		}
	}
}

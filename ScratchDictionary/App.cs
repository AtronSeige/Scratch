using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchDictionary {
	class App {
		public App() {

		}

		public void Run() {
			Dictionary<Numbers, string> dOrdered = new Dictionary<Numbers, string>();
			dOrdered.Add(Numbers.One, "1");
			dOrdered.Add(Numbers.Two, "2");
			dOrdered.Add(Numbers.Three, "3");
			dOrdered.Add(Numbers.Four, "4");
			dOrdered.Add(Numbers.Five, "5");

			Dictionary<Numbers, string> dUnOrdered = new Dictionary<Numbers, string>();
			dUnOrdered.Add(Numbers.Five, "5");
			dUnOrdered.Add(Numbers.Four, "4");
			dUnOrdered.Add(Numbers.One, "1");
			dUnOrdered.Add(Numbers.Three, "3");
			dUnOrdered.Add(Numbers.Two, "2");

			Reorder(dOrdered, dUnOrdered);

			//TestKey();
			//TestCaseInsensitive();
			TestToString();
		}

		private static void Reorder(Dictionary<Numbers, string> dOrdered, Dictionary<Numbers, string> dUnOrdered) {

			// Use OrderBy method. This will sort the items in the order they are created as enums
			foreach (var item in dUnOrdered.OrderBy(i => i.Key)) {
				Console.WriteLine(item);
			}
		}

		enum Numbers {
			One,
			Two,
			Three,
			Four,
			Five,
		}

		private void TestKey() {
			Dictionary<int, string> d = new Dictionary<int, string>();

			d.Add(1, "One");
			d.Add(2, "Two");
			d.Add(3, "Three");

			Console.WriteLine($"d1 = {d[1]}");
			//Console.WriteLine($"d4 = {d[4]}");
		}

		private void TestCaseInsensitive() {
			// Case insensitive dictionary
			Dictionary<string, string> d2 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

			d2.Add("one", "one");

			Console.WriteLine($"D1 has one [{d2.ContainsKey("one")}]");
			Console.WriteLine($"D1 has oNe [{d2.ContainsKey("oNe")}]");
			Console.WriteLine($"D1 has blue [{d2.ContainsKey("blue")}]");

		}

		private void TestToString() {
			Dictionary<string, string> d = new Dictionary<string, string>();

			d.Add("one", "een");
			d.Add("two", "twee");
			d.Add("three", "drie");

			string s = string.Empty;

			IEnumerable<string> l = d.Select(x => string.Format("<li>{0} - {1}</li>", x.Key, x.Value));

			s = string.Join("", l);

			Console.WriteLine(s);


		}
	}
}

using System;
using System.Collections.Generic;

namespace ScratchNull {
	class App {

		public void Run() {
			string s = null;
			int? i = null;
			decimal? d = null;
			object o = null;
			DateTime? dt = null;

			//AreNullsEqual(s, i, d, o, dt);
			//HaveType(s, i, d, o, dt);

			ShorthandTest();

			NullConditional();

			NullCoalescing();

		}

		private static void ShorthandTest() {
			string nullA = null;
			string nullB = null;
			string valueA = "Hi";
			string valueB = "Bye";

			var tmp = nullA + valueA;
			tmp = valueA + nullA;

			BothHaveValueOrBothNull(nullA, nullB);
			BothHaveValueOrBothNull(valueA, nullB);
			BothHaveValueOrBothNull(nullA, valueB);
			BothHaveValueOrBothNull(valueA, valueB);

		}

		private static void BothHaveValueOrBothNull(string a, string b) {
			Console.WriteLine("-------------------------");
			Console.WriteLine($"Testing a [{a}], b [{b}]");
			if (a == null && b == null) {
				Console.WriteLine("both are null");
			}

			if (a != null && b == null) {
				Console.WriteLine("b are null");
			}

			if (a == null && b != null) {
				Console.WriteLine("a are null");
			}

			if (a != null && b != null) {
				Console.WriteLine("both are not null");
			}

			Console.WriteLine("---Shorthand---");
			if (a == null & b == null) {
				Console.WriteLine("[sh] both are null or not null");
			} else {
				Console.WriteLine("[sh] either is null");
			}

			//This check is for if BOTH are null
			//if (a == null & b == null)
			//{
			//    Console.WriteLine("[sh] both are null");
			//}
			//else
			//{
			//    Console.WriteLine("[sh] one or both has a value");
			//}
		}

		private static void HaveType(string s, int? i, decimal? d, object o, DateTime? dt) {

			//Console.WriteLine($"string type : [{s.GetType().ToString()}]"); //Error, null ref
			//Console.WriteLine($"int? type : [{i.GetType().ToString()}]"); //Error, null ref
			//Console.WriteLine($"decimal? type : [{d.GetType().ToString()}]"); //Error, null ref
			//Console.WriteLine($"object type : [{o.GetType().ToString()}]"); //Error, null ref
			//Console.WriteLine($"datetime? type : [{dt.GetType().ToString()}]"); //Error
		}

		private static void AreNullsEqual(string s, int? i, decimal? d, object o, DateTime? dt) {

			Console.WriteLine($"Is string equal to object : [{s == o}]"); //True
			Console.WriteLine($"Is int equal to decimal : [{i == d}]");  //True
			Console.WriteLine($"Is decimal equal to int : [{d == i}]"); //True

			//Console.WriteLine($"Is string equal to datetime? : [{ s == dt }]"); //Not allowed
			//Console.WriteLine($"Is string equal to int? : [{ s == i }]"); //Not allowed
			//Console.WriteLine($"Is string equal to decimal? : [{ s == d }]"); //Not allowed
			//Console.WriteLine($"Is int equal to object : [{i == o}]");  //Not allowed
			//Console.WriteLine($"Is decimal equal to object : [{d == o}]"); //Not allowed
			//Console.WriteLine($"Is int equal to datetime : [{i == dt}]"); //Not allowed
			//Console.WriteLine($"Is decimal equal to datetime : [{d == dt}]"); //Not allowed

			//Console.WriteLine($"Is datetime equal to int : [{ dt == i}]"); //Not allowed
			//Console.WriteLine($"Is datetime equal to object : [{ dt == d}]"); //Not allowed
			//Console.WriteLine($"Is datetime equal to object : [{ dt == o}]"); //Not allowed
		}

		//Get the type, even if the object is null
		private static Type GetRealType<T>(T obj) {
			Type t;

			if (obj == null)
				t = typeof(T);
			else
				t = obj.GetType();

			return t;
		}



		private void NullConditional() {

			/* Available in C# 6 and later, a null-conditional operator applies a member access, ?., 
		 * or element access, ?[], operation to its operand only if that operand evaluates to 
		 * non-null; otherwise, it returns null. That is,
		 *		If a evaluates to null, the result of a?.x or a?[x] is null.
		 *		If a evaluates to non-null, the result of a?.x or a?[x] is the same as the result of a.x or a[x], respectively.
		 */

			test t = null;

			if (t?.Id > 0) {
				Console.WriteLine("null t, null id. greater than 0");
			} else {
				Console.WriteLine("null t, null id. false");
			}

			t = new test();

			if (t?.Id > 0) {
				Console.WriteLine("t instance, null id. greater than 0");
			} else {
				Console.WriteLine("t instance, null id. false");
			}

			t.Id = 5;

			if (t?.Id > 0) {
				Console.WriteLine("t instance, id 5. greater than 0");
			} else {
				Console.WriteLine("t instance, id 5. false");
			}


			if (t?.Name?.Length > 0) {
				Console.WriteLine("t instance, null name. length greater than 0");
			} else {
				Console.WriteLine("t instance, null name. false");
			}

			t.Name = "JacoTest";

			if (t?.Name?.Length > 0) {
				Console.WriteLine("t instance, name JacoTest. length greater than 0");
			} else {
				Console.WriteLine("t instance, name JacoTest. false");
			}

			t = null;

			if (t?.Name?.Length > 0) {
				Console.WriteLine("null t, null name. length greater than 0");
			} else {
				Console.WriteLine("null t, null name. false");
			}

			if (t?.Ages?.Count > 0) {
				Console.WriteLine("null t, null ages. Any");
			} else {
				Console.WriteLine("null t, null ages. false");
			}

			t = new test();

			if (t?.Ages?.Count > 0) {
				Console.WriteLine("t instance, null ages. Any");
			} else {
				Console.WriteLine("t instance, null ages. false");
			}

			t.Ages = new List<int>();

			if (t?.Ages?.Count > 0) {
				Console.WriteLine("t instance, ages instance. Any");
			} else {
				Console.WriteLine("t instance, null instance. false");
			}

			t.Ages.Add(1);

			if (t?.Ages?.Count > 0) {
				Console.WriteLine("t instance, ages instance, 1 item. Any");
			} else {
				Console.WriteLine("t instance, null instance, 1 item. false");
			}
		}

		class test {
			public int? Id { get; set; }
			public string Name { get; set; }
			public List<int> Ages { get; set; }
		}

		private void NullCoalescing() {
			/*
		 * Only available from C# 8
		 * The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, 
		 * it evaluates the right-hand operand and returns its result. The ?? operator doesn't evaluate its right-hand 
		 * operand if the left-hand operand evaluates to non-null.
		 */

			// Create a null object
			int? a = null;

			// If the variable is null, then set it to the right hand value, otherwise keep it as it is.
			//a ??= 10;
		}
	}
}

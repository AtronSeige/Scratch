using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchCollection
{
	class Program
	{
		static void Main(string[] args)
		{
			test t = new test();
			t.Name = "Test_1";
			t.lst.Add("one");
			t.lst.Add("two");
			t.lst.Add("three");
			Console.WriteLine(t.ToString());

			test t_1 = new test();
			t_1.Name = "Test_X";
			t_1.lst.Add("one");
			t_1.lst.Add("two");
			t_1.lst.Add("three");
			Console.WriteLine(t_1.ToString());

			test t_2 = new test();
			t_2.Name = "Test_G";
			t_2.lst.Add("one");
			t_2.lst.Add("two");
			t_2.lst.Add("three");
			Console.WriteLine(t_2.ToString());

			//test1 t1 = new test1();
			//t1.Name = "Test1";
			//t1.lst.Add("1");
			//t1.lst.Add("2");
			//t1.lst.Add("3");
			//Console.WriteLine(t1.ToString());

			//test2 t2 = new test2();
			//t2.Name = "Test2";
			//t2.lst.Add("four");
			//t2.lst.Add("five");
			//t2.lst.Add("six");
			//Console.WriteLine(t2.ToString());

			test3 t3 = new test3();
			t3.Name = "Test3";
			t3.lst.Add(t);
			t3.lst.Add(t_1);
			t3.lst.Add(t_2);
			Console.WriteLine(t3.ToString());

			// This throws an Exception!
			//List<string> strings = null;
			//foreach (string s in strings) {
			//	Console.WriteLine("what");
			//}

			Console.ReadLine();
		}
	}

	public class test
	{
		public string Name { get; set; }
		public List<string> lst { get; set; }

		public test()
		{
			this.lst = new List<string>();
		}

		public override string ToString()
		{
			return this.Name + " - " + String.Join(",", this.lst.ToArray());
		}
	}

	public class test1
	{
		public string Name { get; set; }

		private List<string> _lst;
		public List<string> lst
		{
			get
			{
				return _lst;
			}
			set { _lst = value; }
		}

		public test1()
		{
			this._lst = new List<string>();
		}

		public override string ToString()
		{
			return this.Name + " - " + String.Join(",", this.lst.ToArray());
		}
	}

	public class test2
	{
		public string Name { get; set; }
		private List<string> _lst;
		public virtual List<string> lst
		{
			get { return _lst; }
			set { _lst = value; }
		}

		public test2()
		{
			this._lst = new List<string>();
		}

		public override string ToString()
		{
			return this.Name + " - " + String.Join(",", this.lst.ToArray());
		}
	}

	public class test3
	{
		public string Name { get; set; }
		private List<test> _lst;
		public List<test> lst
		{
			get
			{
				this._lst = this._lst.OrderBy(x => x.Name).ToList();
				return this._lst;
			}
			set
			{
				this._lst = value;
			}
		}

		public test3()
		{
			this._lst = new List<test>();
		}

		public override string ToString()
		{
			return this.Name + " - " + string.Join(",", this.lst.Select(x => x.Name));
		}
	}
}

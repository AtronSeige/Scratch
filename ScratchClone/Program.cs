using System;
using System.Collections.Generic;
using System.Reflection;

namespace ScratchClone
{
	class Program
	{
		static void Main(string[] args)
		{
			//create data
			City jhb = new City { Name = "Jhb" };

			Address aPhysical = new Address { Line1 = "Physical", City = jhb };
			Address aPostal = new Address { Line1 = "Postal", City = jhb };

			Contact c = new Contact { Name = "Jaco", Surname = "Hamilton-Attwell" };
			c.Addresses.AddRange(new List<Address> { aPhysical, aPostal });

			Console.WriteLine("Contact: {0} {1}", c.Name, c.Surname);
			foreach (Address a in c.Addresses)
			{
				Console.WriteLine("Address: {0}, {1}", a.Line1, a.City.Name);
			}



			Contact c2 = Copy<Contact>(c);

			Console.WriteLine("----CLONED-----");

			Console.WriteLine("Contact: {0} {1}", c2.Name, c2.Surname);
			foreach (Address a in c2.Addresses)
			{
				Console.WriteLine("Address: {0}, {1}", a.Line1, a.City.Name);
			}

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();


			Console.ReadLine();
		}

		//public static T Copy<T>(this T original, List<string> propertyExcludeList = null)
		public static T Copy<T>(T original, List<string> propertyExcludeList = null)
		{
			if (propertyExcludeList == null)
			{
				propertyExcludeList = new List<string>();
			}

			T copy = Activator.CreateInstance<T>();
			FieldInfo[] fiList = typeof(T).GetFields();
			foreach (FieldInfo fi in fiList)
			{
				if (!propertyExcludeList.Contains(fi.Name))
				{
					if (fi.GetValue(copy) != fi.GetValue(original))
					{
						fi.SetValue(copy, fi.GetValue(original));
					}
				}
			}

			PropertyInfo[] piList = typeof(T).GetProperties();
			foreach (PropertyInfo pi in piList)
			{
				if (!propertyExcludeList.Contains(pi.Name))
				{
					if (pi.GetValue(copy, null) != pi.GetValue(original, null))
					{
						pi.SetValue(copy, pi.GetValue(original, null), null);
					}
				}
			}
			return copy;

		}
	}
}

using ScratchHelpers;
using System;
using System.Xml;

namespace ScratchDateTime
{
	class Program
	{
		static void Main(string[] args) {

			try {
				App a = new App();
				a.Run();
			} catch (Exception ex) {
				Console.WriteLine(ex.ToFullString());
			}

			Console.WriteLine("All done. Press any key...");
			Console.ReadLine();
		}

	}
}

using ScratchHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScratchString
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

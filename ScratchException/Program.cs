﻿using ScratchHelpers;
using System;
using System.Collections;
using System.Text;

namespace ScratchException {
	class Program {
		private static void Main(string[] args) {

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

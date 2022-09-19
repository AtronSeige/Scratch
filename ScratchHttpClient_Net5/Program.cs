using System;

namespace ScratchHttpClient {
	internal class Program {
		static void Main(string[] args) {
			try {
				App a = new App();
				a.Run();
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				
			}
			Console.WriteLine("Done!");
			Console.ReadLine();
		}
	}
}

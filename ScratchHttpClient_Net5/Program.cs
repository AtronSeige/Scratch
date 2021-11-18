using System;

namespace ScratchHttpClient_Net5 {
	internal class Program {
		static void Main(string[] args) {
			try {
				App a = new App();
				a.Run();
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				Console.ReadLine();
			}

		}
	}
}

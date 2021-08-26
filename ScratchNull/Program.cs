using ScratchHelpers;
using System;

namespace ScratchNull {
	class Program {
		static void Main(string[] args) {
			try {
				App a = new App();
				a.Run();
			} catch (Exception ex) {
				Console.WriteLine(ex.ToFullString());
			}
		}
	}
}

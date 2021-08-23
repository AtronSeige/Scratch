using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchEnum {
	class App {
		public App() {

		}

		public void Run() {
			Console.WriteLine(Gender.Female);
			Console.WriteLine((int)Gender.Male);

			Gender g = (Gender)2;

			Sex s = (Sex)1;
			Sex sM = (Sex)Enum.Parse(typeof(Sex), "M");
			Sex sF = (Sex)Enum.Parse(typeof(Sex), "F");
			//This does nto work because the case is invalid
			//Sex s3 = (Sex)Enum.Parse(typeof(Sex), "m");


			//Convert one enum to another 
			//This only works if the INT value exists in the other.
			//In this case, converting sM (0) will set Gender to 0, which is useless, as we do not have a 0 value in Gender. It does NOT throw an error.
			Gender conv = (Gender)sF;
			WriteStuff(conv);

			//Random: this sets gender to 100, even though the value does not exist
			Gender convInt = (Gender)100;
			WriteStuff(convInt);
			//Use Enum.IsDefined to find out if a value exists in a Enum
			WriteStuff("100 Exists in Gender: " + Enum.IsDefined(typeof(Gender), 100));
			WriteStuff("1 Exists in Gender: " + Enum.IsDefined(typeof(Gender), 1));
			WriteStuff("FighterJet  Exists in Gender: " + Enum.IsDefined(typeof(Gender), "FighterJet"));

			WriteStuff("sM Exists in Gender: " + Enum.IsDefined(typeof(Gender), (int)sM));
			WriteStuff("sF Exists in Gender: " + Enum.IsDefined(typeof(Gender), (int)sF));

			bubbles b;

			b = bubbles.one;
			Console.WriteLine(b.ToString());

			b = (bubbles)2;
			Console.WriteLine(b.ToString());

			b = (bubbles)3;
			Console.WriteLine(b.ToString());

			b = (bubbles)4;
			Console.WriteLine(b.ToString());

			Enum.TryParse("one", out b);
			Console.WriteLine(b.ToString());

		}



		private void WriteStuff(object msg, bool isError = false) {
			if (isError) Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(msg);
			if (isError) Console.ResetColor();
		}

		//private static void WriteStuff(string msg, bool isError = false)
		//{
		//    if (isError) Console.ForegroundColor = ConsoleColor.Red;
		//    Console.WriteLine(msg);
		//    if (isError) Console.ResetColor();
		//}



		public enum Gender {
			Female = 1,
			Male = 2,
			FighterJet = 3
		}

		public enum Sex {
			M, F
		}

		enum bubbles {
			one = 1,
			two = 2,
			three
		}
	}
}

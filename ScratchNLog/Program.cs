using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://github.com/NLog/NLog/wiki/Tutorial

namespace ScratchNLog {
	internal class Program {
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static void Main(string[] args) {
			logger.Info("ScratchMLog has started.");

			Bubbles bubbles = new Bubbles();

			try {
				// Logging exceptions!
				Exception e3 = new Exception("I AM THREE");
				Exception e2 = new Exception("I AM TWO", e3);
				throw new Exception("I AM ONE", e2);
			} catch (Exception e) {
				logger.Error(e);
			}


			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}

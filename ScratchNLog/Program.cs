using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScratchNLog {
	internal class Program {
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static void Main(string[] args) {
			logger.Info("ScratchMLog has started.");

			Bubbles bubbles = new Bubbles();

			Console.ReadLine();
		}
	}
}

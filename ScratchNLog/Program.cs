using NLog;
using System;

// https://github.com/NLog/NLog/wiki/Tutorial
// https://github.com/NLog/NLog/wiki/How-to-use-structured-logging#transform-captured-properties

namespace ScratchNLog {
	internal class Program {
		private static ILogger logger;

		static void Main(string[] args) {

			//Note: The null checks are needed because Bubbles logs itself in the constructor.
			// If the values had not been null, then the extra checks are not required.
			// This has to be registered before LogManager.GetCurrentClassLogger() is called. 
			LogManager.Setup().SetupSerialization(s =>
				s.RegisterObjectTransformation<Bubbles>(b =>
					new {
						b.ID,
						Name = b.Name?? "null",
						b.Duration,
						b.Radius,
						//bubbles.SecretOne, // do not serialize
						SecretTwo = b.SecretTwo != null ? b.SecretTwo.Substring(0, 5) : "null", // Mask
						SecretThree = "88888888888" // Replace
					}
				)
			);

			logger = LogManager.GetCurrentClassLogger();

			logger.Info("ScratchMLog has started.");

			Bubbles bubbles = new Bubbles();
			bubbles.ID = 1;
			bubbles.Name = "Bubbles";
			bubbles.Duration = DateTime.Now;
			bubbles.Radius = 1.5m;
			bubbles.SecretOne = "TopSecret";
			bubbles.SecretTwo = "123456789";
			bubbles.SecretThree = "abcdefgh";

			logger.Info("Info {@bubbles}", bubbles);

			try {
				// Logging exceptions!
				Exception e3 = new Exception("I AM THREE");
				Exception e2 = new Exception("I AM TWO", e3);
				throw new Exception("I AM ONE", e2);
			} catch (Exception e) {
				logger.Error(e);
			}

			logger.Info("post transformation {@bubbles}", bubbles);

			Console.WriteLine("Done");
			Console.ReadLine();
		}
	}
}

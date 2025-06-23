using NLog;
using System;
using System.Collections.Generic;

// https://github.com/NLog/NLog/wiki/Tutorial
// https://github.com/NLog/NLog/wiki/How-to-use-structured-logging#transform-captured-properties

namespace ScratchNLog {
	internal class Program {
		private static Logger logger;

		static void Main(string[] args) {

			//Note: The null checks are needed because Bubbles logs itself in the constructor.
			// If the values had not been null, then the extra checks are not required.
			// This has to be registered before LogManager.GetCurrentClassLogger() is called. 
			//LogManager.Setup().SetupSerialization(s =>
			//	s.RegisterObjectTransformation<Bubbles>(b =>
			//		new {
			//			b.ID,
			//			Name = b.Name?? "null",
			//			b.Duration,
			//			b.Radius,
			//			//bubbles.SecretOne, // do not serialize
			//			SecretTwo = b.SecretTwo != null ? b.SecretTwo.Substring(0, 5) : "null", // Mask
			//			SecretThree = "88888888888", // Replace
			//		}
			//	)
			//);

			RegisterInterfactLogTransformations();

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
			logger.WithProperty("bubbles", bubbles).Info("BUBBLES!!!");

			ITestLogTransform one = new LogTransformOne() { ID = 1, Name = "One", Email = "one@one.com", Token = "THIS IS A SECURE TOKEN", TokenExpiry = DateTime.Now };
			logger.Info("One {@one}", one);
			logger.WithProperty("one", one).Info("ONE", one);

			ITestLogTransform two = new LogTransformTwo() { ID = 2, Name = "Two", Email = "two@two.com", Password = "Password01", Secret = "Ninja" };
			logger.Info("Two {@two}", two);

			try {
				// Logging exceptions!
				Exception e3 = new Exception("I AM THREE");
				Exception e2 = new Exception("I AM TWO", e3);
				throw new Exception("I AM ONE", e2);
			} catch (Exception e) {
				logger.Error(e);
			}

			logger.Info("post transformation {@bubbles}", bubbles);

			logger.Info("sentence {@object}", new { bubbles.ID, bubbles.Name });

			logger.WithProperty("ID", bubbles.ID)
				.WithProperty("Name", bubbles.Name)
				.Info("test WithProperty");

			logger.WithProperties(new Dictionary<string, object>() {
				["ID"] = bubbles.ID,
				["Name"] = bubbles.Name
			})
				.Info("test WithProperties1");

			logger.WithProperties(new Dictionary<string, object>() { { "ID", bubbles.ID }, { "Name", bubbles.Name } })
				.Info("test WithProperties2");

			Dictionary<string, object> properties = new Dictionary<string, object>() {
				{ "ID", bubbles.ID },
				{ "Name", bubbles.Name }
			};

			logger.WithProperties(properties)
				.Info("test WithProperties3");

			string[] array = new string[] { "One", "Two", "Three" };
			logger.Info("test WithArray {@array}", array);

			//array = null;
			////logger.Info("count null {count}", array.Length);

			Console.WriteLine("Done");
			Console.ReadLine();
		}

		/// <summary>
		/// A method to add all class transformation to NLog for interfaces that require transformation.
		/// </summary>
		public static void RegisterInterfactLogTransformations() {
			// Register a transformation for each interface, the reflection will find the specified method for each class that implements the interface and call it.
			LogManager.Setup().SetupSerialization(s =>
				s.RegisterObjectTransformation<ITestLogTransform>(o => {
					var method = o.GetType().GetMethod("GetNLogTransformationObject", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
					if (method != null) {
						return method.Invoke(o, null);
					}
					return o;
				})
			);
		}
	}
}

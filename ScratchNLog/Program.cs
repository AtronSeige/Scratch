using NLog;
using System;
using System.Collections.Generic;

// https://github.com/NLog/NLog/wiki/Tutorial
// https://github.com/NLog/NLog/wiki/How-to-use-structured-logging#transform-captured-properties

namespace ScratchNLog {
	internal class Program {
		private static Logger logger;

		static void Main(string[] args) {
			// This is the main entry point for the application.
			// It will run the Run method which contains the main logic.
			//Run();
			// Uncomment to see a small example of logging with properties.
			SmallExample();

			Console.WriteLine("Done");
			Console.ReadLine();
		}

		public static void Run() {

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

			logger.Info("ScratchNLog has started.");

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

		public static void SmallExample() {

			Logger logger = LogManager.GetCurrentClassLogger();

			SmallObj s1 = new SmallObj();
			s1.ID = 1;
			s1.Name = "Bubbles";

			SmallObj s2 = new SmallObj();
			s2.ID = 2;
			s2.Name = "Galore";

			// The @ sign tells NLog to deconstruct the object to properties.
			logger.Info("Full object in message {@s1}", s1);

			logger.WithProperty("Small1", s1).Info("Full s1 object in event properties");
			logger.WithProperty("Small1", s1).WithProperty("Small2", s2).Info("Full both object in event properties, added individually.");
			logger.WithProperties(new Dictionary<string, object>() {
				{ "Small1", s1 },
				{ "Small2", s2 }
			}).Info("Full both object in event properties, added as a dictionary.");
		}

		internal class SmallObj {
			public int ID { get; set; }
			public string Name { get; set; }
		}
	}
}

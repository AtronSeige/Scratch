using NLog;
using System;

namespace ScratchNLog {
	public class Bubbles {
		public int ID { get; set; }
		public string Name { get; set; }
		public DateTime Duration { get; set; }
		public decimal Radius { get; set; }

		public string SecretOne { get; set; }
		public string SecretTwo { get; set; }
		public string SecretThree { get; set; }

		private Logger logger = LogManager.GetCurrentClassLogger();
		private HiddenData Hidden { get; set; } = new HiddenData();

		private class HiddenData {

			public HiddenData() {
					LogManager.Setup().SetupSerialization(s =>
					s.RegisterObjectTransformation<HiddenData>(hd =>
						new {
							TopSecretMask = hd.TopSecret != null ? hd.TopSecret.Substring(0, 5) : "null", // Mask With new Name,
						}
					)
				);
			}

			public string TopSecret { get; set; }
		}


		public Bubbles() {
			//logger.Info("Bubbles Constructed");

			LogManager.Setup().SetupSerialization(s =>
				s.RegisterObjectTransformation<Bubbles>(b =>
					new {
						b.ID,
						Name = b.Name ?? "null",
						b.Duration,
						b.Radius,
						//bubbles.SecretOne, // do not serialize
						SecretTwo = b.SecretTwo != null ? b.SecretTwo.Substring(0, 5) : "null", // Mask
						SecretThree = "88888888888", // Replace
						b.Hidden
					}
				)
			);

			this.Hidden.TopSecret = "TopSecretHiddenData";

			//// THE @ sign tells NLog to deconstruct the object to properties.
			//logger.Info("new {@bubbles}", this);

			//logger.Info("hidden {@hidden}", this.Hidden);
		}
	}
}

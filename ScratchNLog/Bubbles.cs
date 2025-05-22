using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public Bubbles() {
			logger.Info("Bubbles Constructed");
			// THE @ sign tells NLog to deconstruct the object to properties.
			logger.Info("new {@bubbles}", this);
		}
	}
}

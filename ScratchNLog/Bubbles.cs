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

		private Logger logger = LogManager.GetCurrentClassLogger();

		public Bubbles() {
			logger.Info("Bubbles Constructed");
			logger.Info(this);
		}
	}
}

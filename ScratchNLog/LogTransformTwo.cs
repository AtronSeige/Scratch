using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchNLog {
	internal class LogTransformTwo :ITestLogTransform {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public string Password { get; set; }
		public string Secret { get; set; }

		public LogTransformTwo() {
			LogManager.Setup().SetupSerialization(s =>
				s.RegisterObjectTransformation<LogTransformTwo>(two =>
					new {
						Password_LAST4 = two.Password != null ? two.Password.Substring(0, 4) : "null", // Mask With new Name,
						Secret_NULLED = (string) null // Nulled with new Name
					}
				)
			);
		}
	}
}

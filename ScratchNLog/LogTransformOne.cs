using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchNLog {
	internal class LogTransformOne :ITestLogTransform {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public string Token { get; set; }
		public DateTime? TokenExpiry { get; set; }

		public LogTransformOne() {

			LogManager.Setup().SetupSerialization(s =>
					s.RegisterObjectTransformation<LogTransformOne>(one =>
						new {
							Token_LAST4 = one.Token != null ? one.Token.Substring(0, 4) : "null", // Mask With new Name,
							TokenExpiry_NULLED = (DateTime?)null // Nulled with new Name
						}
					)
				);
		}
	}
}

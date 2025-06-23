using NLog;
using System;

namespace ScratchNLog {
	internal class LogTransformOne : ITestLogTransform {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public string Token { get; set; }
		public DateTime? TokenExpiry { get; set; }

		public object GetNLogTransformationObject() {
			return new {
				this.Name,
				Token_First4 = this.Token != null ? this.Token.Substring(0, 4) : "null",
				TokenExpiry_NULLED = (DateTime?)null
			};
		}
	}
}

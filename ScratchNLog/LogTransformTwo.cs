using NLog;

namespace ScratchNLog {
	internal class LogTransformTwo : ITestLogTransform {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public string Password { get; set; }
		public string Secret { get; set; }

		public object GetNLogTransformationObject() {
			return new {
				this.Name,
				Password_First4 = this.Password != null ? this.Password.Substring(0, 4) : "null", // Masked With new Name,
				Secret_NULLED = (string)null // Nulled with new Name
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchExtensions {
	public static class Extensions {

		public static string Mask(this string value, int maskLength = 4) {
			if (string.IsNullOrWhiteSpace(value)) {
				return "null";
			}
			if (maskLength < 0) {
				maskLength = 4;
			}
			if (value.Length <= maskLength) {
				return new string('*', value.Length);
			}
			StringBuilder maskedValue = new StringBuilder();
			maskedValue.Append(new string('*', maskLength));
			maskedValue.Append(value.Substring(maskLength));
			return maskedValue.ToString();
		}

	}
}

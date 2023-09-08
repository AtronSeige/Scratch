using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScratchFile {
	/// <summary>
	/// This is the definition for the error model.
	/// </summary>
	[XmlType("Error")]
	public class Error {
		/// <summary>
		/// This is the definition for the error message.
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }
		/// <summary>
		/// This is the definition for the error details.
		/// </summary>
		[JsonProperty("details")]
		public string Details { get; set; }
	}
}

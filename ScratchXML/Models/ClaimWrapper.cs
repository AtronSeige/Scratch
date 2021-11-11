using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ScratchXML.Models {

	[XmlRoot("Claims")]
	public class ClaimWrapper {

		[XmlElement("Claim")]
		public List<Claim> Claims { get; set; }

		public ClaimWrapper() {
			Claims = new List<Claim>();
		}
	}
}

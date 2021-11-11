using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ScratchXML.Models
{
	//[XmlRoot("Claims")]
	//[XmlElement("")]
	public class Claim
	{
		public string ClaimNo { get; set; }
		public List<Reserve> Reserves { get; set; }
	}
}

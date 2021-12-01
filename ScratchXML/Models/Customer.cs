using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ScratchXML.Models {
	[XmlRoot("Customer")]
	//[XmlType("Customer")]
	public class Customer {
		[XmlElement("Customer_ID")]
		public int ID { get; set; }

		[XmlElement("Customer_Name")]
		public string Name { get; set; }
	}
}

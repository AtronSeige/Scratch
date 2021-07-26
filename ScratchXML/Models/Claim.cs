using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchXML.Models
{
	public class Claim
	{
		public string ClaimNo { get; set; }
		public List<Reserve> Reserves { get; set; }
	}
}

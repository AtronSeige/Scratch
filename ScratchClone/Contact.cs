using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchClone
{
	public class Contact
	{
		#region Properties
		public string Name;
		public string Surname;
		public List<Address> Addresses;
		#endregion

		#region Constructor
		public Contact()
		{
			this.Addresses = new List<Address>();
		}
		#endregion

		#region Functions

		#endregion
	}
}

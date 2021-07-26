using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchAccessModifiers_Lib1
{
	//A public class is accessable by any code in the same
	//assembly or any assembly that refrences here
	public class PublicClass
	{
		//A public class is accessable by any code in the same
		//assembly or any assembly that refrences here
		public string publicName { get; set; }

		//Can be accessed by the code in the same class or struct, or by a class
		//that inherits from this class
		protected string protectedName { get; set; }

		//Can be accessed by code in the same assembly, but not from another assembly.
		internal string internalName { get; set; }

		//Can be accessed by code in the same assembly, or from a derived class
		//in a different assembly
		protected internal string protectedinternalName { get; set; }

		//Can only be accessed by code in the same class or stuct
		private string privateName { get; set; }


		//A public class is accessable by any code in the same
		//assembly or any assembly that refrences here
		public bool PublicMethod()
		{
			var c12 = new InternalClass();
			return true;
		}

		//Can be accessed by the code in the same class or struct, or by a class
		//that inherits from this class
		protected bool ProtectedMethod()
		{
			return true;
		}

		//Can be accessed by code in the same assembly, but not from another assembly.
		internal bool InternalMethod()
		{
			return false;
		}

		//Can be accessed by code in the same assembly, or from a derived class
		//in a different assembly
		protected internal bool ProtectedInternalMethod()
		{
			return true;
		}

		//Can only be accessed by code in the same class or stuct
		private bool PrivateMethod()
		{
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchStatic
{
	class Class1
	{
		public static int i = 200;
		public int j = 100;

		public int something()
		{
			j = i;
			i = i / 2;

			return i;
		}

	}
}

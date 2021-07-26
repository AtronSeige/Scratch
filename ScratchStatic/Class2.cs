using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchStatic
{
	static class Class2
	{
		public static int i = 200;
		public static int j = 100;

		public static int something()
		{
			j = i;
			i = i / 2;

			return i;
		}
	}
}

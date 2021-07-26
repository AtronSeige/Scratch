using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class PetConfigCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new PetConfigElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((PetConfigElement)element).Name;
		}
	}
}

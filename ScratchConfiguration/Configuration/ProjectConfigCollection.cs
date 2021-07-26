using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class ProjectConfigCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ProjectConfigElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ProjectConfigElement)element).Name;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class ProjectConfigElement : ConfigurationElement
	{
		[ConfigurationProperty("name", DefaultValue = "Bubbles", IsRequired = true, IsKey = true)]
		public string Name
		{
			get
			{
				return (string)this["name"];
			}
			set
			{
				this["name"] = value;
			}
		}

		[ConfigurationProperty("description", DefaultValue = "Bubbles", IsRequired = true)]
		public string Description
		{
			get
			{
				return (string)this["description"];
			}
			set
			{
				this["description"] = value;
			}
		}



	}
}

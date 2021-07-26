using ScratchConfiguration.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	class PetConfigElement : ConfigurationElement
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

		[ConfigurationProperty("type", DefaultValue = "Cat", IsRequired = true)]
		public PetType PetType
		{
			get
			{
				return (PetType)this["type"];
			}
			set
			{
				this["type"] = value;
			}
		}


	}
}

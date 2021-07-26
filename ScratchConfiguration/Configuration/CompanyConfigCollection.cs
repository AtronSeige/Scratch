using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class CompanyConfigCollection : ConfigurationElementCollection
	{
		[ConfigurationProperty("text", DefaultValue = "Work List", IsRequired = false, IsKey = true)]
		public string Text
		{
			get
			{
				return (string)this["text"];
			}
			set
			{
				this["text"] = value;
			}
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new CompanyConfigElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((CompanyConfigElement)element).Name;
		}
	}
}

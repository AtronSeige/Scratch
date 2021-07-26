using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class CompanyConfigElement : ConfigurationElement
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

		[ConfigurationProperty("datefrom", IsRequired = true)]
		public DateTime DateFrom
		{
			get
			{
				return (DateTime)this["datefrom"];
			}
			set
			{
				this["datefrom"] = value;
			}
		}

		[ConfigurationProperty("dateto", IsRequired = true)]
		public DateTime DateTo
		{
			get
			{
				return (DateTime)this["dateto"];
			}
			set
			{
				this["dateto"] = value;
			}
		}

		[ConfigurationProperty("Projects")]
		[ConfigurationCollection(typeof(ProjectConfigCollection), AddItemName = "Project", CollectionType = ConfigurationElementCollectionType.BasicMap)]
		public ProjectConfigCollection Projects
		{
			get { return (ProjectConfigCollection)this["Projects"]; }
			set { this["Projects"] = value; }
		}
	}
}

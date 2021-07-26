using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	internal class DeveloperConfigSection : ConfigurationSection
	{
		//Public properties
		public static string Name
		{
			get
			{
				return config._name;
			}
			set
			{
				config._name = value;
			}
		}

		public static DateTime Birthday
		{
			get
			{
				return config._birthday;
			}
			set
			{
				config._birthday = value;
			}
		}

		public static bool IsMarried
		{
			get
			{
				return config._ismarried;
			}
			set
			{
				config._ismarried = value;
			}
		}


		//Reading the data from the Config file
		private const string SECTION = "Developer";
		private static DeveloperConfigSection config = ConfigurationManager.GetSection(SECTION) as DeveloperConfigSection;

		[ConfigurationProperty("name")]
		private string _name
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

		[ConfigurationProperty("birthday")]
		private DateTime _birthday
		{
			get
			{
				return (DateTime)this["birthday"];
			}
			set
			{
				this["birthday"] = value;
			}
		}

		[ConfigurationProperty("ismarried")]
		private Boolean _ismarried
		{
			get
			{
				return (bool)this["ismarried"];
			}
			set
			{
				this["ismarried"] = value;
			}
		}
	}
}

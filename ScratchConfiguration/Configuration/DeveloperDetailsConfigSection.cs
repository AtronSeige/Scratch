using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class DeveloperDetailsConfigSection : ConfigurationSection
	{
		//this allows us to access the properties through the Static Properties
		private static DeveloperDetailsConfigSection config = ConfigurationManager.GetSection("DeveloperDetails") as DeveloperDetailsConfigSection;

		//These are the properties that relate to the CONFIG file.
		//Simple Properties
		[ConfigurationProperty("haspets", DefaultValue = "false", IsRequired = false)]
		private bool _haspets
		{
			get { return (bool)this["haspets"]; }
			set { this["haspets"] = value; }
		}

		[ConfigurationProperty("hasprojects", DefaultValue = "false", IsRequired = false)]
		private bool _hasprojects
		{
			get { return (bool)this["hasprojects"]; }
			set { this["hasprojects"] = value; }
		}

		[ConfigurationProperty("Pets")]
		[ConfigurationCollection(typeof(PetConfigCollection), AddItemName = "Pet", CollectionType = ConfigurationElementCollectionType.BasicMap)]
		private PetConfigCollection _pets
		{
			get { return (PetConfigCollection)this["Pets"]; }
			set { this["Pets"] = value; }
		}

		[ConfigurationProperty("Companies")]
		[ConfigurationCollection(typeof(ProjectConfigCollection), AddItemName = "Company", CollectionType = ConfigurationElementCollectionType.BasicMap)]
		private CompanyConfigCollection _companies
		{
			get { return (CompanyConfigCollection)this["Companies"]; }
			set { this["Companies"] = value; }
		}

		/*
		 * Public Static properties
		 */
		public static bool HasPets
		{
			get { return config._haspets; }
			set { config._haspets = value; }
		}

		public static PetConfigCollection Pets
		{
			get { return config._pets; }
			set { config._pets = value; }
		}

		public static bool HasProjects
		{
			get { return config._hasprojects; }
			set { config._hasprojects = value; }
		}

		public static CompanyConfigCollection Companies
		{
			get { return config._companies; }
			set { config._companies = value; }
		}
	}
}

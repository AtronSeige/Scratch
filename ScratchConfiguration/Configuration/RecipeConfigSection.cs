using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ScratchConfiguration.Configuration
{
	public class RecipeConfigSection : ConfigurationSection
	{
		//this allows us to access the properties through the Static Properties
		private static RecipeConfigSection config = ConfigurationManager.GetSection("Recipes") as RecipeConfigSection;

	}
}

using ScratchConfiguration.Configuration;
using System;

namespace ScratchConfiguration
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("***Reading Content from the App.Config File");
				TestDeveloper();
				TestDevloperDetails();
				TestRecipes();

				Console.WriteLine("All Done");
			}
			catch (Exception ex)
			{
				ShowError(ex);
			}


			Console.ReadLine();
		}

		private static void TestRecipes()
		{

		}

		private static void TestDevloperDetails()
		{
			if (DeveloperDetailsConfigSection.HasPets)
			{
				Console.WriteLine("Reading Pets");
				Console.WriteLine("Developer has the following pets:");
				foreach (PetConfigElement pet in DeveloperDetailsConfigSection.Pets)
				{
					Console.WriteLine("{0} is of type {1}", pet.Name, pet.PetType.ToString());
				}
			}
			else
			{
				Console.WriteLine("No Pets :(");
			}

			if (DeveloperDetailsConfigSection.HasProjects)
			{
				Console.WriteLine("Reading Projects : {0}", DeveloperDetailsConfigSection.Companies.Text);
				Console.WriteLine("Developer has worked for the following companies:");
				foreach (CompanyConfigElement company in DeveloperDetailsConfigSection.Companies)
				{
					Console.WriteLine("Projects for {0} from {1} to {2}", company.Name, company.DateFrom.ToShortDateString(), company.DateTo.ToShortDateString());
					foreach (ProjectConfigElement project in company.Projects)
					{
						Console.WriteLine("{0} - {1}", project.Name, project.Description);
					}
				}
			}
			else
			{
				Console.WriteLine("No Projects :(");

			}
		}

		private static void TestDeveloper()
		{
			Console.WriteLine("Reading Developer");
			Console.WriteLine("Developer is {0}, born on {1} and he {2} married.",
				DeveloperConfigSection.Name,
				DeveloperConfigSection.Birthday.ToShortDateString(),
				DeveloperConfigSection.IsMarried ? "is" : "isn't");
		}

		private static void ShowError(Exception ex)
		{
			Console.WriteLine("Something broke!");

			while (ex != null)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Stack Trace {0}", ex.StackTrace);
				Console.WriteLine("-------------------------------");
				ex = ex.InnerException;
			}
		}
	}
}

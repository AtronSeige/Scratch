using ScratchRandom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchLinq {
	internal class TestGroupBy {

		private School schoolFactory = new School();
		private Student studentFactory = new Student();

		public void TestGroupBy1() {
			Console.WriteLine("TestGroupBy1");

			Console.WriteLine();

			//Using Method Syntax
			IEnumerable<IGrouping<string, Student>> GroupByMS = studentFactory.GetStudents(5, 18).GroupBy(s => s.Branch);

			//It will iterate through each groups
			foreach (IGrouping<string, Student> group in GroupByMS) {
				Console.WriteLine(group.Key + " : " + group.Count());
				//Iterate through each student of a group
				foreach (Student student in group) {
					Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
				}
			}
		}

		public void TestGroupBy2() {

			Console.WriteLine("TestGroupBy2");

			IEnumerable<IGrouping<string, School>> GroupBySchoolOrUni = schoolFactory.GetSchools().GroupBy(s => s.SchoolOrUni);

			foreach (IGrouping<string, School> group in GroupBySchoolOrUni) {
				Console.WriteLine(group.Key + " : " + group.Count());

				foreach (School school in group) {
					Console.WriteLine("  Name :" + school.Name + ", SchoolOrUni: " + school.SchoolOrUni);
					foreach (Student student in school.Students) {
						Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
					}
				}
			}
		}

		public void TestGroupBy3() {

			Console.WriteLine("TestGroupBy3");

			IEnumerable<IGrouping<string, School>> GroupBySchoolOrUni = schoolFactory.GetSchools().GroupBy(s => s.SchoolOrUni);

			foreach (IGrouping<string, School> group in GroupBySchoolOrUni) {
				Console.WriteLine(group.Key + " : " + group.Count());

				foreach (School school in group) {
					Console.WriteLine("  Name :" + school.Name + ", SchoolOrUni: " + school.SchoolOrUni);
					foreach (Student student in school.Students) {
						Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
					}
				}
			}
		}
	}

	public class Student {
		public int ID { get; set; }
		public string Name { get; set; }

		public string Gender { get { return genders.Random(); } }
		public string Branch { get { return branches.Random(); } }
		public int Age { get; set; }

		private List<string> genders = new List<string> { "Male", "Female", "Unknown", "Helicopter" };
		private List<string> branches = new List<string> { "Math", "Language", "Science", "Magic" };
		private Random r = new Random();

		public List<Student> GetStudents(int minAge, int maxAge) {

			return new List<Student>()
			{
				new Student { ID = 1001, Name = "Preety", Age = r.Next(minAge, maxAge) },
				new Student {ID = 1002, Name = "Snurag", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1003, Name = "Pranaya", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1004, Name = "Anurag", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1005, Name = "Hina", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1006, Name = "Priyanka", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1007, Name = "santosh", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1008, Name = "Tina", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1009, Name = "Celina", Age = r.Next(minAge, maxAge)},
				new Student {ID = 1010, Name = "Sambit", Age = r.Next(minAge, maxAge)}
			};
		}
	}

	public class School {
		public int ID { get; set; }
		public string Name { get; set; }

		public string SchoolOrUni { get; set; }

		public List<Student> Students { get; set; } = new List<Student>();

		private Student studentFactory = new Student();

		public List<School> GetSchools() {
			return new List<School> {
				new School{ ID = 1, Name = "Primary School", SchoolOrUni = "School", Students = studentFactory.GetStudents(5,13) },
				new School{ ID = 2, Name = "High School", SchoolOrUni = "School", Students = studentFactory.GetStudents(13,18)},
				new School{ ID = 3, Name = "University", SchoolOrUni = "Uni", Students = studentFactory.GetStudents(18,99)},
			};
		}
	}
}

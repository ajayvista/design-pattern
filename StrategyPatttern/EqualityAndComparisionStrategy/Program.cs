using System;
using System.Collections.Generic;

namespace EqualityAndComparisionStrategy
{
	public sealed class NameComparerStrategy : IComparer<Employee>
	{
		public int Compare(Employee x, Employee y)
		{
			if (ReferenceEquals(x, y)) return 0;
			if (ReferenceEquals(null, y)) return 1;
			if (ReferenceEquals(null, x)) return -1;
			return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
		}
	}
	public class Employee : IComparable<Employee>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }


		public int CompareTo(Employee other)
		{
			return this.Salary.CompareTo(other.Salary);

			//Change the default sorting conditions here
			/*if (this.Salary > other.Salary)
			{
				return 1;
			}
			else if (this.Salary < other.Salary)
			{
				return -1;
			}
			else
			{
				return 0;
			}*/
		}

		public static IComparer<Employee> NameComparer { get; } = new NameComparerStrategy();
	}


	


	class MainClass
	{
		public static void Main(string[] args)
		{
			var listOfEmployee = new List<Employee>()
			{
				new Employee{ Id = 1, Name = "Joe", Salary=323 },
				new Employee{ Id = 1, Name = "Doe", Salary=3222 },
				new Employee{ Id = 1, Name = "Jhonson", Salary=1212 },
				new Employee{ Id = 1, Name = "Boby", Salary=3233 },
				new Employee{ Id = 1, Name = "Rehan", Salary=123213 }
			};

			//listOfEmployee.Sort(); // Default

			listOfEmployee.Sort(Employee.NameComparer);//based on given strategy

			foreach (var item in listOfEmployee)
			{
				Console.WriteLine($"{item.Id} \t {item.Name} \t {item.Salary}");
			}

			Console.ReadKey();
		}
	}
}


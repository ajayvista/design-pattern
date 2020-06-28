using System;
using System.Collections.Generic;
using OpenClosedPrincipleEx0.Example1;
using OpenClosedPrincipleEx0.Example2;

namespace SingleResponsibility
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			#region Example 1
			Console.WriteLine("Example1");

			//closed for extension
			ErrorLogger errorLogger = new ErrorLogger("TEXTFILE");
			errorLogger.LogError("Hello world!!");


			IErrorLogger _logger = new TextFileErrorLogger();
			_logger.LogError("Hello world with principle");
			#endregion

			#region Example 2

			Console.WriteLine("Example2-Without principle");
			var prouctCollection = new List<Product>
			{
				new OpenClosedPrincipleEx0.Example2.Product("Toy1", OpenClosedPrincipleEx0.Example2.Color.Red, OpenClosedPrincipleEx0.Example2.Size.Small),
				new OpenClosedPrincipleEx0.Example2.Product("Toy2", OpenClosedPrincipleEx0.Example2.Color.Green, OpenClosedPrincipleEx0.Example2.Size.Medium),
				new OpenClosedPrincipleEx0.Example2.Product("Toy3", OpenClosedPrincipleEx0.Example2.Color.Blue, OpenClosedPrincipleEx0.Example2.Size.Large)
			};

			foreach (var p in ProductFilter.FilterByColor(prouctCollection, Color.Blue))
				//? what if you need to apply multiple filter condition
			{
				Console.WriteLine($"Product: {p.Name}\tSize: {p.Size.ToString()}\tColor: {p.Color}\t");
			}



			Console.WriteLine("Example2-With principle");

			var fileredProducts = new NewProductFilter()
									.Filter(prouctCollection,
									new OrSpecification<Product>(
										 new ColorSpecification(Color.Red),
										 new SizeSpecification(Size.Medium)
									));


			foreach (var p in fileredProducts)
			{
				Console.WriteLine($"Product: {p.Name}\tSize: {p.Size.ToString()}\tColor: {p.Color}\t");
			}

			#endregion


			Console.ReadKey();
		}
	}
}


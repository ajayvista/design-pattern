using System;
using DependencyInversion.Example1.PrincipleViolation;
using DependencyInversion.Example1.WithPrinciple;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInversion
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			var gizmoProcessor = new Example1.PrincipleViolation.GizmoProcessor();
			gizmoProcessor.Process();


			//Example1
			//control inverted and injected whereever the dependency needed - poor approch
			//consider a scenario where you go this logger injected 100 places in your code 
			var withPrinciple = new Example1.WithPrinciple.GizmoProcessor(
				 new DependencyInversion.Example1.WithPrinciple.TextLogger()
				);

			withPrinciple.Process();


			//Example2: define all dependency at one place and get that resolve at runntime based on dependency
			var collection = new ServiceCollection();
			collection.AddScoped<ILogger, DependencyInversion.Example1.WithPrinciple.TextLogger>();
			collection.AddScoped<IGizmoProcessor, Example1.WithPrinciple.GizmoProcessor>();

			var serviceProvider = collection.BuildServiceProvider();
			var processor = serviceProvider.GetService<IGizmoProcessor>();
			processor.Process();


			Console.ReadKey();
		}
	}
}


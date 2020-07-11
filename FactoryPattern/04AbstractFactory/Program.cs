using System;
using System.Collections.Generic;
using System.Linq;
namespace AbstractFactory
{
	public interface ICheck
	{
		void DoCheck();
	}

	public class SoftCreditCheck : ICheck
	{
		public void DoCheck()
		{
			Console.WriteLine("This is soft credit check");
		}
	}

	public class HardCreditCheck : ICheck
	{
		public void DoCheck()
		{
			Console.WriteLine("This is hard credit check");
		}
	}

	public interface IFinancialCheckFactory
	{
		ICheck Verify(Lazy<string> ruleSet);
	}

	public class FraudCheckFactory : IFinancialCheckFactory
	{
		public ICheck Verify(Lazy<string> ruleSet)
		{
			Console.WriteLine("Doing fraud check");
			return (ICheck)new SoftCreditCheck();
		}
	}

	public class UNSanctionsCheckFactory : IFinancialCheckFactory
	{
		public ICheck Verify(Lazy<string> ruleSet)
		{
			Console.WriteLine("Doing UN Sancations check");
			return (ICheck)new HardCreditCheck();
		}
	}

	public class FinancialCrimeCheck
	{
		public List<Tuple<string, IFinancialCheckFactory>> Checks = new List<Tuple<string, IFinancialCheckFactory>>();


		public FinancialCrimeCheck()
		{
			foreach (var checkType in typeof(FinancialCrimeCheck).Assembly.GetTypes())
			{
				if (typeof(IFinancialCheckFactory).IsAssignableFrom(checkType) && !checkType.IsInterface)
				{
					Checks.Add(new Tuple<string, IFinancialCheckFactory>(
						 checkType.Name.Replace("Factory",string.Empty),
						 (IFinancialCheckFactory) Activator.CreateInstance(checkType)
						));
				}
			}
		}

		
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			/* The abstract factory pattern provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes.
			 */
			string [] objectToAccess =  new []  {"FraudCheck" };
			var financialCheck = new FinancialCrimeCheck();

			foreach (IFinancialCheckFactory chk in financialCheck.Checks.Where(a => objectToAccess.Contains(a.Item1)).Select(b=>b.Item2))
			{
				chk.Verify(null);
			}

			Console.ReadKey();
		}
	}
}



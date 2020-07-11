using System;
using System.Collections.Generic;

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
			return (ICheck) new SoftCreditCheck();
		}
	}

	public class UNSanctionsCheckFactory : IFinancialCheckFactory
	{
		public ICheck Verify(Lazy<string> ruleSet)
		{
			Console.WriteLine("Doing UN Sancations check");
			return (ICheck) new HardCreditCheck();
		}
	}

	public class FinancialCrimeCheck
	{
		public enum FinancialCrimeCheckType
		{
			FraudCheck,
			UNSanctionsCheck
		}

		private Dictionary<FinancialCrimeCheckType, IFinancialCheckFactory> financialCrimeCheck = new Dictionary<FinancialCrimeCheckType, IFinancialCheckFactory>();

		public FinancialCrimeCheck()
		{
			foreach (FinancialCrimeCheckType checkType in Enum.GetValues(typeof(FinancialCrimeCheckType)))
			{
				var factory = (IFinancialCheckFactory)Activator.CreateInstance(
					Type.GetType($"AbstractFactory.{Enum.GetName(typeof(FinancialCrimeCheckType), checkType)}Factory"));
				financialCrimeCheck.Add(checkType, factory);
			}
		}

		public ICheck Load(FinancialCrimeCheckType financialCrimeCheckType)
		{
			return financialCrimeCheck[financialCrimeCheckType]
				.Verify(null);
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			/* The abstract factory pattern provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes.
			 */

			var financialCheck = new FinancialCrimeCheck();
			financialCheck
				.Load(FinancialCrimeCheck.FinancialCrimeCheckType.FraudCheck)
				.DoCheck();
		}
	}
}


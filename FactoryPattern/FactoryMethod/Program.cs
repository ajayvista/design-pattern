using System;
using System.Collections.Generic;

namespace FactoryMethod
{
	public interface ICheck
	{
		void Initialize();
		void DoCheck();
	}

	public class SoftCreditCheck : ICheck
	{
		public SoftCreditCheck(List<string> ruleIds)
		{

		}
		public void DoCheck()
		{
			Console.WriteLine("This is soft credit check");
		}

		public void Initialize()
		{
			Console.WriteLine("Let say some dependecies must be initialized before anything get used from this class");
		}
	}

	public class HardCreditCheck : ICheck
	{
		public HardCreditCheck(string details)
		{

		}
		public void DoCheck()
		{
			Console.WriteLine("This is hard credit check");
		}

		public void Initialize()
		{
			Console.WriteLine("Let say some dependecies must be initialized before anything get used from this class");
		}
	}


	public enum CheckType
	{
		SoftCheck,
		HardCheck
	}

	public class CreditCheckFactory
	{

		private ICheck _check;

		public static ICheck NewSoftCreditCheck(List<string> rules)
		{
			return new SoftCreditCheck(rules);
		}

		public static ICheck NewHardCreditCheck(string details)
		{
			return new HardCreditCheck(details);
		}

		private CreditCheckFactory()
		{
			
		}


		/*
		 * Public
		public CreditCheckFactory(CheckType checkType, List<string> rules=null, string details=null)
		{
			if (checkType == CheckType.HardCheck)
				_check = new HardCreditCheck(details);
			else
				_check = new SoftCreditCheck(rules);
		}
		*
		*/


	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			//Define an interface for creating an object, but let subclasses decide which class to instantiate.
			//Factory Method lets a class defer instantiation to subclasses.
			var check = CreditCheckFactory.NewHardCreditCheck("details");
			check.Initialize();
			check.DoCheck();
		}
	}
}


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsynchronousFactoryMethod
{
	public interface ICheck
	{
		
		void DoCheck();
	}

	public class SoftCreditCheck : ICheck
	{
		private SoftCreditCheck()
		{
		}

		public void DoCheck()
		{
			Console.WriteLine("This is soft credit check");
		}

		private async Task<SoftCreditCheck> Initialize(List<string> rules)
		{
			await Task.Delay(1000);
			Console.WriteLine("Let say some dependecies must be initialized before anything get used from this class");
			return this;
		}

		public static async Task<SoftCreditCheck> CreateAsync(List<string> rules)
		{
			var obj = new SoftCreditCheck();
			return await obj.Initialize(rules);
		}
	}

	public class HardCreditCheck : ICheck
	{

		private HardCreditCheck()
		{
		}

		public void DoCheck()
		{
			Console.WriteLine("This is hard credit check");
		}

		private async Task<HardCreditCheck> Initialize(string details)
		{
			await Task.Delay(1000);
			Console.WriteLine("Let say some dependecies must be initialized before anything get used from this class");
			return this;
		}

		public static async Task<ICheck> CreateAsync(string details)
		{
			var obj = new HardCreditCheck();
			return (ICheck) await obj.Initialize(details);
		}
	}

	public class CreditCheckFactory
	{
		private CreditCheckFactory()
		{

		}

		public static async Task<ICheck> NewSoftCreditCheck(List<string> rules)
		{
			return await SoftCreditCheck.CreateAsync(rules);
		}

		public static async Task<ICheck> NewHardCreditCheck(string details)
		{
			return await HardCreditCheck.CreateAsync(details);
		}

		/*
		 * Public
		public CreditCheckFactory(CheckType checkType, List<string> rules=null, string details=null)
		{
			if (checkType == CheckType.HardCheck)
			{
				_check = new HardCreditCheck(details);
				_check.Initialize(rules);
			}
			else
			{
				_check = new SoftCreditCheck(rules);
				_check.Initialize(details);
			}
		}
		*
		*/


	}

	class MainClass
	{
		public static async Task Main(string[] args)
		{	
			//normally
			/*
			 * 
			 * var obj = new Class(details);
			 * obj.Initialize();
			 * obj.DoSomething();
			 */

			//option 1
			/* var check = SoftCreditCheck.CreateAsync(null)
						.GetAwaiter()
						.GetResult();

			//or
			*/
			var check = await CreditCheckFactory.NewHardCreditCheck("details");
			check.DoCheck();
		}
	}
}


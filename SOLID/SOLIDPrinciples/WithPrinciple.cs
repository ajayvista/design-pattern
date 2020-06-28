using System;
namespace DependencyInversion.Example2.WithPrinciple
{
	public interface IDocument
	{
		bool Write();
	}

	public interface IPrinterDevice
	{
		void Print(IDocument document);
	}

	public interface IScannerDevice
	{
		void Scan(IDocument document);
	}

	public interface IFaxDevice
	{
		void Fax(IDocument document);
	}

	public class MultifunctionPrinterModelE202 : IPrinterDevice, IScannerDevice, IFaxDevice
	{
		public void Fax(IDocument document)
		{
			//logic to fax
		}

		public void Print(IDocument document)
		{
			//logic to print
		}

		public void Scan(IDocument document)
		{
			//logic to scan
		}
	}

	public class MultifunctionPrinterModelX123 : IPrinterDevice, IScannerDevice
	{
		public void Print(IDocument document)
		{
			//logic to print
		}

		public void Scan(IDocument document)
		{
			//logic to scan
		}
	}


}

using System;
namespace InterfaceSegregation.Example2.PrincipleViolation
{
	public interface IDocument
	{
		 bool Write();
	}

	public interface IPrinterDevice
	{
		void Scan(IDocument document);
		void Print(IDocument document);
		void Fax(IDocument document);
	}

	public class MultifunctionPrinterModelE202 : IPrinterDevice
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

	public class MultifunctionPrinterModelX123 : IPrinterDevice
	{
		public void Fax(IDocument document)
		{
			throw new Exception("Not applicable on this device");
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
}

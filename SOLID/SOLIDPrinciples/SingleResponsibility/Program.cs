using System;

namespace SingleResponsibility
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var csvFileProcessor = new CsvFileProcessor();
			var data = csvFileProcessor.Process("data.csv");

			//violation of principle
			// read, process and write all principle in single class
			Console.WriteLine($"processed data - {string.Join("\n", data)}");
			csvFileProcessor.StoreCsvDataAsTxt(data, "temp.txt");
			Console.WriteLine($"processed data saved in temp.txt");


			//with principle

			var addressProcessor = new AddressProcessor();

			addressProcessor
					.Process(
							new CsvAddressDataProvider("data.csv"),
							new CsvAddressParser(),
							new TxtFileWriter("processed-data.txt")
							);

			Console.ReadKey();
		}
	}
}


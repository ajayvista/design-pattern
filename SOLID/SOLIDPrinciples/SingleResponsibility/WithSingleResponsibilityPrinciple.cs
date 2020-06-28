using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SingleResponsibility
{
	public interface IAddressDataProvider
	{
		string Read();
	}

	public interface IAddressParser
	{
		List<Address> Parse(string addressList);
	}

	public interface IAddressWriter
	{
		void Write(List<Address> addressData);
	}


	public class Address
	{
		public string ContactPersonName { get; set; }
		public string AddressLine { get; set; }
		public string Postcode { get; set; }
		public string State { get; set; }

		public override string ToString()
		{
			return $"{this.ContactPersonName},{this.AddressLine},{this.Postcode},{this.State},";
		}
	}

	public class CsvAddressDataProvider : IAddressDataProvider
	{
		private readonly string _filename;

		public CsvAddressDataProvider(string filename)
		{
			_filename = filename;
		}

		public string Read()
		{
			return File.ReadAllText(_filename);
		}
	}

	public class XmlAddressDataProvider : IAddressDataProvider
	{
		private readonly string _filename;

		public XmlAddressDataProvider(string filename)
		{
			_filename = filename;
		}

		public string Read()
		{
			//logic to parse
			return "";
		}
	}

	public class CsvAddressParser : IAddressParser
	{
		public List<Address> Parse(string csvData)
		{
			List<Address> contacts = new List<Address>();
			string[] lines = csvData.Split('\n');
			foreach (string line in lines)
			{
				string[] columns = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
				var contact = new Address
				{
					ContactPersonName = columns[0],
					AddressLine = columns[1],
					State = columns[2],
					Postcode = columns[3]
				};
				contacts.Add(contact);
			}

			return contacts;
		}
	}


	public class AddressProcessor
	{
		public void Process(IAddressDataProvider cdp, IAddressParser cp, IAddressWriter cw)
		{
			var providedData = cdp.Read();
			var parsedData = cp.Parse(providedData);
			cw.Write(parsedData);
		}
	}

	public class TxtFileWriter : IAddressWriter
	{
		string _filename;
		public TxtFileWriter(string filename)
		{
			_filename = filename;
		}
		public void Write(List<Address> addressData)
		{
			File.WriteAllLines(_filename, addressData.Select(a=>a.ToString()).ToArray());
		}
	}

	public class DbWriter : IAddressWriter
	{
		public DbWriter(string dbsettings)
		{

		}
		public void Write(List<Address> addressData)
		{
			//logic to save in db
		}
	}
}

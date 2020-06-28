using System;
using System.IO;
namespace SingleResponsibility
{

    public class CsvFileProcessor
    {
        public string[] Process(string filename)
        {
            var csvData = ReadCsv(filename);
            return ParseCsv(csvData);
        }

        public string ReadCsv(string filename)
        {
            return File.ReadAllText(filename);
        }

        public string[] ParseCsv(string csvData)
        {
            return csvData.ToString().Split('\n');
        }

        public void StoreCsvDataInDb(string[] csvData, string filename)
        {
           // save to db logic here
        }

        public void StoreCsvDataAsTxt(string[] csvData,string filename)
        {
            File.WriteAllLines(filename, csvData);
        }
    }



}

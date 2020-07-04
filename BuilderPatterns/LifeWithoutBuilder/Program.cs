using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LifeWithoutBuilder
{

	public class SearchParam
	{
		public string FieldName { get; set; }
		public string Value { get; set; }
		public string Operator { get; set; }
	}

	public class EmployeeQueryParms
	{
		public int RecorddsLimit { get; set; }
		public List<SearchParam> SearchParCms { get; set; }
	}

	public class ApiRequest
	{
		public string ResourcePath { get; set; }
		public string RequestBody { get; set; }
		public Dictionary<string,string> Headers { get; set; }
		public Dictionary<string, string> QueryParams { get; set; }
		public string Method { get; set; }
	}


	class MainClass
	{
		public static void Main(string[] args)
		{
			var request = new ApiRequest();

			request.ResourcePath = "http://this-is-api-path.com/api/employee/search";

			request.Method = "GET";

			request.QueryParams = new Dictionary<string, string> {
				{ "key1","value1" },
				{ "key2","value2" },
				{ "key3","value3" },
				{ "key4","value4" }
			};

			request.Headers = new Dictionary<string, string> {
				{ "Content-Type","application/json" },
				{ "Access-Token","xyz" }
			};

			request.RequestBody = JsonConvert.SerializeObject(new EmployeeQueryParms { RecorddsLimit = 100, SearchParCms = new List<SearchParam> { } });

			
			Console.WriteLine($"Response - {GetResponseFromUri(request)}");

		}


		private static string GetResponseFromUri(ApiRequest apiRequest)
		{
			return "this is resonse of api";
		}
	}
}


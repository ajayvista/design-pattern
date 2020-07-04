using System;
using System.Collections.Generic;
using Builder.Builders;
using Newtonsoft.Json;

namespace Builder
{
	


	class MainClass
	{
		public static void Main(string[] args)
		{
			string path = "http://this-is-api-path.com/api/employee/search";
			var apiRequestBuilder = new ApiRequestBuilder<EmployeeQueryParms>(new Uri(path));

			apiRequestBuilder.BuildHeader(new Dictionary<string, string> {
				{ "Content-Type","application/json" },
				{ "Access-Token","xyz" }
			});

			apiRequestBuilder.BuildQueryString(new Dictionary<string, string> {
				{ "key1","value1" },
				{ "key2","value2" },
				{ "key3","value3" },
				{ "key4","value4" }
			});
			apiRequestBuilder.BuildBody(new EmployeeQueryParms { });

			var request = apiRequestBuilder.Build();

			Console.WriteLine($"Response - {GetResponseFromUri(request)}");

		}


		private static string GetResponseFromUri(ApiRequest apiRequest)
		{
			return "this is resonse of api";
		}
	}
}


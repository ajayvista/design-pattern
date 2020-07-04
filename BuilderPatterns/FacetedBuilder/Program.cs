using System;
using System.Collections.Generic;
using Builder.Builders;

namespace FacetedBuilder
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string path = "http://this-is-api-path.com/api/employee/search";
			var apiRequestBuilder = new ApiRequestBuilder<EmployeeQueryParms>();

			var request = apiRequestBuilder
				.Url(new Uri(path))
				.Headers //facade builder
					.BuildHeader(new Dictionary<string, string> 
					{
						{ "Content-Type","application/json" },
						{ "Access-Token","xyz" }
					}
				).QueryParams //facade builder
					.BuildQueryString(new Dictionary<string, string> 
					{
						{ "key1","value1" },
						{ "key2","value2" },
						{ "key3","value3" },
						{ "key4","value4" }
					}
				)
				.BuildBody(new EmployeeQueryParms { })
				.Build();

			Console.WriteLine($"Response - {GetResponseFromUri(request)}");
		}

		private static string GetResponseFromUri(ApiRequest apiRequest)
		{
			return "this is resonse of api";
		}
	}
}


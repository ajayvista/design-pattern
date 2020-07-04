using System;
using System.Collections.Generic;
using Builder.Builders;
using Newtonsoft.Json;

namespace FunctionalBuilder
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var request1 = new FunctionalApiRequestBuilder()
							.BuildHeader(new Dictionary<string, string>() {
								{ "Content-Type","application/json"}
							})
							.BuildQueryParam(new Dictionary<string, string>() {
								{ "key1","value1"}
							})
							.Build();


			var request2 = new GenericApiRequestBuilder()
							.BuildHeader(new Dictionary<string, string>() {
								{ "Content-Type","application/json"}
							})
							.BuildQueryParam(new Dictionary<string, string>() {
								{ "key1","value1"}
							})
							.BuildUrl(new Uri("http://localhost"))
							.Build();

			Console.WriteLine($"this is request : {JsonConvert.SerializeObject(request2)}");
		}
	}
}


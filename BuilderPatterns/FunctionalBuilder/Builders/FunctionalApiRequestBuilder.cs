using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
namespace Builder.Builders
{
	public enum Method
	{
		GET,
		POST,
		PUT,
		DELETE
	}


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
		public Uri ResourcePath { get; set; }
		public string RequestBody { get; set; }
		public Dictionary<string, string> Headers { get; set; }
		public Dictionary<string, string> QueryParams { get; set; }
		public string Method { get; set; }
	}


	public sealed class FunctionalApiRequestBuilder
	{

		private readonly List<Func<ApiRequest, ApiRequest>> listOfActions = new List<Func<ApiRequest, ApiRequest>>();

		private FunctionalApiRequestBuilder Do(Action<ApiRequest> action) => AddAction(action);

		private FunctionalApiRequestBuilder AddAction(Action<ApiRequest> action)
		{
			listOfActions.Add(p => {
				action(p);
				return p;
			});
			return this;
		}

		public FunctionalApiRequestBuilder BuildHeader(Dictionary<string, string> headers) => Do((request) => {
				request.Headers = headers;
			});

		public FunctionalApiRequestBuilder BuildQueryParam(Dictionary<string, string> headers) => Do((request) => {
			request.QueryParams = headers;
		});

		

		public ApiRequest Build() => listOfActions.Aggregate(new ApiRequest(), (pm, func) =>  func(pm));

		
	}
}

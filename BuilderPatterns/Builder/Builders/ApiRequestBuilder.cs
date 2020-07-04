using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Builder.Builders
{
	public enum Method
	{
		GET,
		POST,
		PUT,
		DELETE
	}


	public interface IApiRequestBuilder<T>
	{
		void BuildBody(T body);
		void BuildMethod(Method method);
		void BuildHeader(Dictionary<string, string> headers);
		void BuildQueryString(Dictionary<string, string> queryParams);
		ApiRequest Build();
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


	public class ApiRequestBuilder<T>:IApiRequestBuilder <T>
	{
		private readonly ApiRequest request = null;


		public ApiRequestBuilder(Uri uri)
		{
			request = new ApiRequest() { ResourcePath = uri};
		}

		public void BuildBody(T body)
		{
			request.RequestBody =
				JsonConvert.SerializeObject(body);

		}

		public void BuildHeader(Dictionary<string, string> headers)
		{
			if (headers == null)
				return;

			request.Headers = headers;

		}

		public void BuildMethod(Method method)
		{
			request.Method = method.ToString();
		}

		public void BuildQueryString(Dictionary<string, string> queryParams)
		{
			if (queryParams == null)
				return;

			request.QueryParams = queryParams;
		}

		public ApiRequest Build()
		{
			return request;
		}
	}
}

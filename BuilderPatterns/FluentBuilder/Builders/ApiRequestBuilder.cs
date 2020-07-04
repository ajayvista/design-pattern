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
		IApiRequestBuilder<T> BuildBody(T body);
		IApiRequestBuilder<T> BuildMethod(Method method);
		IApiRequestBuilder<T> BuildHeader(Dictionary<string, string> headers);
		IApiRequestBuilder<T> BuildQueryString(Dictionary<string, string> queryParams);
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

		public IApiRequestBuilder<T> BuildBody(T body)
		{
			request.RequestBody =
				JsonConvert.SerializeObject(body);
			return this;
		}

		public IApiRequestBuilder<T> BuildHeader(Dictionary<string, string> headers)
		{
			if (headers != null)
				request.Headers = headers;

			return this;
		}

		public IApiRequestBuilder<T> BuildMethod(Method method)
		{
			request.Method = method.ToString();
			return this;
		}

		public IApiRequestBuilder<T> BuildQueryString(Dictionary<string, string> queryParams)
		{
			if (queryParams != null)
				request.QueryParams = queryParams;
			return this;
		}

		public ApiRequest Build()
		{
			return request;
		}
	}
}

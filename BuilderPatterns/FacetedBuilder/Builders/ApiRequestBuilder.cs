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


	public class ApiRequestBuilder<T>
	{
		protected ApiRequest request = null;

		public ApiRequestHeaderBuilder<T> Headers { get; set; }
		public ApiRequestQueryBuilder<T> QueryParams { get; set; }

		public ApiRequestBuilder()
		{
			request = new ApiRequest();
			this.Headers = new ApiRequestHeaderBuilder<T>(request);
			this.QueryParams = new ApiRequestQueryBuilder<T>(request);
		}

		public ApiRequestBuilder<T> Url(Uri uri)
		{
			request.ResourcePath = uri;
			return this;
		}

		public ApiRequestBuilder<T> BuildBody(T body)
		{
			request.RequestBody =
				JsonConvert.SerializeObject(body);
			return this;
		}

		public ApiRequestBuilder<T> BuildMethod(Method method)
		{
			request.Method = method.ToString();
			return this;
		}

		public ApiRequest Build()
		{
			return request;
		}
	}

	public class ApiRequestHeaderBuilder<T> : ApiRequestBuilder<T>
	{
		public ApiRequestHeaderBuilder(ApiRequest request)
		{
			this.request = request;
		}
		public ApiRequestBuilder<T> BuildHeader(Dictionary<string, string> headers)
		{
			if (headers != null)
				this.request.Headers = headers;
			return this;
		}
	}

	public class ApiRequestQueryBuilder<T> : ApiRequestBuilder<T>
	{
		public ApiRequestQueryBuilder(ApiRequest request)
		{
			this.request = request;
		}
		public ApiRequestBuilder<T> BuildQueryString(Dictionary<string, string> queryParams)
		{
			if (queryParams != null)
				this.request.QueryParams = queryParams;
			return this;
		}
	}
}

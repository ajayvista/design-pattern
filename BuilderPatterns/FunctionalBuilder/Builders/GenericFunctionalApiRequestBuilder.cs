using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
namespace Builder.Builders
{
	public abstract class BaseGenericApiRequestBuilder<TSubject, TBuilder>
			where TSubject : new()
			where TBuilder : BaseGenericApiRequestBuilder<TSubject, TBuilder>
	{

		private readonly List<Func<ApiRequest, ApiRequest>> listOfActions = new List<Func<ApiRequest, ApiRequest>>();

		public TBuilder Do(Action<ApiRequest> action) => AddAction(action);

		private TBuilder AddAction(Action<ApiRequest> action)
		{
			listOfActions.Add(p => {
				action(p);
				return p;
			});
			return (TBuilder)this;
		}

		public ApiRequest Build() => listOfActions.Aggregate(new ApiRequest(), (pm, func) => func(pm));
	}

	public sealed class GenericApiRequestBuilder : BaseGenericApiRequestBuilder<ApiRequest, GenericApiRequestBuilder>
	{

		public GenericApiRequestBuilder BuildHeader(Dictionary<string, string> headers) => Do((request) => {
			request.Headers = headers;

		});

		public GenericApiRequestBuilder BuildQueryParam(Dictionary<string, string> headers) => Do((request) => {
			request.QueryParams = headers;
		});
	}

	public static class GenericApiRequestBuilderExtension
	{
		public static GenericApiRequestBuilder BuildUrl(this GenericApiRequestBuilder builder, Uri url) => builder.Do((req)=>{ req.ResourcePath = url; });
	}
}

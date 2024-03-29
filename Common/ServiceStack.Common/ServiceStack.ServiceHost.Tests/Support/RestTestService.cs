using System;
using System.Runtime.Serialization;

namespace ServiceStack.ServiceHost.Tests.Support
{
	[DataContract]
	public class RestTest { }

	[DataContract]
	public class RestTestResponse
	{
		[DataMember]
		public string MethodName { get; set; }
	}

	public class RestTestService
		: IService<RestTest>
		, IRestGetService<RestTest>
		, IRestPutService<RestTest>
		, IRestPostService<RestTest>
		, IRestDeleteService<RestTest>
	{
		public object Execute(RestTest request)
		{
			return new RestTestResponse { MethodName = "Execute" };
		}

		public object Get(RestTest request)
		{
			return new RestTestResponse { MethodName = "Get" };
		}

		public object Put(RestTest request)
		{
			return new RestTestResponse { MethodName = "Put" };
		}

		public object Post(RestTest request)
		{
			return new RestTestResponse { MethodName = "Post" };
		}

		public object Delete(RestTest request)
		{
			return new RestTestResponse { MethodName = "Delete" };
		}
	}
}
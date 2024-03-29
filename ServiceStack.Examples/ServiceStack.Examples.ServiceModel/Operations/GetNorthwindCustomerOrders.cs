using System.Runtime.Serialization;
using ServiceStack.ServiceInterface.ServiceModel;
using CustomerOrders=ServiceStack.Examples.ServiceModel.Types.CustomerOrders;

namespace ServiceStack.Examples.ServiceModel.Operations
{
	[DataContract(Namespace = ExampleConfig.DefaultNamespace)]
	public class GetNorthwindCustomerOrders
	{
		[DataMember]
		public string CustomerId { get; set; }
	}

	[DataContract(Namespace = ExampleConfig.DefaultNamespace)]
	public class GetNorthwindCustomerOrdersResponse
	{
		public GetNorthwindCustomerOrdersResponse()
		{
			this.ResponseStatus = new ResponseStatus();
		}

		[DataMember]
		public CustomerOrders CustomerOrders { get; set; }

		[DataMember]
		public ResponseStatus ResponseStatus { get; set; }
	}
}
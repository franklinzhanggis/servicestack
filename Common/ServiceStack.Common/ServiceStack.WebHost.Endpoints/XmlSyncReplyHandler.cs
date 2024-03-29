using System;
using System.Web;
using ServiceStack.Logging;
using ServiceStack.Service;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceModel.Serialization;
using ServiceStack.WebHost.Endpoints.Extensions;
using ServiceStack.WebHost.Endpoints.Support;

namespace ServiceStack.WebHost.Endpoints
{
	public class XmlSyncReplyHandler : XmlHandlerBase
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (XmlSyncReplyHandler));

		public override void ProcessRequest(HttpContext context)
		{
			var response = new HttpResponseWrapper(context.Response);
			var operationName = context.Request.GetOperationName();

			if (DefaultHandledRequest(context)) return;

			try
			{
				if (string.IsNullOrEmpty(operationName)) return;

				var request = CreateRequest(context.Request, operationName);

				var endpointAttributes = EndpointAttributes.SyncReply | EndpointAttributes.Xml
					 | GetEndpointAttributes(context.Request);

				var result = ExecuteService(request, endpointAttributes);

				response.WriteToResponse(result, x => DataContractSerializer.Instance.Parse(x), ContentType.Xml);
			}
			catch (Exception ex)
			{
				var errorMessage = string.Format("Error occured while Processing Request: {0}", ex.Message);
				Log.Error(errorMessage, ex);

				response.WriteXmlErrorToResponse(operationName, errorMessage, ex);
			}
		}
	}

}
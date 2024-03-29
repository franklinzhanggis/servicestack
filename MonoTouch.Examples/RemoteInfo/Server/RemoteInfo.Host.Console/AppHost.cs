using System;
using System.Reflection;
using Funq;
using RemoteInfo.ServiceInterface;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.WebHost.Endpoints;

namespace RemoteInfo.Host.Console
{
	/// <summary>
	/// Web Services with http://www.servicestack.net/
	/// 
	/// Configuring ServiceStack to run in stand alone mode.
	/// </summary>
	public class AppHost 
		: XmlSyncReplyHttpListener
	{
		private static ILog log;

		public AppHost()
			: base("MonoTouch RemoteInfo", typeof(GetDirectoryInfoHandler).Assembly)
		{
			LogManager.LogFactory = new ConsoleLogFactory();
			log = LogManager.GetLogger(GetType());
		}

		public override void Configure(Container container)
		{
			container.Register<IResourceManager>(new ConfigurationResourceManager());
			container.Register(c => new RemoteInfoConfig(c.Resolve<IResourceManager>()));

			var config = container.Resolve<IResourceManager>();

			var listeningOn = config.GetString("ListenBaseUrl");
			this.Start(listeningOn);

			log.InfoFormat("AppHost Configured at {0}, listening on {1}", DateTime.Now, listeningOn);
		}

	}
}
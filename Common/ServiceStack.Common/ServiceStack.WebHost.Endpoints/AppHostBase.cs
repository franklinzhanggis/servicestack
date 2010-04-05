using System;
using System.IO;
using System.Reflection;
using Funq;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;

namespace ServiceStack.WebHost.Endpoints
{
	public abstract class AppHostBase
		: IFunqlet, IDisposable
	{
		private readonly ILog log = LogManager.GetLogger(typeof(AppHostBase));
		private readonly DateTime startTime;
		private readonly ServiceManager serviceManager;

		public static AppHostBase Instance { get; protected set; }

		protected AppHostBase()
		{
			this.startTime = DateTime.Now;
			log.Info("Begin Initializing Application...");
		}

		protected AppHostBase(string serviceName, params Assembly[] assembliesWithServices)
			: this()
		{
			this.serviceManager = new ServiceManager(assembliesWithServices);

			SetConfig(new EndpointHostConfig {
				ServiceName = serviceName,
				ServiceController = serviceManager.ServiceController,
			});
		}

		protected IServiceController ServiceController
		{
			get
			{
				return this.serviceManager != null ? this.serviceManager.ServiceController : null;
			}
		}

		public Container Container
		{
			get
			{
				return this.serviceManager != null ? this.serviceManager.Container : null;
			}
		}

		public void Init()
		{
			if (Instance != null)
			{
				throw new InvalidDataException("AppHostBase.Instance has already been set");
			}

			Instance = this;

			if (this.serviceManager != null)
			{
				serviceManager.Init();
				Configure(serviceManager.Container);
			}
			else
			{
				Configure(null);
			}

			EndpointHost.SetOperationTypes(
				EndpointHost.Config.ServiceController.OperationTypes, 
				EndpointHost.Config.ServiceController.AllOperationTypes
			);

			var elapsed = DateTime.Now - this.startTime;
			log.InfoFormat("Initializing Application took {0}ms", elapsed.TotalMilliseconds);
		}

		public abstract void Configure(Container container);

		public void SetConfig(EndpointHostConfig config)
		{
			EndpointHost.Config = config;
			this.serviceManager.ServiceController.EnableAccessRestrictions = config.EnableAccessRestrictions;
		}

		public virtual object ExecuteService(object requestDto)
		{
			return ExecuteService(requestDto, EndpointAttributes.None);
		}

		public object ExecuteService(object requestDto, EndpointAttributes endpointAttributes)
		{
			return EndpointHost.Config.ServiceController.Execute(requestDto,
				new HttpRequestContext(requestDto, endpointAttributes));
		}

		public virtual string ExecuteXmlService(string xml)
		{
			return ExecuteXmlService(xml, EndpointAttributes.None);
		}

		public string ExecuteXmlService(string xml, EndpointAttributes endpointAttributes)
		{
			return (string)EndpointHost.Config.ServiceController.ExecuteText(xml,
				new HttpRequestContext(xml, endpointAttributes));
		}

		public virtual void Dispose()
		{
			if (this.serviceManager != null)
			{
				this.serviceManager.Dispose();
			}
		}
	}
}
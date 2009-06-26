using ServiceStack.Configuration;

namespace ServiceStack.Sakila.Tests.Integration.Support
{
	public class AppConfig
	{
		public string LocalConnectionString
		{
			get { return ConfigUtils.GetAppSetting("LocalConnectionString"); }
		}

		public string MappingAssemblyName
		{
			get { return ConfigUtils.GetAppSetting("MappingAssemblyName"); }
		}

	}
}
using System;
using NUnit.Framework;
using ServiceStack.WebHost.Endpoints.Tests.Support.Host;

namespace ServiceStack.WebHost.Endpoints.Tests
{
	public class ServiceHostTestBase
	{
		public static TestAppHost CreateAppHost()
		{
			var appHost = new TestAppHost();
			appHost.Init();
			
			return appHost;
		}

		public void ShouldThrow<T>(Action action)
			where T : Exception
		{
			ShouldThrow<T>(action, "Should Throw");
		}

		public void ShouldThrow<T>(Action action, string errorMessageIfNotThrows)
			where T : Exception
		{
			try
			{
				action();
			}
			catch (T ex)
			{
				return;
			}
			Assert.Fail(errorMessageIfNotThrows);
		}

		public void ShouldNotThrow<T>(Action action)
			where T : Exception
		{
			ShouldNotThrow<T>(action, "Should not Throw");
		}
	
		public void ShouldNotThrow<T>(Action action, string errorMessageIfThrows)
			where T : Exception
		{
			try
			{
				action();
			}
			catch (T ex)
			{
				Assert.Fail(errorMessageIfThrows);
			}
		}

	}
}
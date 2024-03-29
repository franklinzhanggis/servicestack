﻿using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using ServiceStack.ServiceInterface.Tests.Support.Version100.Operations;

namespace ServiceStack.ServiceInterface.Tests
{
	[TestFixture]
	public class ZeroConfigServiceResolverTests : TestBase
	{
		[Test]
		public void ZeroConfig_basic_test()
		{
			var exampleOperation = typeof(GetCustomers);
			var resolver = new ZeroConfigServiceResolver(GetType().Assembly,
				exampleOperation.Assembly, exampleOperation.Namespace);

			Assert.That(resolver.OperationTypes.Count, Is.GreaterThan(0));
			Assert.That(resolver.FindService(exampleOperation.Name), Is.Not.Null);
		}

		[Test]
		public void PortResolver_returns_the_correct_no_of_operation_types()
		{
			var exampleOperation = typeof(GetCustomers);
			var resolver = new ZeroConfigServiceResolver(GetType().Assembly,
				exampleOperation.Assembly, exampleOperation.Namespace);

			Assert.That(resolver.OperationTypes.Count, Is.EqualTo(base.AllOperations.Count));
			Assert.That(resolver.OperationTypes, Is.EquivalentTo(base.AllOperations));
		}
	}
}
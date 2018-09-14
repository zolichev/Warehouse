using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Service.Tests.MemoryStorage;

namespace Warehouse.Service.Tests
{
	[TestClass()]
	public class ServiceLocatorTests
	{
		[TestMethod()]
		public void ServiceManagerTest()
		{
			//Prepare
			Test.Config();

			//Action

			//Confirm
			Assert.IsNotNull(Test.ServiceLocator);
		}
	}
}
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
	public class ServiceManagerTests
	{
		[TestMethod()]
		public void ServiceManagerTest()
		{
			//Prepare
			ServiceManager serviceManager = new ServiceManager(new WareRepositoryTest(), new ClientRepositoryTest(), new NotificationRepositoryTest());

			//Action
			ServiceManager.Current = serviceManager;

			//Confirm
			Assert.IsNotNull(ServiceManager.Current);
		}
	}
}
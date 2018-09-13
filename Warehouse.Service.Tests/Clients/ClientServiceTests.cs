using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse.Model.Clients;

namespace Warehouse.Service.Tests.Clients
{
	[TestClass()]
	public class ClientServiceTests
	{
		/*
		Initial values:
		(1, "test", "", true)
 	  */

		[TestMethod()]
		public void ClientServiceTest()
		{
			//Prepare
			TestConfig.Register();

			//Action

			//Confirm
			Assert.IsNotNull(ServiceManager.Current.ClientService);
		}

		[TestMethod()]
		public void GetNotifiableClientsTest()
		{
			//Prepare
			TestConfig.Register();

			//Action

			//Confirm
			Assert.IsNotNull(ServiceManager.Current.ClientService.GetNotifiableClients());
			Assert.IsTrue(ServiceManager.Current.ClientService.GetNotifiableClients().Any());
		}

		[TestMethod()]
		public void CheckAutentificationTest()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value = ServiceManager.Current.ClientService.CheckAutentification("test", "");

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(true, value);
		}

		[TestMethod()]
		public void RegisterTest()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value = ServiceManager.Current.ClientService.Register(new ClientValue()
			{
				Login = "u1",
				Password = "u1",
				Notifiable = true
			});

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(2, value.Id);
			Assert.AreEqual("u1", value.Login);
			Assert.AreEqual(true, value.Notifiable);
		}

		[TestMethod()]
		public void GetClientTest()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value = ServiceManager.Current.ClientService.GetClient(1);

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual("test", value.Login);
			Assert.AreEqual(true, value.Notifiable);
		}

		[TestMethod()]
		public void GetClientTest1()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value = ServiceManager.Current.ClientService.GetClient("test");

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual("test", value.Login);
			Assert.AreEqual(true, value.Notifiable);
		}

		[TestMethod()]
		public void UpdateClientNotifiableTest()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value = ServiceManager.Current.ClientService.UpdateClientNotifiable("test", false);

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual("test", value.Login);
			Assert.AreEqual(false, value.Notifiable);
		}
	}
}
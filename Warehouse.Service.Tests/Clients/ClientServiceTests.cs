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
			Test.Config();

			//Action

			//Confirm
			Assert.IsNotNull(Test.ServiceLocator.ClientService);
		}

		[TestMethod()]
		public void GetNotifiableClientsTest()
		{
			//Prepare
			Test.Config();

			//Action

			//Confirm
			Assert.IsNotNull(Test.ServiceLocator.ClientService.GetNotifiableClients());
			Assert.IsTrue(Test.ServiceLocator.ClientService.GetNotifiableClients().Any());
		}

		[TestMethod()]
		public void CheckAutentificationTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value = Test.ServiceLocator.ClientService.CheckAutentification("test", "");

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(true, value);
		}

		[TestMethod()]
		public void RegisterTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value = Test.ServiceLocator.ClientService.Register(new ClientValue()
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
			Test.Config();

			//Action
			var value = Test.ServiceLocator.ClientService.GetClient(1);

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
			Test.Config();

			//Action
			var value = Test.ServiceLocator.ClientService.GetClient("test");

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
			Test.Config();

			//Action
			var value = Test.ServiceLocator.ClientService.UpdateClientNotifiable("test", false);

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual("test", value.Login);
			Assert.AreEqual(false, value.Notifiable);
		}
	}
}
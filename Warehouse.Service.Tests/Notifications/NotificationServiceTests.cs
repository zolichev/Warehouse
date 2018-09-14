using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse.Model.Notifications;
using Warehouse.Service.Tests.MemoryStorage;

namespace Warehouse.Service.Tests.Notifications
{
	[TestClass()]
	public class NotificationServiceTests
	{
		/*
		Initial values:
		(1, db.Clients[0].Id, db.Wares[0].Id, db.Wares[0].ToObjectProperties(),
				DateTime.Now, NotificationType.WareExpired)
		(2, db.Clients[0].Id, db.Wares[4].Id, db.Wares[4].ToObjectProperties(),
				DateTime.Now, NotificationType.WareExpired)
 	  */

		[TestMethod()]
		public void NotificationServiceTest()
		{
			//Prepare
			Test.Config();

			//Action

			//Confirm
			Assert.IsNotNull(Test.ServiceLocator.NotificationService);
		}

		[TestMethod()]
		public void ExistTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value1 = Test.ServiceLocator.NotificationService.Exist(
				new NotificationTest(1, 1, 1, new Dictionary<string, string>(), DateTime.Now, NotificationType.WareExpired));
			var value2 = Test.ServiceLocator.NotificationService.Exist(
				new NotificationTest(10, 1, 1, new Dictionary<string, string>(), DateTime.Now, NotificationType.WareExpired));
			var value3 = Test.ServiceLocator.NotificationService.Exist(
				new NotificationTest(10, 10, 10, new Dictionary<string, string>(), DateTime.Now, NotificationType.WareExpired));

			//Confirm
			Assert.IsNotNull(value1);
			Assert.AreEqual(true, value1);
			Assert.IsNotNull(value2);
			Assert.AreEqual(true, value2);
			Assert.IsNotNull(value3);
			Assert.AreEqual(false, value3);
		}

		[TestMethod()]
		public void GetNotificationsTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value1 = Test.ServiceLocator.NotificationService.GetNotifications("test");
			var value2 = Test.ServiceLocator.NotificationService.GetNotifications("test_not_exist");

			//Confirm
			Assert.IsNotNull(value1);
			Assert.AreEqual(true, value1.Any());
			Assert.IsNull(value2);
		}

		[TestMethod()]
		public void GetNotificationTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value = Test.ServiceLocator.NotificationService.GetNotification("test", 1);

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual(1, value.ObjectId);
			Assert.AreEqual(1, value.ClientId);
			Assert.AreEqual(NotificationType.WareExpired, value.Type);
		}

		[TestMethod()]
		public void AddTest()
		{
			//Prepare
			Test.Config();

			//Action
			var valueBefore = new NotificationTest(3, 1, 1, new Dictionary<string, string>(), DateTime.Now,
				NotificationType.WareTaked);
			var countBefore = Test.ServiceLocator.NotificationService.GetNotifications("test").Count();
			Test.ServiceLocator.NotificationService.Add(valueBefore);
			var valueAfter = Test.ServiceLocator.NotificationService.GetNotifications("test").LastOrDefault();
			var countAfter = Test.ServiceLocator.NotificationService.GetNotifications("test").Count();

			//Confirm
			Assert.IsNotNull(valueAfter);
			Assert.AreEqual(valueBefore.Id, valueAfter.Id);
			Assert.AreEqual(valueBefore.ClientId, valueAfter.ClientId);
			Assert.AreEqual(valueBefore.ObjectId, valueAfter.ObjectId);
			Assert.AreEqual(valueBefore.Type, valueAfter.Type);
			Assert.AreEqual(countBefore, countAfter - 1);
		}

		[TestMethod()]
		public void ViewNotificationTest()
		{
			//Prepare
			Test.Config();

			//Action
			var countBefore = Test.ServiceLocator.NotificationService.GetNotifications("test").Count();
			var value = Test.ServiceLocator.NotificationService.ViewNotification("test", 1);
			var countAfter = Test.ServiceLocator.NotificationService.GetNotifications("test").Count();

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(1, value.Id);
			Assert.AreEqual(1, value.ClientId);
			Assert.AreEqual(1, value.ObjectId);
			Assert.AreEqual(NotificationType.WareExpired, value.Type);
			Assert.AreEqual(true, value.Viewed);
			Assert.AreEqual(countBefore, countAfter);
		}

		[TestMethod()]
		public void ViewNextNotificationTest()
		{
			//Prepare
			Test.Config();

			//Action
			var countBefore = Test.ServiceLocator.NotificationService.GetNotifications("test").Count();
			Test.ServiceLocator.NotificationService.ViewNextNotification("test");
			var value = Test.ServiceLocator.NotificationService.ViewNextNotification("test");
			var countAfter = Test.ServiceLocator.NotificationService.GetNotifications("test").Count();

			//Confirm
			Assert.IsNotNull(value);
			Assert.AreEqual(2, value.Id);
			Assert.AreEqual(1, value.ClientId);
			Assert.AreEqual(5, value.ObjectId);
			Assert.AreEqual(NotificationType.WareExpired, value.Type);
			Assert.AreEqual(true, value.Viewed);
			Assert.AreEqual(countBefore, countAfter);
		}

		[TestMethod()]
		public void ViewAllNotificationsTest()
		{
			//Prepare
			Test.Config();

			//Action
			var value1 = Test.ServiceLocator.NotificationService.ViewAllNotifications("test");
			var value2 = Test.ServiceLocator.NotificationService.ViewAllNotifications("test");

			//Confirm
			Assert.IsNotNull(value1);
			Assert.AreEqual(true, value1.Any());
			Assert.IsNotNull(value2);
			Assert.AreEqual(false, value2.Any());
		}
	}
}
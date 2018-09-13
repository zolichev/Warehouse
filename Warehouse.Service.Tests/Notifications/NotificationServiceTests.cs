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
			TestConfig.Register();

			//Action

			//Confirm
			Assert.IsNotNull(ServiceManager.Current.NotificationService);
		}

		[TestMethod()]
		public void ExistTest()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value1 = ServiceManager.Current.NotificationService.Exist(
				new NotificationTest(1, 1, 1, new Dictionary<string, string>(), DateTime.Now, NotificationType.WareExpired));
			var value2 = ServiceManager.Current.NotificationService.Exist(
				new NotificationTest(10, 1, 1, new Dictionary<string, string>(), DateTime.Now, NotificationType.WareExpired));
			var value3 = ServiceManager.Current.NotificationService.Exist(
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
			TestConfig.Register();

			//Action
			var value1 = ServiceManager.Current.NotificationService.GetNotifications("test");
			var value2 = ServiceManager.Current.NotificationService.GetNotifications("test_not_exist");

			//Confirm
			Assert.IsNotNull(value1);
			Assert.AreEqual(true, value1.Any());
			Assert.IsNull(value2);
		}

		[TestMethod()]
		public void GetNotificationTest()
		{
			//Prepare
			TestConfig.Register();

			//Action
			var value = ServiceManager.Current.NotificationService.GetNotification("test", 1);

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
			TestConfig.Register();

			//Action
			var valueBefore = new NotificationTest(3, 1, 1, new Dictionary<string, string>(), DateTime.Now,
				NotificationType.WareTaked);
			var countBefore = ServiceManager.Current.NotificationService.GetNotifications("test").Count();
			ServiceManager.Current.NotificationService.Add(valueBefore);
			var valueAfter = ServiceManager.Current.NotificationService.GetNotifications("test").LastOrDefault();
			var countAfter = ServiceManager.Current.NotificationService.GetNotifications("test").Count();

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
			TestConfig.Register();

			//Action
			var countBefore = ServiceManager.Current.NotificationService.GetNotifications("test").Count();
			var value = ServiceManager.Current.NotificationService.ViewNotification("test", 1);
			var countAfter = ServiceManager.Current.NotificationService.GetNotifications("test").Count();

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
			TestConfig.Register();

			//Action
			var countBefore = ServiceManager.Current.NotificationService.GetNotifications("test").Count();
			ServiceManager.Current.NotificationService.ViewNextNotification("test");
			var value = ServiceManager.Current.NotificationService.ViewNextNotification("test");
			var countAfter = ServiceManager.Current.NotificationService.GetNotifications("test").Count();

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
			TestConfig.Register();

			//Action
			var value1 = ServiceManager.Current.NotificationService.ViewAllNotifications("test");
			var value2 = ServiceManager.Current.NotificationService.ViewAllNotifications("test");

			//Confirm
			Assert.IsNotNull(value1);
			Assert.AreEqual(true, value1.Any());
			Assert.IsNotNull(value2);
			Assert.AreEqual(false, value2.Any());
		}
	}
}
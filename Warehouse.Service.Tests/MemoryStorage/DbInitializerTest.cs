using System;
using System.Collections.Generic;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Model.Wares;

namespace Warehouse.Service.Tests.MemoryStorage
{
	/// <summary>
	/// Initializer DB on first start
	/// </summary>
	public static class DbInitializerTest
	{
		/// <summary>
		/// Initialize DB if it needed.
		/// </summary>
		public static void Initialize()
		{
			var db = WarehouseContextTest.Current;
			db.Wares.Clear();
			db.Wares.Add(new WareTest(1, "Tuna", WareType.SeaFood, DateTime.Today.AddDays(-1)));
			db.Wares.Add(new WareTest(2, "Tuna", WareType.SeaFood, DateTime.Today.AddDays(2)));
			db.Wares.Add(new WareTest(3, "Mussels", WareType.SeaFood, DateTime.Today));
			db.Wares.Add(new WareTest(4, "Salmon", WareType.SeaFood, DateTime.Today.AddDays(2)));
			db.Wares.Add(new WareTest(5, "Lamb", WareType.Meat, DateTime.Today.AddDays(-7)));
			db.Wares.Add(new WareTest(6, "Beef", WareType.Meat, DateTime.Today.AddDays(14)));
			db.Wares.Add(new WareTest(7, "Potatoes", WareType.Vegetables, DateTime.Today.AddMonths(6)));

			db.Clients.Clear();
			db.Clients.Add(new ClientTest(1, "test", "", true));

			db.Notifications.Clear();
			db.Notifications.Add(new NotificationTest(1, db.Clients[0].Id, db.Wares[0].Id, db.Wares[0].ToObjectProperties(),
				DateTime.Now, NotificationType.WareExpired));
			db.Notifications.Add(new NotificationTest(2, db.Clients[0].Id, db.Wares[4].Id, db.Wares[4].ToObjectProperties(),
				DateTime.Now, NotificationType.WareExpired));
		}
	}

	internal class NotificationTest : Notification
	{
		public NotificationTest(int id, int clientId, int objectId, Dictionary<string, string> objectProperties,
			DateTime dateTime, NotificationType type)
			: base(clientId, objectId, objectProperties, dateTime, type) => Id = id;
	}

	internal class ClientTest : Client
	{
		public ClientTest(int id, Client client) : base(client.Login, client.PasswordHash, client.Notifiable) =>Id = id;

		public ClientTest(int id, string login, string pwdHash, bool notifiable) : base(login, pwdHash, notifiable) =>
			Id = id;
	}

	internal class WareTest : Ware
	{
		public WareTest(int id, string name, WareType type, DateTime expirationDate) : base(name, type, expirationDate) =>
			Id = id;

		public WareTest(int id, Ware ware) : base(ware.Name, ware.Type, ware.ExpirationDate) => Id = id;
	}
}
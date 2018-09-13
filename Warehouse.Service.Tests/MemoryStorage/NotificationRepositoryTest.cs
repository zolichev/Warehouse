using System.Collections.Generic;
using System.Linq;
using Warehouse.Model.Notifications;
using Warehouse.Storage.Notifications;

namespace Warehouse.Service.Tests.MemoryStorage
{
	/// <inheritdoc />
	internal class NotificationRepositoryTest : INotificationRepository
	{
		private readonly WarehouseContextTest _db = WarehouseContextTest.Current;

		/// <inheritdoc />
		public IQueryable<Notification> Notifications => _db.Notifications.AsQueryable();

		/// <inheritdoc />
		public Notification Add(Notification notification)
		{
			_db.Notifications.Add(notification);
			return notification;
		}

		/// <inheritdoc />
		public Notification Remove(Notification notification)
		{
			if (notification != null)
			{
				_db.Notifications.Remove(notification);
			}

			return notification;
		}

		/// <inheritdoc />
		public Notification Update(Notification notification)
		{
			return notification;
		}

		/// <inheritdoc />
		public IQueryable<Notification> Update(IEnumerable<Notification> notifications)
		{
			return notifications.AsQueryable();
		}

		private bool Exists(int id) => _db.Notifications.Count(e => e.Id == id) > 0;
	}
}
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Warehouse.Model.Notifications;

namespace Warehouse.Storage.Notifications
{
	/// <inheritdoc />
	public class NotificationRepository : INotificationRepository
	{
		private readonly WarehouseContext _db = WarehouseContext.Current;

		/// <inheritdoc />
		public IQueryable<Notification> Notifications => _db.Notifications;

		/// <inheritdoc />
		public Notification Add(Notification notification)
		{
			var storingNotification = new StoringNotification(notification);
			_db.Notifications.Add(storingNotification);
			_db.SaveChanges();
			return storingNotification;
		}

		/// <inheritdoc />
		public Notification Remove(Notification notification)
		{
			if (notification != null)
			{
				var storingNotification = _db.Notifications.Find(notification.Id);
				if (storingNotification != null) _db.Notifications.Remove(storingNotification);
				_db.SaveChanges();
			}

			return notification;
		}

		/// <inheritdoc />
		public Notification Update(Notification notification)
		{
			if (notification != null)
			{
				var storingNotification = _db.Notifications.Find(notification.Id);
				if (storingNotification != null)
				{
					storingNotification.Update(notification);
					_db.Entry(storingNotification).State = EntityState.Modified;
					_db.SaveChanges();
				}
			}

			return notification;
		}

		/// <inheritdoc />
		public IQueryable<Notification> Update(IEnumerable<Notification> notifications)
		{
			var needSave = false;
			var list = notifications.ToList();
			foreach (var notification in list)
			{
				if (notification != null)
				{
					var storingNotification = _db.Notifications.Find(notification.Id);
					if (storingNotification != null)
					{
						storingNotification.Update(notification);
						_db.Entry(storingNotification).State = EntityState.Modified;
						needSave = true;
					}
				}
			}

			if (needSave) _db.SaveChanges();
			return list.AsQueryable();
		}

		private bool Exists(int id) => _db.Notifications.Count(e => e.Id == id) > 0;
	}
}
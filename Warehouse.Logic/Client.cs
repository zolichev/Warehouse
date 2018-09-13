using System.Collections.Generic;
using System.Linq;

namespace Warehouse.Model
{
	/// <summary>
	/// Client of warehouse
	/// </summary>
	public class Client
	{
		/// <summary>
		/// Notification queue.
		/// </summary>
		protected Queue<Notification> Notifications { get; set; }

		public Client()
		{
			Notifications = new Queue<Notification>();
		}

		/// <summary>
		/// Add notification to client
		/// </summary>
		/// <param name="notification">Notification for adding.</param>
		public void PushNotification(Notification notification)
		{
			if (notification != null)
				Notifications.Enqueue(notification);
		}

		/// <summary>
		/// Get latest notification and clear it.
		/// </summary>
		/// <returns></returns>
		public Notification PopNotification() => Notifications.Count > 0 ? Notifications.Dequeue() : null;

		/// <summary>
		/// Get all notifications and clear its.
		/// </summary>
		/// <returns></returns>
		public IReadOnlyList<Notification> PopAllNotifications()
		{
			var result = Notifications.ToList().AsReadOnly();
			Notifications.Clear();
			return result;
		}
	};
}
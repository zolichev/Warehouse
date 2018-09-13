using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Storage;
using Warehouse.Storage.Notifications;

namespace Warehouse.Service.Notifications
{
	/// <summary>
	/// Notification service.
	/// </summary>
	public class NotificationService : INotificationService
	{
		private readonly INotificationRepository _repo;
		private readonly ServiceManager _serviceManager;

		/// <inheritdoc />
		public NotificationService(INotificationRepository repo, ServiceManager serviceManager)
		{
			_repo = repo;
			_serviceManager = serviceManager;
		}

		/// <summary>
		/// Check notification exist yet
		/// </summary>
		/// <param name="notification">Checked notification</param>
		/// <returns>True if notification is founded, else false</returns>
		public bool Exist(Notification notification)
		{
			return _repo.Notifications.Count(i => i.Id == notification.Id ||
			                                      (i.ObjectId == notification.ObjectId &&
			                                       i.ClientId == notification.ClientId &&
			                                       i.Type == notification.Type)) > 0;
		}

		/// <summary>
		/// Get all notifications for client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <returns>All client notifications or null if client not found</returns>
		public IEnumerable<Notification> GetNotifications(string clientName)
		{
			var client = _serviceManager.ClientService.GetClient(clientName);
			if (client == null) return null;
			return _repo.Notifications.Where(i => i.ClientId == client.Id);
		}

		/// <summary>
		/// Get client notification by id
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <param name="id">Uniq identifier of notification</param>
		/// <returns>Client notification or null if client or notification not found</returns>
		public Notification GetNotification(string clientName, int id)
		{
			var client = _serviceManager.ClientService.GetClient(clientName);
			if (client == null) return null;
			return _repo.Notifications.FirstOrDefault(i => i.Id == id && i.ClientId == client.Id);
		}

		/// <summary>
		/// Add new notification.
		/// </summary>
		/// <param name="notification">Notification for adding.</param>
		/// <returns>Added notification</returns>
		public Notification Add(Notification notification)
		{
			return _repo.Add(notification);
		}

		/// <summary>
		/// View and make viewed notification of client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <param name="id">Uniq identifier of notification</param>
		/// <returns>Founded and made viewed notification or null if client or notification not found</returns>
		public Notification ViewNotification(string clientName, int id)
		{
			var client = _serviceManager.ClientService.GetClient(clientName);
			var notification = _repo.Notifications.Where(i => !i.Viewed).FirstOrDefault(i => i.Id == id);
			if (notification != null) notification.Viewed = true;
			return notification;
		}

		/// <summary>
		/// View and make viewed first hasn't viewed yet notification of client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <returns>Founded and made viewed notification or null if client or notification not found</returns>
		public Notification ViewNextNotification(string clientName)
		{
			var client = _serviceManager.ClientService.GetClient(clientName);
			var notification = _repo.Notifications.FirstOrDefault(i => !i.Viewed && i.ClientId == client.Id);
			if (notification != null)
			{
				notification.Viewed = true;
				_repo.Update(notification);
			}

			return notification;
		}

		/// <summary>
		/// View and make viewed all notifications from client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <returns>Founded and made viewed notifications or null if client not found</returns>
		public IEnumerable<Notification> ViewAllNotifications(string clientName)
		{
			var client = _serviceManager.ClientService.GetClient(clientName);
			if (client == null) return null;
			var notifications = _repo.Notifications.Where(i => !i.Viewed && i.ClientId == client.Id).ToList();
			notifications.ForEach(n => n.Viewed = true);
			_repo.Update(notifications);
			return notifications;
		}
	}
}
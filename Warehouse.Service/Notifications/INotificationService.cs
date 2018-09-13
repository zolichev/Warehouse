using System.Collections.Generic;
using Warehouse.Model.Notifications;

namespace Warehouse.Service.Notifications
{
	/// <summary>
	/// Notification service
	/// </summary>
	public interface INotificationService
	{
		/// <summary>
		/// Check notification exist yet
		/// </summary>
		/// <param name="notification">Checked notification</param>
		/// <returns>True if notification is founded, else false</returns>
		bool Exist(Notification notification);

		/// <summary>
		/// Get all notifications for client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <returns>All client notifications or null if client not found</returns>
		IEnumerable<Notification> GetNotifications(string clientName);

		/// <summary>
		/// Get client notification by id
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <param name="id">Uniq identifier of notification</param>
		/// <returns>Client notification or null if client or notification not found</returns>
		Notification GetNotification(string clientName, int id);

		/// <summary>
		/// Add new notification.
		/// </summary>
		/// <param name="notification">Notification for adding.</param>
		/// <returns>Added notification</returns>
		Notification Add(Notification notification);

		/// <summary>
		/// View and make viewed notification of client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <param name="id">Uniq identifier of notification</param>
		/// <returns>Founded and made viewed notification or null if client or notification not found</returns>
		Notification ViewNotification(string clientName, int id);

		/// <summary>
		/// View and make viewed first hasn't viewed yet notification of client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <returns>Founded and made viewed notification or null if client or notification not found</returns>
		Notification ViewNextNotification(string clientName);

		/// <summary>
		/// View and make viewed all notifications from client
		/// </summary>
		/// <param name="clientName">Client name</param>
		/// <returns>Founded and made viewed notifications or null if client not found</returns>
		IEnumerable<Notification> ViewAllNotifications(string clientName);
	}
}
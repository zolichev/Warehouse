using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Model.Notifications;

namespace Warehouse.Storage.Notifications
{
	/// <summary>
	/// Notifications repository.
	/// </summary>
	public interface INotificationRepository
	{
		/// <summary>
		/// Notifications in repository
		/// </summary>
		IQueryable<Notification> Notifications { get; }

		/// <summary>
		/// Add new notification to repository.
		/// </summary>
		/// <param name="notification">New notification for adding.</param>
		/// <returns>Added notification.</returns>
		Notification Add(Notification notification);

		/// <summary>
		/// Remove notification from repository.
		/// </summary>
		/// <param name="notification">Notification for remove.</param>
		/// <returns>Removed notification.</returns>
		Notification Remove(Notification notification);

		/// <summary>
		/// Update notification in repository.
		/// </summary>
		/// <param name="notification">Notification for update</param>
		/// <returns>Updated notification</returns>
		Notification Update(Notification notification);

		/// <summary>
		/// Update notifications in repository.
		/// </summary>
		/// <param name="notifications">Notifications for update</param>
		/// <returns>Updated notifications</returns>
		IQueryable<Notification> Update(IEnumerable<Notification> notifications);
	}
}
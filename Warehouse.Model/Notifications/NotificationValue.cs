using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Model.Notifications
{
	/// <summary>
	/// Basic properties of Notification.
	/// </summary>
	public class NotificationValue
	{
		/// <summary>
		/// Uniq identifier of Notification object.
		/// </summary>
		public int ObjectId { get; protected set; }

		/// <summary>
		/// Value properties of object.
		/// </summary>
		public ReadOnlyDictionary<string, string> ObjectProperties { get; protected set; }

		/// <summary>
		/// Notification happened date and time.
		/// </summary>
		public DateTime DateTime { get; protected set; }

		/// <summary>
		/// Type of notification.
		/// </summary>
		public NotificationType Type { get; protected set; }

		/// <inheritdoc />
		public NotificationValue(int objectId, Dictionary<string, string> objectProperties, DateTime dateTime,
			NotificationType type)
		{
			DateTime = dateTime;
			Type = type;
			ObjectId = objectId;
			ObjectProperties = new ReadOnlyDictionary<string, string>(objectProperties);
		}

		/// <inheritdoc />
		public NotificationValue(int objectId, ReadOnlyDictionary<string, string> objectProperties, DateTime dateTime,
			NotificationType type)
		{
			DateTime = dateTime;
			Type = type;
			ObjectId = objectId;
			ObjectProperties = objectProperties;
		}

		/// <summary>
		/// For EF.
		/// </summary>
		protected NotificationValue()
		{
		}
	}
}
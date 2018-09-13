using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Warehouse.Model.Clients;

namespace Warehouse.Model.Notifications
{
	/// <summary>
	/// Notification of changing wareValue.
	/// </summary>
	public class Notification : NotificationValue, IEntity
	{
		/// <summary>
		/// Uniq identifier.
		/// </summary>
		public int Id { get; protected set; }

		/// <summary>
		/// Notified client identity.
		/// </summary>
		public int ClientId { get; protected set; }

		/// <summary>
		/// Notification had been viewed
		/// </summary>
		public bool Viewed { get; set; }

		/// <summary>
		/// Create Notification from basic object
		/// </summary>
		/// <param name="clientId">Notification client id.</param>
		/// <param name="notificationValue">Value of Notification</param>
		public Notification(int clientId, NotificationValue notificationValue) :
			this(clientId, notificationValue.ObjectId, notificationValue.ObjectProperties, notificationValue.DateTime, notificationValue.Type)
		{
		}

		/// <inheritdoc />
		public Notification(int clientId, int objectId, Dictionary<string, string> objectProperties, DateTime dateTime, NotificationType type) :
			base(objectId, objectProperties, dateTime, type)
		{
			ClientId = clientId;
			Viewed = false;
		}

		/// <inheritdoc />
		public Notification(int clientId, int objectId, ReadOnlyDictionary<string, string> objectProperties, DateTime dateTime, NotificationType type) :
			base(objectId, objectProperties, dateTime, type)
		{
			ClientId = clientId;
			Viewed = false;
		}

		/// <summary>
		/// For EF.
		/// </summary>
		protected Notification()
		{
		}
	}
}
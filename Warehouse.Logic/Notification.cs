namespace Warehouse.Model
{
	/// <summary>
	/// Notification of changing.
	/// </summary>
	public class Notification
	{
		/// <summary>
		/// Notification happened date and time.
		/// </summary>
		public DateTime DateTime { get; set; }

		/// <summary>
		/// Notification message.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Type of notification.
		/// </summary>
		public NotificationType Type { get; set; }
	}

	public enum NotificationType
	{
		GoodAdded,
		GoodRemoved,
		GoodExpired
	}
}
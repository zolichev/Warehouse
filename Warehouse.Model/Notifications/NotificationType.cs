namespace Warehouse.Model.Notifications
{
	/// <summary>
	/// Type of notification
	/// </summary>
	public enum NotificationType
	{
		/// <summary>
		/// Good added to store
		/// </summary>
		WareStored,

		/// <summary>
		/// Good removed from store
		/// </summary>
		WareTaked,

		/// <summary>
		/// Good expired in store
		/// </summary>
		WareExpired
	}
}
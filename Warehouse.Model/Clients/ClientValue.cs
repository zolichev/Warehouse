namespace Warehouse.Model.Clients
{
	/// <summary>
	/// Basic properties of client
	/// </summary>
	public class ClientValue
	{
		/// <summary>
		/// Client login.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Client password.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Client must be notified about happens.
		/// </summary>
		public bool Notifiable { get; set; }
	}
}
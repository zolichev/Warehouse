using System;

namespace Warehouse.Model.Wares
{
	/// <summary>
	/// Basic properties of ware.
	/// </summary>
	public class WareValue
	{
		/// <summary>
		/// Name of ware.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Expiration date of ware.
		/// </summary>
		public DateTime ExpirationDate { get; set; }

		/// <summary>
		/// Type of ware.
		/// </summary>
		public WareType Type { get; set; }
	}
}

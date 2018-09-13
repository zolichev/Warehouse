namespace Warehouse.Model
{
	/// <summary>
	/// Represent stored good.
	/// </summary>
	public class Good
	{
		/// <summary>
		/// Stock-keeping unit, uniq identificator.
		/// </summary>
		public string Sku { get; set; }

		/// <summary>
		/// Name of good.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Expiration date of good.
		/// </summary>
		public DateTime ExpirationDate { get; set; }

		/// <summary>
		/// Type of good.
		/// </summary>
		public GoodType Type { get; set; }
	}

	/// <summary>
	/// Available type of goods.
	/// </summary>
	public enum GoodType
	{
		SeaFood,
		Fruits,
		Bread,
		Meat,
		Electronics
	}

}

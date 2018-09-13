namespace Warehouse.Model
{
	/// <summary>
	/// Represent storage of goods.
	/// </summary>
	public class Store
	{
		private readonly List<Good> _goods;

		/// <summary>
		/// Goods in the store.
		/// </summary>
		public IReadOnlyCollection<Good> Goods => _goods.AsReadOnly();

		public Store()
		{
			_goods = new List<Good>();
		}

		public void Add(Good good)
		{
			_goods.Add(good);
		}

		public void Remove(Good good)
		{
			_goods.Remove(good);
		}

		public void Remove(string sku)
		{
			var good = _goods.FirstOrDefault(i => i.Sku == sku);
			if (good != null)
				_goods.Remove(good);
		}
	}
}
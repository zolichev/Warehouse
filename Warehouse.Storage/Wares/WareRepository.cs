using System.Linq;
using Warehouse.Model.Wares;

namespace Warehouse.Storage.Wares
{
	/// <inheritdoc />
	public class WareRepository : IWareRepository
	{
		private readonly WarehouseContext _db = WarehouseContext.Current;

		/// <inheritdoc />
		public IQueryable<Ware> Wares => _db.Wares;

		/// <inheritdoc />
		public Ware Add(Ware ware)
		{
			_db.Wares.Add(ware);
			_db.SaveChanges();
			return ware;
		}

		/// <inheritdoc />
		public Ware Remove(Ware ware)
		{
			if (ware != null && Exists(ware.Id))
			{
				_db.Wares.Remove(ware);
				_db.SaveChanges();
			}
			return ware;
		}

		private bool Exists(int id) => _db.Wares.Count(e => e.Id == id) > 0;
	}
}
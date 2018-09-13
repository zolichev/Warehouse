using System.Linq;
using Warehouse.Model.Wares;
using Warehouse.Storage.Wares;

namespace Warehouse.Service.Tests.MemoryStorage
{
	/// <inheritdoc />
	public class WareRepositoryTest : IWareRepository
	{
		private readonly WarehouseContextTest _db = WarehouseContextTest.Current;

		/// <inheritdoc />
		public IQueryable<Ware> Wares => _db.Wares.AsQueryable();

		/// <inheritdoc />
		public Ware Add(Ware ware)
		{
			var id = _db.Wares.Last().Id + 1;
			var wareTest = new WareTest(id, ware);
			_db.Wares.Add(wareTest);
			return wareTest;
		}

		/// <inheritdoc />
		public Ware Remove(Ware ware)
		{
			if (ware != null && Exists(ware.Id))
			{
				_db.Wares.Remove(ware);
			}

			return ware;
		}

		private bool Exists(int id) => _db.Wares.Count(e => e.Id == id) > 0;
	}
}
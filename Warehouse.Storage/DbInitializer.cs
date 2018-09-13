using System;
using System.Data.Entity;
using Warehouse.Model;
using Warehouse.Model.Clients;
using Warehouse.Model.Wares;

namespace Warehouse.Storage
{
	/// <summary>
	/// Initializer DB on first start
	/// </summary>
	public class DbInitializer
	{
		/// <summary>
		/// Initialize DB if it needed.
		/// </summary>
		public static void Initialize()
		{
			Database.SetInitializer(new WarehouseDbInitializer());
		}

		private class WarehouseDbInitializer : DropCreateDatabaseIfModelChanges<WarehouseContext>
		{
			/// <inheritdoc />
			protected override void Seed(WarehouseContext db)
			{
				db.Wares.Add(new Ware("Tuna", WareType.SeaFood, DateTime.Today.AddDays(-1)));
				db.Wares.Add(new Ware("Tuna", WareType.SeaFood, DateTime.Today.AddDays(2)));
				db.Wares.Add(new Ware("Mussels", WareType.SeaFood, DateTime.Today));
				db.Wares.Add(new Ware("Salmon", WareType.SeaFood, DateTime.Today.AddDays(2)));
				db.Wares.Add(new Ware("Lamb", WareType.Meat, DateTime.Today.AddDays(-7)));
				db.Wares.Add(new Ware("Beef", WareType.Meat, DateTime.Today.AddDays(14)));
				db.Wares.Add(new Ware("Potatoes", WareType.Vegetables, DateTime.Today.AddMonths(6)));

				db.Clients.Add(new Client("test", "", true));

				base.Seed(db);
			}
		}
	}
}
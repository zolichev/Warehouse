using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Model.Wares;
using Warehouse.Storage;
using Warehouse.Storage.Wares;

namespace Warehouse.Service.Wares
{
	/// <summary>
	/// Represent storage of wares.
	/// </summary>
	public class WareService : IWareService
	{
		private readonly Keeper _keeper;

		/// <inheritdoc />
		public WareService(IWareRepository repo, ServiceManager serviceFactory)
		{
			_keeper = new Keeper(repo, serviceFactory.ClientService.GetNotifiableClients(),
				serviceFactory.NotificationService);
		}

		/// <summary>
		/// Get all wares in store
		/// </summary>
		/// <returns>All wares in store</returns>
		public IEnumerable<Ware> GetWares() => _keeper.GetWares();

		/// <summary>
		/// Get ware by id.
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded ware or null</returns>
		public Ware GetWare(int id) => _keeper.GetWare(id);

		/// <summary>
		/// Store new ware in store
		/// </summary>
		/// <param name="ware">Ware for adding.</param>
		/// <returns>Added ware</returns>
		public Ware Store(WareValue ware) => _keeper.Store(ware);

		/// <summary>
		/// Take ware from store
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded and removed ware or null</returns>
		public Ware Take(int id)
		{
			var ware = _keeper.GetWare(id);
			return _keeper.Take(ware);
		}

		/// <summary>
		/// Take first expired ware from store
		/// </summary>
		/// <param name="name">Name of ware</param>
		/// <returns>First expired founded and removed ware or null</returns>
		public Ware Take(string name)
		{
			var ware = _keeper.GetWares().OrderBy(i => i.ExpirationDate).FirstOrDefault(i => i.Name == name);
			return _keeper.Take(ware);
		}

		private bool Exists(int id) => _keeper.GetWares().Count(e => e.Id == id) > 0;
	}
}
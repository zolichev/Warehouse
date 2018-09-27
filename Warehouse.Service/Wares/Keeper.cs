using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Model.Wares;
using Warehouse.Service.Notifications;
using Warehouse.Storage;
using Warehouse.Storage.Wares;

namespace Warehouse.Service.Wares
{
	internal class Keeper
	{
		private readonly IWareRepository _repo;
		private readonly Tracker _tracker = new Tracker();

		public Keeper(IWareRepository repo, IEnumerable<Client> clients, INotificationService notificationService)
		{
			_repo = repo;
			SubscribeClients(clients, notificationService);
		}

		private void SubscribeClients(IEnumerable<Client> clients, INotificationService notificationService)
		{
			foreach (var client in clients)
			{
				var notificator = new ClientNotificator(client, notificationService);
				notificator.Subscribe(_tracker);
			}
		}

		/// <summary>
		/// Get all wares in store
		/// </summary>
		/// <returns>All wares in store</returns>
		public IEnumerable<Ware> GetWares()
		{
			CheckExpires();
			return _repo.Wares;
		}

		/// <summary>
		/// Get ware by id.
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded ware or null</returns>
		public Ware GetWare(int id)
		{
			CheckExpires();
			return _repo.Wares.FirstOrDefault(i => i.Id == id);
		}

		/// <summary>
		/// Add new ware in store
		/// </summary>
		/// <param name="ware">Ware</param>
		/// <returns>Added ware</returns>
		public Ware Store(WareValue ware)
		{
			var entity = new Ware(ware);
			entity = _repo.Add(entity);
			WareStored(entity);
			CheckExpires();
			return entity;
		}

		/// <summary>
		/// Take specific ware from store
		/// </summary>
		/// <param name="ware">Specific ware in store</param>
		/// <returns>Founded and removed ware or null</returns>
		public Ware Take(Ware ware)
		{
			CheckExpires();
			var entity = _repo.Remove(ware);
			WareTaked(ware);
			return entity;
		}

		private void CheckExpires() => _repo.Wares.Where(i => i.ExpirationDate < DateTime.Now).ToList().ForEach(WareExpired);

		private void WareExpired(Ware ware) => _tracker.WareExpired(ware);

		private void WareStored(Ware ware) => _tracker.WareStored(ware);

		private void WareTaked(Ware ware) => _tracker.WareTaked(ware);
	}
}
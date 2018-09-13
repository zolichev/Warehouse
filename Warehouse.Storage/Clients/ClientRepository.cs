using System.Data.Entity;
using System.Linq;
using Warehouse.Model.Clients;

namespace Warehouse.Storage.Clients
{
	/// <inheritdoc />
	public class ClientRepository : IClientRepository
	{
		private readonly WarehouseContext _db = WarehouseContext.Current;

		/// <inheritdoc />
		public IQueryable<Client> Clients => _db.Clients;

		/// <inheritdoc />
		public Client Add(Client client)
		{
			_db.Clients.Add(client);
			_db.SaveChanges();
			return client;
		}

		/// <inheritdoc />
		public Client Remove(Client client)
		{
			if (client != null && Exists(client.Id))
			{
				_db.Clients.Remove(client);
				_db.SaveChanges();
			}

			return client;
		}

		/// <inheritdoc />
		public Client Update(Client client)
		{
			if (client != null)
			{
				_db.Entry(client).State = EntityState.Modified;
				_db.SaveChanges();
			}

			return client;
		}

		private bool Exists(int id) => _db.Clients.Count(e => e.Id == id) > 0;
	}
}
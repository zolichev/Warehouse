using System.Linq;
using Warehouse.Model.Clients;
using Warehouse.Storage.Clients;

namespace Warehouse.Service.Tests.MemoryStorage
{
	/// <inheritdoc />
	internal class ClientRepositoryTest : IClientRepository
	{
		private readonly WarehouseContextTest _db = WarehouseContextTest.Current;

		/// <inheritdoc />
		public IQueryable<Client> Clients => _db.Clients.AsQueryable();

		/// <inheritdoc />
		public Client Add(Client client)
		{
			var id = _db.Clients.Last().Id + 1;
			var clientTest = new ClientTest(id, client);
			_db.Clients.Add(clientTest);
			return clientTest;
		}

		/// <inheritdoc />
		public Client Remove(Client client)
		{
			if (client != null && Exists(client.Id))
			{
				_db.Clients.Remove(client);
			}

			return client;
		}

		/// <inheritdoc />
		public Client Update(Client client)
		{
			return client;
		}

		private bool Exists(int id) => _db.Clients.Count(e => e.Id == id) > 0;
	}
}
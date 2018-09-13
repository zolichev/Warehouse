using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Model.Clients;
using Warehouse.Storage;
using Warehouse.Storage.Clients;

namespace Warehouse.Service.Clients
{
	/// <summary>
	/// Client service.
	/// </summary>
	public class ClientService : IClientService
	{
		private readonly IClientRepository _repo;

		/// <inheritdoc />
		public ClientService(IClientRepository repo, ServiceManager serviceManager)
		{
			_repo = repo;
		}

		/// <summary>
		/// Get clients must be notified about happens.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public IEnumerable<Client> GetNotifiableClients()
		{
			return _repo.Clients.Where(i => i.Notifiable);
		}

		/// <summary>
		/// Check client authentification credentials.
		/// </summary>
		/// <param name="login">Client's login</param>
		/// <param name="password">Client's password</param>
		/// <returns>Client authentificated</returns>
		public bool CheckAutentification(string login, string password)
		{
			var client = _repo.Clients.FirstOrDefault(i => i.Login == login);
			if (client == null) return false;
			return SecurePasswordHasher.Verify(password, client.PasswordHash);
		}

		/// <summary>
		/// Register new client.
		/// </summary>
		/// <param name="clientValue">Client basic properties</param>
		/// <returns>Client or null if client not created</returns>
		public Client Register(ClientValue clientValue)
		{
			if (clientValue == null) return null;
			var oldClient = _repo.Clients.FirstOrDefault(i => i.Login == clientValue.Login);
			if (oldClient != null) return null;
			var passwordHash = SecurePasswordHasher.Hash(clientValue.Password);
			var client = new Client(clientValue, passwordHash);
			return _repo.Add(client);
		}

		/// <summary>
		/// Get client by id
		/// </summary>
		/// <param name="id">Uniq identifier of client</param>
		/// <returns>Client or null if client not found</returns>
		public Client GetClient(int id)
		{
			return _repo.Clients.FirstOrDefault(i => i.Id == id);
		}

		/// <summary>
		/// Get client by login
		/// </summary>
		/// <param name="login">Client login</param>
		/// <returns>Client or null if client not found</returns>
		public Client GetClient(string login)
		{
			return _repo.Clients.FirstOrDefault(i => i.Login == login);
		}

		/// <summary>
		/// Update notifiable property of client
		/// </summary>
		/// <param name="login">Client login</param>
		/// <param name="notifiable"></param>
		/// <returns></returns>
		public Client UpdateClientNotifiable(string login, bool notifiable)
		{
			var client = GetClient(login);
			if (client == null) return null;
			if (client.Notifiable != notifiable)
			{
				client.Notifiable = notifiable;
				_repo.Update(client);
			}

			return client;
		}
	}
}
using System;
using System.Collections.Generic;
using Warehouse.Model.Clients;

namespace Warehouse.Service.Clients
{
	/// <summary>
	/// Client service
	/// </summary>
	public interface IClientService
	{
		/// <summary>
		/// Get clients must be notified about happens.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		IEnumerable<Client> GetNotifiableClients();

		/// <summary>
		/// Check client authentification credentials.
		/// </summary>
		/// <param name="login">Client's login</param>
		/// <param name="password">Client's password</param>
		/// <returns>Client authentificated</returns>
		bool CheckAutentification(string login, string password);

		/// <summary>
		/// Register new client.
		/// </summary>
		/// <param name="clientValue">Client basic properties</param>
		/// <returns>Client or null if client not created</returns>
		Client Register(ClientValue clientValue);

		/// <summary>
		/// Get client by id
		/// </summary>
		/// <param name="id">Uniq identifier of client</param>
		/// <returns>Client or null if client not found</returns>
		Client GetClient(int id);

		/// <summary>
		/// Get client by login
		/// </summary>
		/// <param name="login">Client login</param>
		/// <returns>Client or null if client not found</returns>
		Client GetClient(string login);

		/// <summary>
		/// Update notifiable property of client
		/// </summary>
		/// <param name="login">Client login</param>
		/// <param name="notifiable"></param>
		/// <returns></returns>
		Client UpdateClientNotifiable(string login, bool notifiable);
	}
}
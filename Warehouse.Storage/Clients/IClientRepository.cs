using System;
using System.Linq;
using Warehouse.Model.Clients;

namespace Warehouse.Storage.Clients
{
	/// <summary>
	/// Clients repository.
	/// </summary>
	public interface IClientRepository
	{
		/// <summary>
		/// Notifications in repository
		/// </summary>
		IQueryable<Client> Clients { get; }

		/// <summary>
		/// Add new notification to repository.
		/// </summary>
		/// <param name="client">New client for adding.</param>
		/// <returns>Added client.</returns>
		Client Add(Client client);

		/// <summary>
		/// Remove notification from repository.
		/// </summary>
		/// <param name="client">Client for remove.</param>
		/// <returns>Removed client.</returns>
		Client Remove(Client client);

		/// <summary>
		/// Update client in repository
		/// </summary>
		/// <param name="client">Client for update</param>
		/// <returns>Updated client</returns>
		Client Update(Client client);
	}
}
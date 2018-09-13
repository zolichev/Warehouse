using System;
using System.Linq;
using Warehouse.Model.Wares;

namespace Warehouse.Storage.Wares
{
	/// <summary>
	/// Wares repository.
	/// </summary>
	public interface IWareRepository
	{
		/// <summary>
		/// Wares in repository
		/// </summary>
		IQueryable<Ware> Wares { get; }

		/// <summary>
		/// Add new ware to repository.
		/// </summary>
		/// <param name="ware">New ware for adding.</param>
		/// <returns>Added ware.</returns>
		Ware Add(Ware ware);

		/// <summary>
		/// Remove ware from repository.
		/// </summary>
		/// <param name="ware">Ware for remove.</param>
		/// <returns>Removed ware.</returns>
		Ware Remove(Ware ware);
	}
}
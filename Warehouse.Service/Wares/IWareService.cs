using System.Collections.Generic;
using Warehouse.Model.Wares;

namespace Warehouse.Service.Wares
{
	/// <summary>
	/// Represent storage of wares
	/// </summary>
	public interface IWareService
	{
		/// <summary>
		/// Get all wares in store
		/// </summary>
		/// <returns>All wares in store</returns>
		IEnumerable<Ware> GetWares();

		/// <summary>
		/// Get ware by id.
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded ware or null</returns>
		Ware GetWare(int id);

		/// <summary>
		/// Store new ware in store
		/// </summary>
		/// <param name="ware">Ware for adding.</param>
		/// <returns>Added ware</returns>
		Ware Store(WareValue ware);

		/// <summary>
		/// Take ware from store
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded and removed ware or null</returns>
		Ware Take(int id);

		/// <summary>
		/// Take first expired ware from store
		/// </summary>
		/// <param name="name">Name of ware</param>
		/// <returns>First expired founded and removed ware or null</returns>
		Ware Take(string name);
	}
}
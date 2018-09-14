using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Warehouse.Model.Wares;
using Warehouse.Service;
using Warehouse.Service.Wares;
using Warehouse.WebApi.Filters;

namespace Warehouse.WebApi.Controllers
{
	/// <summary>
	/// Ware store
	/// </summary>
	[BasicAuthentication]
	public class WaresController : ApiController
	{
		private readonly IWareService _service = Dependency.ServiceLocator.WareService;

		// GET: api/Wares
		/// <summary>
		/// Get all wares in store
		/// </summary>
		/// <returns>All wares</returns>
		[ResponseType(typeof(IEnumerable<Ware>))]
		public IHttpActionResult GetWares()
		{
			return Ok(_service.GetWares());
		}

		// GET: api/Wares/5
		/// <summary>
		/// Get ware by id.
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded ware or NotFound</returns>
		[ResponseType(typeof(Ware))]
		public IHttpActionResult GetWare(int id)
		{
			var ware = _service.GetWare(id);
			if (ware == null) return NotFound();

			return Ok(ware);
		}

		// POST: api/Wares
		/// <summary>
		/// Add new ware in store
		/// </summary>
		/// <param name="ware">Ware</param>
		/// <returns>Added ware</returns>
		[ResponseType(typeof(Ware))]
		[HttpPost]
		public IHttpActionResult StoreWare(WareValue ware)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var entity = _service.Store(ware);
			return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
		}

		// DELETE: api/Wares/5
		/// <summary>
		/// Remove ware from store
		/// </summary>
		/// <param name="id">Uniq identifier of ware</param>
		/// <returns>Founded and removed ware or NotFound</returns>
		[ResponseType(typeof(Ware))]
		[HttpDelete]
		public IHttpActionResult TakeWare(int id)
		{
			var ware = _service.Take(id);
			if (ware == null) return NotFound();
			return Ok(ware);
		}

		// DELETE: api/Wares/Tuna
		/// <summary>
		/// Remove first expired ware from store
		/// </summary>
		/// <param name="name">Name of ware</param>
		/// <returns>First expired founded and removed ware or NotFound</returns>
		[ResponseType(typeof(Ware))]
		[HttpDelete]
		public IHttpActionResult TakeWareByName(string name)
		{
			var ware = _service.Take(name);
			if (ware == null) return NotFound();
			return Ok(ware);

		}
	}
}
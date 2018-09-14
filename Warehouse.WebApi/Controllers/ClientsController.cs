using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Service;
using Warehouse.Service.Clients;
using Warehouse.WebApi.Filters;

namespace Warehouse.WebApi.Controllers
{
	/// <summary>
	/// Client management.
	/// </summary>
	public class ClientsController : ApiController
	{
		private readonly IClientService _service = Dependency.ServiceLocator.ClientService;

		/// <summary>
		/// Get identity name from context
		/// </summary>
		private string IdentityName => HttpContext.Current.User?.Identity?.Name;

		// GET: api/client
		/// <summary>
		/// Get current client.
		/// </summary>
		/// <returns>Founded client or NotFound</returns>
		[BasicAuthentication]
		[ResponseType(typeof(Client))]
		public IHttpActionResult GetClient()
		{
			if (IdentityName == null) return NotFound();
			var client = _service.GetClient(IdentityName);
			if (client == null) return NotFound();
			return Ok(client);
		}

		// POST: api/clients/register
		/// <summary>
		/// Register new client
		/// </summary>
		/// <returns>Added ware</returns>
		[ResponseType(typeof(Client))]
		[HttpPost]
		public IHttpActionResult Register(ClientValue client)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var entity = _service.Register(client);
			if (entity == null) return BadRequest("Not registered.");
			return CreatedAtRoute("DefaultApi", new {id = entity.Id}, entity);
		}

		// PUT: api/clients/register
		/// <summary>
		/// Update notifiable property of current client
		/// </summary>
		/// <param name="notifiable">New notifiable value</param>
		/// <returns>Updated client</returns>
		[BasicAuthentication]
		[ResponseType(typeof(Client))]
		[HttpPut]
		public IHttpActionResult UpdateNotifiable(bool notifiable)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			if (IdentityName == null) return NotFound();
			var client = _service.UpdateClientNotifiable(IdentityName, notifiable);
			if (client == null) return NotFound();
			return Ok(client);
		}

	}
}
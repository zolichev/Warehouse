using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Warehouse.Model.Notifications;
using Warehouse.Service;
using Warehouse.Service.Notifications;
using Warehouse.WebApi.Filters;

namespace Warehouse.WebApi.Controllers
{
	/// <summary>
	/// Notification for client.
	/// </summary>
	[BasicAuthentication]
	public class NotificationsController : ApiController
	{
		private readonly INotificationService _service = Dependency.ServiceLocator.NotificationService;

		/// <summary>
		/// Get identity name from context
		/// </summary>
		private string IdentityName => HttpContext.Current.User?.Identity?.Name;


		// GET: api/Notifications
		/// <summary>
		/// Get all notifications.
		/// </summary>
		/// <returns>All notifications</returns>
		[ResponseType(typeof(IEnumerable<Notification>))]
		public IHttpActionResult GetNotifications()
		{
			if (IdentityName == null) return NotFound();
			var notifications = _service.GetNotifications(IdentityName);
			if (notifications == null) return NotFound();
			return Ok(notifications);
		}

		// GET: api/Notifications/5
		/// <summary>
		/// Get notification by id.
		/// </summary>
		/// <param name="id">Uniq identifier of notification</param>
		/// <returns>Founded notification or NotFound</returns>
		[ResponseType(typeof(Notification))]
		public IHttpActionResult GetNotification(int id)
		{
			if (IdentityName == null) return NotFound();
			var notification = _service.GetNotification(IdentityName, id);
			if (notification == null) return NotFound();
			return Ok(notification);
		}

		// POST: api/Notifications
		/// <summary>
		/// View and make viewed next notification from client
		/// </summary>
		/// <returns>Founded and made viewed notification</returns>
		[ResponseType(typeof(Notification))]
		[HttpPost]
		public IHttpActionResult ViewNextNotification()
		{
			if (IdentityName == null) return NotFound();
			var notification = _service.ViewNextNotification(IdentityName);
			if (notification == null) return NotFound();
			return Ok(notification);
		}

		// DELETE: api/Notifications
		/// <summary>
		/// View and make viewed all notifications from client
		/// </summary>
		/// <returns>Founded and made viewed notifications</returns>
		[ResponseType(typeof(IEnumerable<Notification>))]
		[HttpDelete]
		public IHttpActionResult ViewAllNotifications()
		{
			if (IdentityName == null) return NotFound();
			var notifications = _service.ViewAllNotifications(IdentityName);
			if (notifications == null) return NotFound();
			return Ok(notifications);
		}

		// DELETE: api/Notifications/5
		/// <summary>
		/// View and remove notification from client
		/// </summary>
		/// <param name="id">Uniq identifier of notification</param>
		/// <returns>Founded and removed notification or NotFound</returns>
		[ResponseType(typeof(Notification))]
		[HttpDelete]
		public IHttpActionResult ViewNotification(int id)
		{
			if (IdentityName == null) return NotFound();
			var notification = _service.ViewNotification(IdentityName, id);
			if (notification == null) return NotFound();
			return Ok(notification);
		}
	}
}
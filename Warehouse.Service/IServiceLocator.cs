using Warehouse.Service.Clients;
using Warehouse.Service.Notifications;
using Warehouse.Service.Wares;

namespace Warehouse.Service
{
	/// <summary>
	/// Service locator
	/// </summary>
	public interface IServiceLocator
	{
		/// <summary>
		/// Ware service
		/// </summary>
		IWareService WareService { get; }

		/// <summary>
		/// Client service
		/// </summary>
		IClientService ClientService { get; }

		/// <summary>
		/// Notification service
		/// </summary>
		INotificationService NotificationService { get; }
	}
}
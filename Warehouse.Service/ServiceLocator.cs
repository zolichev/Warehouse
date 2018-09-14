using System;
using Warehouse.Service.Clients;
using Warehouse.Service.Notifications;
using Warehouse.Service.Wares;
using Warehouse.Storage.Clients;
using Warehouse.Storage.Notifications;
using Warehouse.Storage.Wares;

namespace Warehouse.Service
{
	/// <summary>
	/// Management of services.
	/// </summary>
	public class ServiceLocator : IServiceLocator
	{
		private readonly Lazy<IWareService> _wareService;
		private readonly Lazy<IClientService> _clientService;
		private readonly Lazy<INotificationService> _notiService;

		/// <summary>
		/// Greate instance of ServiceLocator
		/// </summary>
		/// <param name="wareServiceGetter">Ware service get function</param>
		/// <param name="clientServiceGetter">Client service get function</param>
		/// <param name="notificationServiceGetter">Notification service get function</param>
		public ServiceLocator(Func<IServiceLocator, IWareService> wareServiceGetter,
			Func<IServiceLocator, IClientService> clientServiceGetter,
			Func<IServiceLocator, INotificationService> notificationServiceGetter)
		{
			_wareService = new Lazy<IWareService>(() => wareServiceGetter(this));
			_clientService = new Lazy<IClientService>(() => clientServiceGetter(this));
			_notiService = new Lazy<INotificationService>(() => notificationServiceGetter(this));
		}

		/// <summary>
		/// Ware service
		/// </summary>
		public IWareService WareService => _wareService.Value;

		/// <summary>
		/// Client service
		/// </summary>
		public IClientService ClientService => _clientService.Value;

		/// <summary>
		/// Notification service
		/// </summary>
		public INotificationService NotificationService => _notiService.Value;
	}
}
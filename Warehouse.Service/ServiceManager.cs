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
	public class ServiceManager
	{
		private readonly Lazy<WareService> _wareService;
		private readonly Lazy<ClientService> _clientService;
		private readonly Lazy<NotificationService> _notiService;

		/// <summary>
		/// Static instance of ServiceManager
		/// </summary>
		public static ServiceManager Current { get; set; }

		/// <summary>
		/// Greate instance of ServiceManager
		/// </summary>
		/// <param name="wareRepository">Ware repository</param>
		/// <param name="clientRepository">Client repository</param>
		/// <param name="notificationRepository">Notification repository</param>
		public ServiceManager(IWareRepository wareRepository, IClientRepository clientRepository,
			INotificationRepository notificationRepository)
		{
			if (wareRepository == null) throw new ArgumentNullException(nameof(wareRepository));
			if (clientRepository == null) throw new ArgumentNullException(nameof(clientRepository));
			if (notificationRepository == null) throw new ArgumentNullException(nameof(notificationRepository));

			_wareService = new Lazy<WareService>(() => new WareService(wareRepository, this));
			_clientService = new Lazy<ClientService>(() => new ClientService(clientRepository, this));
			_notiService = new Lazy<NotificationService>(() => new NotificationService(notificationRepository, this));
		}

		/// <summary>
		/// Ware service
		/// </summary>
		public WareService WareService => _wareService.Value;

		/// <summary>
		/// Client service
		/// </summary>
		public ClientService ClientService => _clientService.Value;

		/// <summary>
		/// Notification service
		/// </summary>
		public NotificationService NotificationService => _notiService.Value;
	}
}
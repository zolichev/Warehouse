using System;
using Warehouse.Service;
using Warehouse.Service.Clients;
using Warehouse.Service.Notifications;
using Warehouse.Service.Wares;
using Warehouse.Storage.Clients;
using Warehouse.Storage.Notifications;
using Warehouse.Storage.Wares;

namespace Warehouse.WebApi
{
	/// <summary>
	/// Dependency config
	/// </summary>
	public static class Dependency
	{
		/// <summary>
		/// Static instance of ServiceLocator
		/// </summary>
		public static IServiceLocator ServiceLocator { get; private set; }

		/// <summary>
		/// Config dependency
		/// </summary>
		public static void Config()
		{
			IWareService WareServiceGetter(IServiceLocator serviceLocator) => new WareService(new WareRepository(), serviceLocator);
			IClientService ClientServiceGetter(IServiceLocator serviceLocator) => new ClientService(new ClientRepository(), serviceLocator);
			INotificationService NotificationServiceGetter(IServiceLocator serviceLocator) => new NotificationService(new NotificationRepository(), serviceLocator);
			ServiceLocator = new ServiceLocator(WareServiceGetter, ClientServiceGetter, NotificationServiceGetter);
		}
	}
}
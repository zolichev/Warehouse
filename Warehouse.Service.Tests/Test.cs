using Warehouse.Service.Clients;
using Warehouse.Service.Notifications;
using Warehouse.Service.Tests.MemoryStorage;
using Warehouse.Service.Wares;
using Warehouse.Storage.Clients;
using Warehouse.Storage.Notifications;
using Warehouse.Storage.Wares;

namespace Warehouse.Service.Tests
{
	public static class Test
	{
		public static IServiceLocator ServiceLocator { get; private set; }

		public static void Config()
		{
			if (ServiceLocator == null)
			{
				IWareService WareServiceGetter(IServiceLocator serviceLocator) => new WareService(new WareRepositoryTest(), serviceLocator);
				IClientService ClientServiceGetter(IServiceLocator serviceLocator) => new ClientService(new ClientRepositoryTest(), serviceLocator);
				INotificationService NotificationServiceGetter(IServiceLocator serviceLocator) => new NotificationService(new NotificationRepositoryTest(), serviceLocator);
				ServiceLocator = new ServiceLocator(WareServiceGetter, ClientServiceGetter, NotificationServiceGetter);
			}
			DbInitializerTest.Initialize();
		}
	}
}
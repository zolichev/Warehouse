using Warehouse.Service.Tests.MemoryStorage;

namespace Warehouse.Service.Tests
{
	public static class TestConfig
	{
		public static void Register()
		{
			if (ServiceManager == null)
			{
				ServiceManager = new ServiceManager(new WareRepositoryTest(), new ClientRepositoryTest(),
					new NotificationRepositoryTest());
				ServiceManager.Current = ServiceManager;
			}
			DbInitializerTest.Initialize();
		}

		public static ServiceManager ServiceManager { get; private set; }
	}
}
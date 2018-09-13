using Warehouse.Service;
using Warehouse.Storage.Clients;
using Warehouse.Storage.Notifications;
using Warehouse.Storage.Wares;

namespace Warehouse.WebApi
{
	/// <summary>
	/// Dependency config
	/// </summary>
	public class DependencyConfig
	{
		/// <summary>
		/// Register config
		/// </summary>
		public static void Register()
		{
			ServiceManager.Current = new ServiceManager(new WareRepository(), new ClientRepository(), new NotificationRepository());
		}
	}
}
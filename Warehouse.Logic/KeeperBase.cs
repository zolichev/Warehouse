using System;

namespace Warehouse.Api
{
	/// <summary>
	/// Storing goods and observe it.
	/// </summary>
	public abstract class KeeperBase : INotificator
	{
		public IDisposable Subscribe(IObserver<Notification> observer)
		{
			throw new NotImplementedException();
		}
	}
}
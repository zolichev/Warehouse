using System;
using System.Collections.Generic;
using Warehouse.Model.Notifications;
using Warehouse.Model.Wares;

namespace Warehouse.Service.Wares
{
	/// <summary>
	/// Storing Wares and observe it.
	/// </summary>
	internal class Tracker : IObservable<NotificationValue>
	{
		private readonly List<IObserver<NotificationValue>> _observers = new List<IObserver<NotificationValue>>();

		/// <inheritdoc />
		public IDisposable Subscribe(IObserver<NotificationValue> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}

			return new Unsubscriber(_observers, observer);
		}

		private class Unsubscriber : IDisposable
		{
			private readonly List<IObserver<NotificationValue>> _observers;
			private readonly IObserver<NotificationValue> _observer;

			public Unsubscriber(List<IObserver<NotificationValue>> observers, IObserver<NotificationValue> observer)
			{
				_observers = observers;
				_observer = observer;
			}

			public void Dispose()
			{
				if (_observer != null && _observers.Contains(_observer))
				{
					_observers.Remove(_observer);
				}
			}
		}

		/// <summary>
		/// New Ware added to store
		/// </summary>
		/// <param name="ware">Ware</param>
		public void WareStored(Ware ware)
		{
			_observers.ForEach(i =>
				i.OnNext(new NotificationValue(ware.Id, ware.ToObjectProperties(), DateTime.Now, NotificationType.WareStored)));
		}

		/// <summary>
		/// Ware removed from store
		/// </summary>
		/// <param name="ware">Ware</param>
		public void WareTaked(Ware ware)
		{
			_observers.ForEach(i =>
				i.OnNext(new NotificationValue(ware.Id, ware.ToObjectProperties(), DateTime.Now, NotificationType.WareTaked)));
		}

		/// <summary>
		/// Ware expired in store
		/// </summary>
		/// <param name="ware">Ware</param>
		public void WareExpired(Ware ware)
		{
			_observers.ForEach(i =>
				i.OnNext(new NotificationValue(ware.Id, ware.ToObjectProperties(), DateTime.Now, NotificationType.WareExpired)));
		}
	}
}
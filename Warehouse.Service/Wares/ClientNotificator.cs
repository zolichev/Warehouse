using System;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Service.Notifications;
using Warehouse.Storage;

namespace Warehouse.Service.Wares
{
	/// <inheritdoc cref="IObserver&lt;NotificationValue&gt;" />
	internal sealed class ClientNotificator : IObserver<NotificationValue>, IDisposable
	{
		private readonly INotificationService _notificationService;
		private readonly Client _client;
		private IDisposable _unsubscriber;

		/// <inheritdoc />
		public ClientNotificator(Client client, INotificationService notificationService)
		{
			_client = client;
			_notificationService = notificationService;
		}

		/// <summary>
		/// Subscribe to provider
		/// </summary>
		/// <param name="provider">Notification provider</param>
		public void Subscribe(IObservable<NotificationValue> provider)
		{
			if (provider != null)
			{
				_unsubscriber = provider.Subscribe(this);
			}
		}

		/// <inheritdoc />
		public void OnCompleted()
		{
			this.Unsubscribe();
		}

		/// <inheritdoc />
		public void OnNext(NotificationValue value)
		{
			var notification = new Notification(_client.Id, value);
			if (!_notificationService.Exist(notification))
				_notificationService.Add(notification);
		}

		/// <inheritdoc />
		public void OnError(Exception e)
		{
		}

		/// <summary>
		/// Unsubscribe from provider
		/// </summary>
		public void Unsubscribe()
		{
			_unsubscriber.Dispose();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			_unsubscriber?.Dispose();
		}
	}
}
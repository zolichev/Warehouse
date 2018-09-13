using System;
using System.Collections.Generic;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Model.Wares;

namespace Warehouse.Service.Tests.MemoryStorage
{
	internal class WarehouseContextTest 
	{
		private static readonly Lazy<WarehouseContextTest> Context = new Lazy<WarehouseContextTest>();
		public static WarehouseContextTest Current => Context.Value;

		/// <summary>
		/// Wares
		/// </summary>
		public List<Ware> Wares { get; }

		/// <summary>
		/// Notifications
		/// </summary>
		public List<Notification> Notifications { get;  }

		/// <summary>
		/// Clients
		/// </summary>
		public List<Client> Clients { get;  }

		public WarehouseContextTest()
		{
			Wares = new List<Ware>();
			Notifications = new List<Notification>();
			Clients = new List<Client>();
		}

	}
}
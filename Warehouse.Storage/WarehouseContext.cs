using System;
using System.Data.Entity;
using Warehouse.Model.Clients;
using Warehouse.Model.Notifications;
using Warehouse.Model.Wares;
using Warehouse.Storage.Notifications;

namespace Warehouse.Storage
{
	/// <inheritdoc cref="DbContext" />
	internal class WarehouseContext : DbContext
	{
		private static readonly Lazy<WarehouseContext> Context = new Lazy<WarehouseContext>();

		public static WarehouseContext Current => Context.Value;

		/// <summary>
		/// Wares
		/// </summary>
		public DbSet<Ware> Wares { get; set; }

		/// <summary>
		/// Notifications
		/// </summary>
		public DbSet<StoringNotification> Notifications { get; set; }

		/// <summary>
		/// Clients
		/// </summary>
		public DbSet<Client> Clients { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<StoringNotification>().Property(p => p.PropertiesData).HasColumnType("xml");
		}
	}
}
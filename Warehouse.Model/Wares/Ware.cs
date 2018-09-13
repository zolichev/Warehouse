using System;
using System.Collections.Generic;
using System.Globalization;
using Warehouse.Model.Notifications;

namespace Warehouse.Model.Wares
{
	/// <summary>
	/// Represent stored ware.
	/// </summary>
	public class Ware : WareValue, IEntity
	{
		/// <summary>
		/// Uniq identifier.
		/// </summary>
		public int Id { get; protected set; }

		/// <summary>
		/// Create ware from basic object
		/// </summary>
		/// <param name="ware">Ware basic object</param>
		public Ware(WareValue ware) : this(ware.Name, ware.Type, ware.ExpirationDate)
		{
		}

		/// <summary>
		/// Create ware by properties
		/// </summary>
		/// <param name="name">Name of ware</param>
		/// <param name="type">Type of ware</param>
		/// <param name="expirationDate">Expiration date of ware</param>
		public Ware(string name, WareType type, DateTime expirationDate)
		{
			Name = name;
			ExpirationDate = expirationDate;
			Type = type;
		}

		/// <summary>
		/// Constructor for EF.
		/// </summary>
		protected Ware() { }

		/// <summary>
		/// Represent as NotificationObject.
		/// </summary>
		/// <returns>NotificationObject contains properties values.</returns>
		public virtual Dictionary<string, string> ToObjectProperties()
		{
			return new Dictionary<string, string>()
			{
				["Name"] = Name,
				["ExpirationDate"] = ExpirationDate.ToString(CultureInfo.InvariantCulture),
				["Type"] = Enum.GetName(typeof(WareType), Type),
				// Instead of manual filling may using reflection
			};
		}
	}
}
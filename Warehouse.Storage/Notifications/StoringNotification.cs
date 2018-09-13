using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Warehouse.Model.Notifications;

namespace Warehouse.Storage.Notifications
{
	[Table("Notifications")]
	internal class StoringNotification : Notification
	{
		/// <summary>
		/// Contains XML data of the Properties
		/// </summary>
		[IgnoreDataMember]
		public string PropertiesData
		{
			get
			{
				var xElem = new XElement(
					"items",
					ObjectProperties.Select(x =>
						new XElement("item", new XAttribute("key", x.Key), new XAttribute("value", x.Value)))
				);
				return xElem.ToString();
			}
			set
			{
				var xElem = XElement.Parse(value);
				var dict = xElem.Descendants("item")
					.ToDictionary(
						x => (string)x.Attribute("key"),
						x => (string)x.Attribute("value"));
				ObjectProperties = new ReadOnlyDictionary<string, string>(dict);
			}
		}

		public StoringNotification(Notification notification):
			base(notification.ClientId, notification.ObjectId, notification.ObjectProperties, notification.DateTime, notification.Type)
		{
			Id = notification.Id;
		}

		/// <summary>
		/// For EF
		/// </summary>
		public StoringNotification()
		{
			
		}

		public void Update(Notification notification)
		{
			if (ClientId != notification.ClientId) ClientId = notification.ClientId;
			if (ObjectId != notification.ObjectId) ObjectId = notification.ObjectId;
			if (DateTime != notification.DateTime) DateTime = notification.DateTime;
			if (Type != notification.Type) Type = notification.Type;
			if (Viewed != notification.Viewed) Viewed = notification.Viewed;
		}
	}
}
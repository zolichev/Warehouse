using System.Runtime.Serialization;

namespace Warehouse.Model.Clients
{

	/// <summary>
	/// Client of warehouse
	/// </summary>
	public class Client : IEntity
	{
		/// <summary>
		/// Uniq identifier.
		/// </summary>
		public int Id { get; protected set; }

		/// <summary>
		/// Client login.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Client must be notified about happens.
		/// </summary>
		public bool Notifiable { get; set; }

		/// <summary>
		/// Client password hash.
		/// </summary>
		[IgnoreDataMember]
		public string PasswordHash { get; protected set; }

		/// <summary>
		/// Create client from basic object
		/// </summary>
		/// <param name="clientValue">Client basic object</param>
		/// <param name="passwordHash">Client password hash</param>
		public Client(ClientValue clientValue, string passwordHash): this(clientValue.Login, passwordHash, clientValue.Notifiable)
		{
		}

		/// <inheritdoc />
		public Client(string login, string passwordHash, bool notifiable)
		{
			Login = login;
			PasswordHash = passwordHash;
			Notifiable = notifiable;
		}

		/// <summary>
		/// For EF.
		/// </summary>
		protected Client()
		{
		}

	};
}
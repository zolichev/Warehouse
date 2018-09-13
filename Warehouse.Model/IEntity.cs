namespace Warehouse.Model
{
	/// <summary>
	/// Base for entities.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		/// Uniq identifier.
		/// </summary>
		int Id { get; }
	}
}
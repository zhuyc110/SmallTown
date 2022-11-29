namespace SmallTown.Entity
{
    /// <summary>
    /// The type of entity.
    /// </summary>
    public interface IEntityType
    {
        /// <summary>
        /// Gets the id of the type.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public string Name { get; }
  }
}
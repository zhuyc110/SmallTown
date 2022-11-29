namespace SmallTown.EntityType
{
    /// <summary>
    /// The type of entity.
    /// </summary>
    public interface IEntityType
    {
        /// <summary>
        /// Gets the id of the type.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public string Name { get; init; }
    }
}
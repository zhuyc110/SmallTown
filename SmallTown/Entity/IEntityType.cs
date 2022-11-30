namespace SmallTown.Entity
{
    /// <summary>
    /// The type of entity.
    /// </summary>
    public class EntityType
    {
        /// <summary>
        /// Gets the id of the type.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public string Name { get; init; }

        public static readonly EntityType Person = new EntityType { Id = Guid.NewGuid(), Name = "Name" };
    }
}
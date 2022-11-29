using SmallTown.EntityType;

namespace SmallTown.Entity
{
    /// <summary>
    ///   Basic of every entity.
    /// </summary>
    public interface IEntity
    {
        public Guid Id { get; }

        public IEntityType EntityType { get; }
    }
}
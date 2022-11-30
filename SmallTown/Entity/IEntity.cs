using SmallTown.Entity.Component;
using SmallTown.GameSystem;
using System.Numerics;

namespace SmallTown.Entity
{
    /// <summary>
    ///   Basic of every entity.
    /// </summary>
    public interface IEntity : IGameObject
    {
        public EntityType EntityType { get; }

        public Vector2 Location { get; }

        public IReadOnlyCollection<IComponent> Components { get; }
    }
}
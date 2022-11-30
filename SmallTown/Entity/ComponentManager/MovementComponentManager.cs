using SmallTown.Entity.Component;
using System.Numerics;

namespace SmallTown.Entity.ComponentManager
{
    public class MovementComponentManager : IMovementComponentManager
    {
        private readonly HashSet<MovementComponent> _components;

        public MovementComponentManager()
        {
            _components = new HashSet<MovementComponent>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public IReadOnlyCollection<MovementComponent> GetComponents()
        {
            return _components;
        }

        public MovementComponent Create(Vector2 data)
        {
            var component = new MovementComponent(data, properties: new MovementProperties { CanWalk = true });
            _components.Add(component);
            return component;
        }

        public async Task UpdateAsync()
        {
            foreach (var movementComponent in GetComponents())
            {
                await movementComponent.UpdateAsync();
            }
        }
    }
}
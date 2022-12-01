using SmallTown.Function.Framework.Component;
using System.Numerics;

namespace SmallTown.Function.Framework.ComponentManager
{
    public class MovementComponentManager : IMovementComponentManager
    {
        private readonly HashSet<MovementComponent> _components;

        public MovementComponentManager()
        {
            _components = new HashSet<MovementComponent>();
        }

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
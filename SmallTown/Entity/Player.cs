using SmallTown.Entity.Component;
using SmallTown.Entity.ComponentManager;
using SmallTown.Extension;
using SmallTown.GameSystem;
using System.Numerics;

namespace SmallTown.Entity
{
    public class Player : IEntity, IInitializableGameObject
    {
        private readonly ISmallTownOutput _smallTownOutput;
        private readonly IMovementComponentManager _movementComponentManager;

        public Guid Id { get; }

        public EntityType EntityType { get; }

        public IReadOnlyCollection<IComponent> Components { get; }

        public Vector2 Location => Movement.Location;

        private MovementComponent Movement { get; set; }

        public Player(ISmallTownOutput smallTownOutput, IMovementComponentManager movementComponentManager, Vector2 location = default)
        {
            _smallTownOutput = smallTownOutput;
            _movementComponentManager = movementComponentManager;
            Id = Guid.NewGuid();
            Components = InitComponents(location);
            EntityType = EntityType.Person;
        }

        public Task StartAsync()
        {
            _smallTownOutput.Print($"Player starts here: {Location}");
            Movement.SetVelocity(Vector2.UnitX);
            return Task.CompletedTask;
        }

        public Task UpdateAsync()
        {
            _smallTownOutput.Print($"Player is here: {Location}");
            return Task.CompletedTask;
        }

        private IReadOnlyCollection<IComponent> InitComponents(Vector2 location)
        {
            Movement = _movementComponentManager.Create(location);
            var result = new List<IComponent>
            {
                Movement
            };
            return result;
        }
    }
}
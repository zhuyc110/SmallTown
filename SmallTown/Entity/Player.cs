using SmallTown.Function;
using SmallTown.Function.Framework.Component;
using SmallTown.Function.Framework.ComponentManager;
using SmallTown.Platform;
using System.Numerics;

namespace SmallTown.Entity
{
    public class Player : IInitializableGameObject
    {
        private readonly ISmallTownOutput _smallTownOutput;
        private readonly IMovementComponentManager _movementComponentManager;
        private readonly Vector2 _initLocation;

        private MovementComponent _movement;

        public Guid Id { get; }

        public IReadOnlyCollection<IComponent> Components { get; private set; }

        public Vector2 Location => _movement.Location;

        public Player(ISmallTownOutput smallTownOutput, IMovementComponentManager movementComponentManager, Vector2 location = default)
        {
            _smallTownOutput = smallTownOutput;
            _movementComponentManager = movementComponentManager;
            Id = Guid.NewGuid();
            _initLocation = location;
        }

        public Task StartAsync()
        {
            InitComponents();
            _smallTownOutput.Print($"Player starts here: {Location}");
            _movement.SetVelocity(Vector2.UnitX);
            return Task.CompletedTask;
        }

        public Task UpdateAsync()
        {
            _smallTownOutput.Print($"Player is here: {Location}");
            return Task.CompletedTask;
        }

        private void InitComponents()
        {
            _movement = _movementComponentManager.Create(_initLocation);
            Components= new List<IComponent>
            {
                _movement
            };
        }
    }
}
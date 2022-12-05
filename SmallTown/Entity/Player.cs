using SmallTown.Function;
using SmallTown.Function.Framework.Component;
using SmallTown.Function.Framework.ComponentManager;
using SmallTown.Platform;
using System.Numerics;
using System.Threading.Tasks;

namespace SmallTown.Entity
{
    public class Player : GameObjectBase, IInitializableGameObject
    {
        private readonly ISmallTownOutput _smallTownOutput;
        private readonly IMovementComponentManager _movementComponentManager;
        private readonly Vector2 _initLocation;

        private MovementComponent _movement;

        public Vector2 Location => _movement.Location;

        public Player(ISmallTownOutput smallTownOutput, IMovementComponentManager movementComponentManager, Vector2 location = default)
            : base()
        {
            _smallTownOutput = smallTownOutput;
            _movementComponentManager = movementComponentManager;
            _initLocation = location;
        }

        public Task StartAsync()
        {
            InitComponents();
            _smallTownOutput.Print($"Player starts here: {Location}");
            _movement.SetVelocity(Vector2.UnitX);
            return Task.CompletedTask;
        }

        public override Task UpdateAsync()
        {
            _smallTownOutput.Print($"Player is here: {Location}");
            return Task.CompletedTask;
        }

        private void InitComponents()
        {
            _movement = _movementComponentManager.Create(_initLocation);
            Components.Add(_movement);
        }
    }
}
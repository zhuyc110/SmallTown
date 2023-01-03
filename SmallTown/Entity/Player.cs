using SmallTown.Function;
using SmallTown.Function.Framework.Component.Movement;
using SmallTown.Function.Framework.Component.RigidBody;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Platform;
using System.Numerics;

namespace SmallTown.Entity
{
    public class Player : GameObjectBase, IInitializableGameObject
    {
        private readonly Vector2 _initLocation;
        private readonly ISmallTownOutput _smallTownOutput;

        private MovementComponent _movement;

        public Player(ISmallTownOutput smallTownOutput, Vector2 location = default)
        {
            _smallTownOutput = smallTownOutput;
            _initLocation = location;
        }

        public Vector2 Location => _movement.Location;

        public Task StartAsync()
        {
            InitComponents();
            _smallTownOutput.Print($"Player starts here: {Location}");
            _movement.SetVelocity(Vector2.UnitX);
            return Task.CompletedTask;
        }

        public override async Task UpdateAsync()
        {
            _smallTownOutput.Print($"Player is here: {Location}");
            await base.UpdateAsync();
        }

        private void InitComponents()
        {
            _movement = new MovementComponent(this, _initLocation, new MovementProperties { CanWalk = true });
            var rigidBody = new RigidBodyComponent(this);

            Components.Add(_movement);
            Components.Add(rigidBody);
        }
    }
}
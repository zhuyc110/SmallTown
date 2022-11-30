using System.Numerics;

namespace SmallTown.Entity.Component
{
    public class MovementComponent : IComponent
    {
        public MovementComponent() : this(Vector2.Zero, MovementProperties.StillLife)
        {
        }

        internal MovementComponent(Vector2 location, MovementProperties properties)
        {
            Location = location;
            Velocity = Vector2.Zero;
            Id = Guid.NewGuid();
            Properties = properties;
        }

        /// <summary>
        /// One day it will be a dedicate component.
        /// </summary>
        public Vector2 Location { get; private set; }

        public Vector2 Velocity { get; private set; }

        public MovementProperties Properties { get; private set; }

        public Guid Id { get; }

        public Task UpdateAsync()
        {
            Location += Velocity;
            return Task.CompletedTask;
        }

        public void ChangeMovement(bool canWalk = false, bool canFly = false, bool canSwim = false)
        {
            Properties = new MovementProperties { CanFly = canFly, CanSwim = canSwim, CanWalk = canWalk };
        }

        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Location} v: {Velocity}";
        }
    }
}
using SmallTown.Function.Framework.GameObject;
using System.Numerics;

namespace SmallTown.Function.Framework.Component.Movement
{
    public class MovementComponent : ComponentBase
    {
        internal MovementComponent(IGameObject parent, Vector2 location, MovementProperties properties)
        :base(parent)
        {
            Location = location;
            Velocity = Vector2.Zero;
            Properties = properties;
        }

        /// <summary>
        /// One day it will be a dedicate component.
        /// </summary>
        public Vector2 Location { get; private set; }

        public Vector2 Velocity { get; private set; }

        public MovementProperties Properties { get; private set; }

        public override Task UpdateAsync()
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
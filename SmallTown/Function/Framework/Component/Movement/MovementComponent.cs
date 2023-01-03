using SmallTown.Function.Framework.Component.Transform;
using SmallTown.Function.Framework.GameObject;
using System.Numerics;

namespace SmallTown.Function.Framework.Component.Movement
{
    public class MovementComponent : ComponentBase
    {
        internal MovementComponent(IGameObject parent, MovementProperties properties)
        :base(parent)
        {
            Velocity = Vector2.Zero;
            Properties = properties;
        }

        public Vector2 Velocity { get; private set; }

        public MovementProperties Properties { get; private set; }

        public override Task UpdateAsync()
        {
            Parent.GetComponent<TransformComponent>()!.Location += Velocity;
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
            return $"{Parent.GetComponent<TransformComponent>()!.Location} v: {Velocity}";
        }
    }
}
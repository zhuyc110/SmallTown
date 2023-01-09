using System.Numerics;

namespace SmallTown.Function.Physics
{
    public class RigidBody : IRigidBody
    {
        public Guid Id { get; }

        public bool Active { get; } = true;

        public Vector2 Velocity { get; }

        public Vector2 Position { get; }

        private RigidBody(Vector2 position, Vector2 velocity)
        {
            Velocity = velocity;
            Position = position;
            Id = Guid.NewGuid();
        }

        public static IRigidBody Create(Vector2 position, Vector2 velocity)
        {
            return new RigidBody(position, velocity);
        }
    }
}

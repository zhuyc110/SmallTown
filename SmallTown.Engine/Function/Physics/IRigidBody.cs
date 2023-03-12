
using System.Numerics;

namespace SmallTown.Function.Physics
{
    public interface IRigidBody
    {
        Guid Id { get; }

        bool Active { get; }

        Vector2 Velocity { get; }

        Vector2 Position { get; }
    }
}

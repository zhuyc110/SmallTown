using System.Numerics;

namespace SmallTown.Function.Physics
{
    public interface IPhysicsScene
    {
        Guid CreateRigidBody(Vector2 position);

        void RemoveRigidBody(Guid id);
    }
}
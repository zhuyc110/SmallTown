using SmallTown.Entity.Component;
using System.Numerics;

namespace SmallTown.Entity.ComponentManager
{
    public interface IMovementComponentManager : IComponentManager<MovementComponent, Vector2>
    {
    }
}
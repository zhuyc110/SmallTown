using SmallTown.Entity.Component;
using SmallTown.GameSystem;

namespace SmallTown.Entity.ComponentManager
{
    public interface IComponentManager<out TComponent, in TData> : IGameObject
        where TComponent : IComponent
    {
        IReadOnlyCollection<TComponent> GetComponents();

        TComponent Create(TData data);
    }
}
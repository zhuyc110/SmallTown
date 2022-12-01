using SmallTown.Function.Framework.Component;

namespace SmallTown.Function.Framework.ComponentManager
{
    public interface IComponentManager<out TComponent, in TData>
        where TComponent : IComponent
    {
        IReadOnlyCollection<TComponent> GetComponents();

        TComponent Create(TData data);

        Task UpdateAsync();
    }
}
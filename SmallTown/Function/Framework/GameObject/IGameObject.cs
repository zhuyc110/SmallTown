using SmallTown.Function.Framework.Component;

namespace SmallTown.Function.Framework.GameObject
{
    public interface IGameObject
    {
        public Guid Id { get; }

        Task UpdateAsync();

        public ICollection<IComponent> Components { get; }

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    }
}
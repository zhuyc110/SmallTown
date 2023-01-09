using SmallTown.Function.Framework.Component;

namespace SmallTown.Function.Framework.GameObject
{
    public interface IGameObject: IUpdatable
    {
        public Guid Id { get; }

        public ICollection<IComponent> Components { get; }

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    }
}
using SmallTown.Function.Framework.Component;
using SmallTown.Function.Framework.World;

namespace SmallTown.Function.Framework.GameObject
{
    public interface IGameObject: IUpdatable
    {
        public Guid Id { get; }

        public ICollection<IComponent> Components { get; }

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    }
}
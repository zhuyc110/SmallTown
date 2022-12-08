using SmallTown.Function.Framework.Component;

namespace SmallTown.Function.Framework.GameObject
{
    public abstract class GameObjectBase : IGameObject
    {
        protected GameObjectBase()
        {
            Id = Guid.NewGuid();
            Components = new List<IComponent>();
        }

        public Guid Id { get; }

        public ICollection<IComponent> Components { get; }

        public abstract Task UpdateAsync();

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent
        {
            return Components.Where(component => typeof(TComponent) == component.GetType()).Cast<TComponent>().FirstOrDefault();
        }
    }
}
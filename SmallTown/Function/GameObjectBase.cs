using SmallTown.Function.Framework.Component;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallTown.Function
{
    public abstract class GameObjectBase : IGameObject
    {
        public Guid Id { get; }

        public ICollection<IComponent> Components { get; }

        public GameObjectBase()
        {
            Id = Guid.NewGuid();
            Components = new List<IComponent>();
        }

        public abstract Task UpdateAsync();

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent
        {
            foreach (var component in Components)
            {
                if (typeof(TComponent) == component.GetType())
                {
                    return (TComponent)component;
                }
            }

            return null;
        }
    }
}

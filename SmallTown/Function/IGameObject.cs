using SmallTown.Function.Framework.Component;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallTown.Function
{
    public interface IGameObject
    {
        public Guid Id { get; }

        Task UpdateAsync();

        public ICollection<IComponent> Components { get; }

        public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    }
}
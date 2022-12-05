using System;
using System.Threading.Tasks;

namespace SmallTown.Function.Framework.Component
{
    public abstract class ComponentBase : IComponent
    {
        protected WeakReference<IGameObject> Parent { get; }

        protected ComponentBase(IGameObject parent)
        {
            Parent = new WeakReference<IGameObject>(parent);
        }

        public abstract Task UpdateAsync();
    }
}

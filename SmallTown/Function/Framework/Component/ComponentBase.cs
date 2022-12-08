using SmallTown.Function.Framework.GameObject;

namespace SmallTown.Function.Framework.Component
{
    public abstract class ComponentBase : IComponent
    {
        protected WeakReference<IGameObject> Parent { get; }

        protected ComponentBase(IGameObject parent)
        {
            Parent = new WeakReference<IGameObject>(parent);
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public abstract Task UpdateAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeResources();
            }
        }

        protected virtual void DisposeResources()
        {

        }
    }
}
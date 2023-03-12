using SmallTown.Function.Framework.GameObject;

namespace SmallTown.Function.Framework.Component
{
    public abstract class ComponentBase : IComponent
    {
        protected IGameObject Parent
        {
            get
            {
                if (_parent.TryGetTarget(out var parent))
                {
                    return parent;
                }

                throw new ObjectDisposedException(nameof(Parent));
            }
        }

        private readonly WeakReference<IGameObject> _parent;

        protected ComponentBase(IGameObject parent)
        {
            _parent = new WeakReference<IGameObject>(parent);
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

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
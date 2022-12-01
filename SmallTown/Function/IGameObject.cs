using SmallTown.Function.Framework.Component;

namespace SmallTown.Function
{
    public interface IGameObject
    {
        public Guid Id { get; }

        Task UpdateAsync();

        public IReadOnlyCollection<IComponent> Components { get; }
    }
}
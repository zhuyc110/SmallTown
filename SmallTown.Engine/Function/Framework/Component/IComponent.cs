namespace SmallTown.Function.Framework.Component
{
    public interface IComponent : IDisposable, IUpdatable
    {
        Guid Id { get; }
    }
}
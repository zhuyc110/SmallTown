namespace SmallTown.Function.Framework.Component
{
    public interface IComponent : IDisposable
    {
        Guid Id { get; }
        Task UpdateAsync();
    }
}
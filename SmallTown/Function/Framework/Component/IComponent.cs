namespace SmallTown.Function.Framework.Component
{
    public interface IComponent
    {
        Guid Id { get; }
        Task UpdateAsync();
    }
}
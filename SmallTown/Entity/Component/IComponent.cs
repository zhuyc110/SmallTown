namespace SmallTown.Entity.Component
{
    public interface IComponent
    {
        Guid Id { get; }
        Task UpdateAsync();
    }
}
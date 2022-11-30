namespace SmallTown.GameSystem
{
    public interface IGameObject
    {
        public Guid Id { get; }

        Task UpdateAsync();
    }
}
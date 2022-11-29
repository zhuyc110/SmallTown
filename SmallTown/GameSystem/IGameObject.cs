namespace SmallTown.GameSystem
{
    public interface IGameObject
    {
        Task StartAsync();

        Task UpdateAsync();
    }
}
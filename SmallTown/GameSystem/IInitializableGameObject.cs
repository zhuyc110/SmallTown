namespace SmallTown.GameSystem
{
    public interface IInitializableGameObject : IGameObject
    {
        Task StartAsync();

    }
}
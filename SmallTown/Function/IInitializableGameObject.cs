namespace SmallTown.Function
{
    public interface IInitializableGameObject : IGameObject
    {
        Task StartAsync();

    }
}
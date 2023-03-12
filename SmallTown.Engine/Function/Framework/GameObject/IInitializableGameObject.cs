namespace SmallTown.Function.Framework.GameObject
{
    public interface IInitializableGameObject : IGameObject
    {
        Task StartAsync();

    }
}
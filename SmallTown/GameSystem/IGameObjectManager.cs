using SmallTown.Entity;

namespace SmallTown.GameSystem
{
    public interface IGameObjectManager
    {
        IReadOnlyCollection<IGameObject> GameObjects { get; }
    }
}
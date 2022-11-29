using SmallTown.Entity;

namespace SmallTown.GameSystem
{
    public interface IGameObjectManager
    {
        ICollection<IGameObject> GameObjects { get; }

        Guid RegisterGameObject(IGameObject gameObject);
    }
}
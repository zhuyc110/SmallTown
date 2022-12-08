namespace SmallTown.Function.Framework.GameObject
{
    public interface IGameObjectManager
    {
        ICollection<IGameObject> GameObjects { get; }

        Guid RegisterGameObject(IGameObject gameObject);

        IGameObject? GetGameObject(Guid gameObjectId);
    }
}
namespace SmallTown.GameSystem
{
    internal sealed class GameObjectManager : IGameObjectManager
    {
        private readonly IDictionary<Guid, IGameObject> _gameObjects;

        public GameObjectManager()
        {
            _gameObjects = new Dictionary<Guid, IGameObject>();
        }

        public ICollection<IGameObject> GameObjects => _gameObjects.Values;

        public Guid RegisterGameObject(IGameObject gameObject)
        {
            var id = new Guid();
            _gameObjects.Add(id, gameObject);
            return id;
        }
    }
}
﻿using System.Collections.Concurrent;

namespace SmallTown.Function.Framework.GameObject
{
    internal sealed class GameObjectManager : IGameObjectManager
    {
        private readonly IDictionary<Guid, IGameObject> _gameObjects;

        public GameObjectManager()
        {
            _gameObjects = new ConcurrentDictionary<Guid, IGameObject>();
        }

        public ICollection<IGameObject> GameObjects => _gameObjects.Values;

        public Guid RegisterGameObject(IGameObject gameObject)
        {
            _gameObjects.Add(gameObject.Id, gameObject);
            return gameObject.Id;
        }

        public IGameObject? GetGameObject(Guid gameObjectId)
        {
            if (_gameObjects.TryGetValue(gameObjectId, out var result))
            {
                return result;
            }

            return null;
        }
    }
}
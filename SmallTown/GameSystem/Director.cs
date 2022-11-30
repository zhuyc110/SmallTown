using SmallTown.Entity;
using SmallTown.Entity.ComponentManager;
using SmallTown.Extension;
using System.Numerics;

namespace SmallTown.GameSystem
{
    public class Director : IDirector
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly IMovementComponentManager _movementComponentManager;
        private readonly ISmallTownOutput _smallTownOutput;

        public Director(ISmallTownOutput smallTownOutput, IGameObjectManager gameObjectManager, IMovementComponentManager movementComponentManager)
        {
            _smallTownOutput = smallTownOutput;
            _gameObjectManager = gameObjectManager;
            _movementComponentManager = movementComponentManager;
        }

        public Task StartAsync()
        {
            _gameObjectManager.RegisterGameObject(_movementComponentManager);

            return Task.Run(() =>
            {
                var user = new Player(_smallTownOutput, _movementComponentManager, new Vector2(4, 2));
                _gameObjectManager.RegisterGameObject(user);
            });
        }
    }
}
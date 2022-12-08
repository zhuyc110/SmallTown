using SmallTown.Entity;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Platform;
using System.Numerics;

namespace SmallTown.Function.Framework.World
{
    public class Director : IDirector
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly ISmallTownOutput _smallTownOutput;

        public Director(ISmallTownOutput smallTownOutput, IGameObjectManager gameObjectManager)
        {
            _smallTownOutput = smallTownOutput;
            _gameObjectManager = gameObjectManager;
        }

        public Task StartAsync()
        {
            return Task.Run(() =>
            {
                var user = new Player(_smallTownOutput, new Vector2(4, 2));
                _gameObjectManager.RegisterGameObject(user);
            });
        }
    }
}
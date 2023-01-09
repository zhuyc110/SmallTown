using SmallTown.Entity;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Platform;
using System.Numerics;

namespace SmallTown.Function.Framework.World
{
    public class LevelDirector : ILevelDirector
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly ISmallTownOutput _smallTownOutput;

        public LevelDirector(ISmallTownOutput smallTownOutput, IGameObjectManager gameObjectManager)
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
using SmallTown.Entity;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Platform;
using SmallTown.Resource;
using System.Numerics;

namespace SmallTown.Function.Framework.World
{
    public class LevelDirector : ILevelDirector
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly IAssetManager _assetManager;
        private readonly ISmallTownOutput _smallTownOutput;

        public LevelDirector(ISmallTownOutput smallTownOutput, IGameObjectManager gameObjectManager, IAssetManager assetManager)
        {
            _smallTownOutput = smallTownOutput;
            _gameObjectManager = gameObjectManager;
            _assetManager = assetManager;
        }

        public async Task StartAsync()
        {
            var asset = await _assetManager.Load("./Asset/Level/Level.1-1.json");

            await Task.Run(() =>
            {
                //var user = new Player(_smallTownOutput, new Vector2(4, 2));
                //var playerObject = asset?[nameof(Player).ToLowerInvariant()];
                //if (playerObject != null)
                //{
                //    user.Name = playerObject[nameof(Player.Name).ToLowerInvariant()]?.ToString() ?? string.Empty;
                //}

                //_gameObjectManager.RegisterGameObject(user);
            });

            _smallTownOutput.Print("Started...");
        }
    }
}
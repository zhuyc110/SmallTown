using Microsoft.Extensions.Hosting;
using SmallTown.Config;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Function.Framework.World;
using SmallTown.Platform;

namespace SmallTown.Function
{
    internal sealed class GameTicker : BackgroundService
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly IDirector _director;
        private readonly ISmallTownOutput _smallTownOutput;
        private readonly Settings _settings;

        private bool _initialized;

        public GameTicker(IGameObjectManager gameObjectManager, 
            ISmallTownOutput smallTownOutput,
            IDirector director,
            Settings settings)
        {
            _gameObjectManager = gameObjectManager;
            _smallTownOutput = smallTownOutput;
            _director = director;
            _settings = settings;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            await _director.StartAsync();

            foreach (var gameObject in _gameObjectManager.GameObjects.OfType<IInitializableGameObject>())
            {
                await gameObject.StartAsync();
            }

            _smallTownOutput.Print($"The world initialized at {DateTime.Now:HH:mm:ss}");
            _initialized = true;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(_settings.FrameInterval, stoppingToken);

                if (!_initialized)
                {
                    continue;
                }

                _smallTownOutput.Print($"The world updated at {DateTime.Now:HH:mm:ss}");
                
                foreach (var gameObject in _gameObjectManager.GameObjects)
                {
                    await gameObject.UpdateAsync();
                }
            }
        }
    }
}
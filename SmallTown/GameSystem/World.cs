using Microsoft.Extensions.Hosting;
using SmallTown.Config;
using SmallTown.Extension;

namespace SmallTown.GameSystem
{
    internal sealed class World : BackgroundService
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly Settings _settings;
        private readonly ISmallTownOutput _smallTownOutput;

        private bool _initialized;

        public World(IGameObjectManager gameObjectManager, ISmallTownOutput smallTownOutput, Settings settings)
        {
            _gameObjectManager = gameObjectManager;
            _smallTownOutput = smallTownOutput;
            _settings = settings;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            foreach (var gameObject in _gameObjectManager.GameObjects)
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
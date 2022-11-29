using Microsoft.Extensions.Hosting;
using SmallTown.Config;

namespace SmallTown.GameSystem
{
    public sealed class World : BackgroundService
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly Settings _settings;

        public World(IGameObjectManager gameObjectManager, Settings settings)
        {
            _gameObjectManager = gameObjectManager;
            _settings = settings;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            foreach (var gameObject in _gameObjectManager.GameObjects)
            {
                await gameObject.StartAsync();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(_settings.FrameInterval, stoppingToken);

                foreach (var gameObject in _gameObjectManager.GameObjects)
                {
                    await gameObject.UpdateAsync();
                }
            }
        }
    }
}
﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SmallTown.Config;
using SmallTown.Engine.Function;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Function.Framework.World;
using SmallTown.Platform;

namespace SmallTown.Function
{
    internal sealed class GameTicker : BackgroundService
    {
        private readonly IGameObjectManager _gameObjectManager;
        private readonly ILevelDirector _levelDirector;
        private readonly ISmallTownOutput _smallTownOutput;
        private readonly IEnumerable<IInitializable> _initializables;
        private readonly Settings _settings;

        private bool _initialized;

        public GameTicker(IGameObjectManager gameObjectManager, 
            ISmallTownOutput smallTownOutput,
            ILevelDirector levelDirector,
            IEnumerable<IInitializable> initializables, 
            IOptions<Settings> settings)
        {
            _gameObjectManager = gameObjectManager;
            _smallTownOutput = smallTownOutput;
            _levelDirector = levelDirector;
            _initializables = initializables;
            _settings = settings.Value;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            foreach (var initializable in _initializables)
            {
                await initializable.StartAsync();
            }

            await _levelDirector.StartAsync();

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
                await Task.Delay(_settings.World.FrameInterval, stoppingToken);

                if (!_initialized)
                {
                    continue;
                }

                _smallTownOutput.Print($"The world updated at {DateTime.Now:HH:mm:ss}");

                await LogicalUpdate();

                await RendererUpdate();
            }
        }

        private async Task LogicalUpdate()
        {
            foreach (var gameObject in _gameObjectManager.GameObjects)
            {
                await gameObject.UpdateAsync();
            }
        }

        private async Task RendererUpdate()
        {
            await Task.CompletedTask;
        }
    }
}
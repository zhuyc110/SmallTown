using SmallTown.Engine.Function;
using SmallTown.Engine.Resource;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Shared;
public abstract class DataReadingManagerBase : IInitializable
{
    protected readonly IAssetManager _assetManager;
    protected readonly ILanguageService _languageService;

    protected DataReadingManagerBase(IAssetManager assetManager, ILanguageService languageService)
    {
        _assetManager = assetManager;
        _languageService = languageService;
    }

    public abstract Task StartAsync();
}

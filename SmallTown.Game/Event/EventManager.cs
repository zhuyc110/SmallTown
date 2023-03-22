using SmallTown.Engine.Resource;
using SmallTown.Game.Entity;
using SmallTown.Game.Shared;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Event;
public class EventManager : ReadableObjectManagerBase<Event>
{
    protected override string ReadableObjectKey => nameof(Event);

    public EventManager(IAssetManager assetManager, ILanguageService languageService) : base(assetManager, languageService)
    {
    }

    public override async Task StartAsync()
    {
        await base.StartAsync();
    }
}

using SmallTown.Engine.Resource;
using SmallTown.Game.Person;
using SmallTown.Game.Shared;
using SmallTown.Resource;

namespace SmallTown.Game.Entity;
public class EntityManager : ReadableObjectManagerBase<Entity>
{
    private readonly IRoleManager _roleManager;

    protected override string ReadableObjectKey => nameof(Entity);

    public EntityManager(IAssetManager assetManager, ILanguageService languageService, IRoleManager roleManager) : base(assetManager, languageService)
    {
        _roleManager = roleManager;
    }

    public override async Task StartAsync()
    {
        await base.StartAsync();

        foreach (var entity in ReadableObjects) 
        {
            entity.Setup(_roleManager);
        }
    }
}

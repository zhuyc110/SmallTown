using SmallTown.Engine.Function;
using SmallTown.Engine.Resource;
using SmallTown.Resource;

namespace SmallTown.Game.Shared;
public abstract class ReadableObjectManagerBase<TReadableObject> : DataReadingManagerBase
    where TReadableObject : IReadableObject
{
    protected static IReadOnlyList<TReadableObject> ReadableObjects = new List<TReadableObject>();

    protected abstract string ReadableObjectKey { get; }

    protected ReadableObjectManagerBase(IAssetManager assetManager, ILanguageService languageService)
        :base(assetManager, languageService)
    {
    }

    public override async Task StartAsync()
    {
        var personalityFilePath = $"./Data/{ReadableObjectKey}/{_languageService.CurrentLanguage}.json";
        var personalities = await _assetManager.LoadAndDeserialize<TReadableObject[]>(personalityFilePath);

        if (personalities != null)
        {
            ReadableObjects = personalities.OrderBy(x => x.Id).ToList();
        }
    }

    public virtual TReadableObject Get(int id)
    {
        if (id <= 0 || ReadableObjects.Count < id)
        {
            return ReadableObjects[0];
        }

        if (ReadableObjects[id - 1].Id != id)
        {
            return ReadableObjects[0];
        }

        return ReadableObjects[id - 1];
    }
}
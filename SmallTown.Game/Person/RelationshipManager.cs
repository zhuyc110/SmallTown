using SmallTown.Engine.Resource;
using SmallTown.Game.Shared;
using SmallTown.Resource;

namespace SmallTown.Game.Person;
public class RelationshipManager : ReadableObjectManagerBase<Relationship>
{
    protected override string ReadableObjectKey => nameof(Relationship);

    private static readonly IDictionary<int, IDictionary<Rarity, string>> LabelMapping = new Dictionary<int, IDictionary<Rarity, string>>();

    public RelationshipManager(IAssetManager assetManager, ILanguageService languageService)
        : base(assetManager, languageService)
    {
    }

    public static string GetLabel(ValueInstance<Relationship> instance)
    {
        if (LabelMapping.TryGetValue(instance.Reference.Id, out var labels) && labels.TryGetValue(instance.Rarity, out var label))
        {
            return label;
        }

        return string.Empty;
    }

    public override async Task StartAsync()
    {
        await base.StartAsync();

        var stringResourceFilePath = $"./Data/{nameof(Relationship)}/Label/{_languageService.CurrentLanguage}.json";
        var stringResource = await _assetManager.LoadAndDeserialize<IdValuePair<int, string[]>[]>(stringResourceFilePath);

        foreach (var (id, labels) in stringResource!)
        {
            LabelMapping.Add(id, labels.Select((label, index) => new { label, index }).ToDictionary(x => (Rarity)(x.index + 1), x => x.label));
        }
    }
}

using SmallTown.Engine.Resource;
using SmallTown.Game.Shared;
using SmallTown.Resource;

namespace SmallTown.Game.Person;
public class PropertyManager : ReadableObjectManagerBase<Property>
{
    protected override string ReadableObjectKey => nameof(Property);

    public PropertyManager(IAssetManager assetManager, ILanguageService languageService)
        : base(assetManager, languageService)
    {
    }

    public static Rarity GetRarity(ReadableObjectValueInstance<Property> propertyInstance)
    {
        switch (propertyInstance.Value)
        {
            case int n when n <= 4:
                return Rarity.Lousy;
            case int n when n <= 14:
                return Rarity.Poor;
            case int n when n <= 34:
                return Rarity.Common;
            case int n when n <= 64:
                return Rarity.Rare;
            case int n when n <= 84:
                return Rarity.Excellent;
            case int n when n <= 94:
                return Rarity.Epic;
            case int n when n <= 100:
                return Rarity.Legendary;
            default:
                break;
        }

        return Rarity.Undefined;
    }
}

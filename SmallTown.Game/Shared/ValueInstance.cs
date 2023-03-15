namespace SmallTown.Game.Shared;

public class ValueInstance<TReadableObject>
    where TReadableObject : IReadableObject
{
    public TReadableObject Reference { get; }

    public int Value
    {
        get => _value;
        set
        {
            if (_value == value)
            {
                return;
            }

            _value = value;
            Rarity = GetRarity(this);
        }
    }

    public Rarity Rarity { get; private set; }

    private static readonly int DefaultValue = 35;

    private int _value;

    public ValueInstance(TReadableObject reference, int? value = null)
    {
        Reference = reference;
        Value = value ?? DefaultValue;
    }

    private static Rarity GetRarity(ValueInstance<TReadableObject> instance)
    {
        switch (instance.Value)
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

    public override string ToString()
    {
        return $"{Reference}: {Value}";
    }
}

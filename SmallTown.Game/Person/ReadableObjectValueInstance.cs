using SmallTown.Game.Shared;

namespace SmallTown.Game.Person;
public class ReadableObjectValueInstance<TReadableObject>
    where TReadableObject : IReadableObject
{
    public TReadableObject Reference { get; }

    public int Value { get; set; }

    private static readonly int DefaultValue = 35;

    public ReadableObjectValueInstance(TReadableObject reference, int? value = null)
    {
        Reference = reference;
        Value = value ?? DefaultValue;
    }
}

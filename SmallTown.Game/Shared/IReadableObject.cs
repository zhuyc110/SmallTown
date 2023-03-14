namespace SmallTown.Game.Shared;
public interface IReadableObject
{
    public int Id { get; }

    public string Name { get; }

    public string Description { get; }
}

public abstract class ReadableObjectBase : IReadableObject
{
    public int Id { get; }

    public string Name { get; }

    public string Description { get; }

    public ReadableObjectBase(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return Name;
    }
}
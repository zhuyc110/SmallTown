using SmallTown.Game.Shared;

namespace SmallTown.Game.Person;
public class Role : ReadableObjectBase
{
    public float Hardness { get; set; }

    public Role(int id, string name, string description, float hardness = 0)
        : base(id, name, description)
    {
        Hardness = hardness;
    }
}

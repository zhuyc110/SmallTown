using SmallTown.Game.Shared;

namespace SmallTown.Game.Person;
public class Role : ReadableObjectBase
{
    public float Hardness { get; set; }

    public IList<Role> Children { get; set; }

    public Role(int id, string name, string description, IList<Role> children, float hardness = 0)
        : base(id, name, description)
    {
        Children = children;
        Hardness = hardness;
    }

    public Role GetChild(int id)
    {
        var parentId = id / 10000;
        var subId = id % 10000;

        if (parentId != Id)
        {
            return this;
        }

        if (Children == null || Children[subId - 1].Id != id)
        {
            return this;
        }

        return Children[subId - 1];
    }
}

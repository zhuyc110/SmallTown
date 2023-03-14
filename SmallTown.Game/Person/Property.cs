using SmallTown.Game.Shared;
using System;
using System.Linq;

namespace SmallTown.Game.Person;
public class Property : ReadableObjectBase
{
    public Property(int id, string name, string description)
        : base(id, name, description)
    {
    }
}

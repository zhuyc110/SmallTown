using SmallTown.Game.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person;
public  class Relationship : ReadableObjectBase
{
    public Relationship(int id, string name, string description)
        : base(id, name, description)
    {
    }
}

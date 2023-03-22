using SmallTown.Game.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Event;
public class Event : ReadableObjectBase
{
    public int PeopleCount { get; }
    public IList<int> LocationIds { get; }
    public IList<Condition> Conditions { get; }

    public Event(int id, string name, string description, int peopleCount, IList<int> locationIds, IList<Condition> conditions)
        : base(id, name, description)
    {
        PeopleCount = peopleCount;
        LocationIds = locationIds;
        Conditions = conditions;
    }
}

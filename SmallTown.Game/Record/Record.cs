using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Record;
public class Record : ICloneable
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public DateTime Time { get; set; }

    public Vector2 Location { get; set; }

    public string LoggedString
    {
        get
        {
            return $"In {Location} at {Time}, something happened";
        }
    }

    public object Clone()
    {
        return new Record
        {
            Id = Id,
            EventId = EventId,
            Time = Time,
            Location = Location
        };
    }
}

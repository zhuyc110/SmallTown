using SmallTown.Engine.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person;
public interface IPersonalityManager : IInitializable
{
    IReadOnlyCollection<Personality> Personalities { get; }
}

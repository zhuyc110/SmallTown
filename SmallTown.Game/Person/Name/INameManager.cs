using SmallTown.Engine.Function;
using SmallTown.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person.Name;
public interface INameManager : IInitializable
{
    IReadOnlyDictionary<float, string> LastNameRateTable { get; }
    IReadOnlyCollection<string> ExtendedLastName { get; }
    IReadOnlyDictionary<(int, Sex), string[]> FirstNameRateTable { get; }
    IReadOnlyDictionary<Sex, string[]> ExtendedFirstNameTable { get; }
}

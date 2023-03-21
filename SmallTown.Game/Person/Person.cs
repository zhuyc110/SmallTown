using SmallTown.Game.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person;
public class Person
{
    public int Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public int Sex { get; init; }

    public int Age { get; init; }

    public bool Alive { get; init; }

    public Personality Personality { get; init; }

    public ValueInstance<Property> Properties { get; init; }

    public Role Role { get; init; }
}

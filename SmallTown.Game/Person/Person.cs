﻿using SmallTown.Game.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person;
public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Sex Sex { get; set; }

    public int Age { get; set; }

    public bool Alive { get; set; }

    public Personality Personality { get; set; }

    public IReadOnlyCollection<ValueInstance<Property>> Properties { get; set; }

    public Role Role { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName}, {Sex}, {Age}, {Personality}";
    }
}

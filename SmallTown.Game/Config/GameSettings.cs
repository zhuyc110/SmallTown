using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Config;
public class GameSettings
{
    public PeopleSettings People { get; set; }
}

public class PeopleSettings
{
    public int SexRate { get; set; }
}
using SmallTown.Engine.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person;
public interface IRoleManager : IInitializable
{
    Role Get(int id);
}

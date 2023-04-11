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
    string GetFirstName(int random, int age, Sex sex);
    string GetLastName(float random);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Engine.Function;

public interface IPrioritizedInitializable : IInitializable
{
    int Priority { get; }
}

using SmallTown.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Engine.Infrastructure;
public static class EnumerableExtensions
{
    public static T Choice<T>(this IEnumerable<T> collection)
    {
        var index = SmallRandom.NextNonNegative(collection.Count());
        return collection.ElementAt(index);
    }
}

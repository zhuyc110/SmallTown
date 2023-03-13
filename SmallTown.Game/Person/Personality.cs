using Newtonsoft.Json;
using SmallTown.Game.Shared;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person
{
    public class Personality
    {
        private static IReadOnlyDictionary<int, string> _elements = new Dictionary<int, string>();

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        internal IReadOnlyCollection<string> HighElements
        {
            get
            {
                return _highElementIds.Select(x => _elements[x]).ToList();
            }
        }

        private readonly int[] _highElementIds;

        public Personality(int id, string name, string description, int[] highElements)
        {
            Id = id;
            Name = name;
            Description = description;
            _highElementIds = highElements;
        }

        public static void InitElements(IEnumerable<IdValuePair<int, string>> elements)
        {
            _elements = elements.ToDictionary(x => x.Id, x => x.Value);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

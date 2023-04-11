using SmallTown.Game.Shared;

namespace SmallTown.Game.Person
{
    public class Personality : ReadableObjectBase
    {
        private static IReadOnlyDictionary<int, string>? _elements;

        internal IReadOnlyCollection<string> HighElements
        {
            get
            {
                return _highElementIds.Select(x => _elements![x]).ToList();
            }
        }

        internal IReadOnlyCollection<int> HighElementIds => _highElementIds;

        private readonly int[] _highElementIds;

        public Personality(int id, string name, string description, int[] highElements)
            : base(id, name, description)
        {
            _highElementIds = highElements;
        }

        public static void InitElements(IEnumerable<IdValuePair<int, string>> elements)
        {
            _elements = elements.ToDictionary(x => x.Id, x => x.Value);
        }
    }
}

using Microsoft.Extensions.Options;
using SmallTown.Engine.Core;
using SmallTown.Game.Config;

namespace SmallTown.Game.Person;
public class PersonGenerator
{
    private readonly IList<Person> _people;
    private readonly GameSettings _gameSettings;
    private readonly IRandom _random;
    private int[] _randomes = Array.Empty<int>();
    private bool _started = false;

    public PersonGenerator(IOptions<GameSettings> gameSettings, IRandom random)
    {
        _people = new List<Person>();
        _gameSettings = gameSettings.Value;
        _random = random;
    }

    public PersonGenerator Start(int count)
    {
        _started = true;
        for (var index = 0; index < count; index++)
        {
            _people.Add(new Person
            {
                Id = index
            });
        }
        _randomes = _random.Get(count).ToArray();

        return this;
    }

    public PersonGenerator ConfigLastName()
    {
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];

        }

        return this;
    }

    public PersonGenerator ConfigSex()
    {
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            person.Sex = _randomes[index] > _gameSettings.People.SexRate ? Sex.Female : Sex.Male;
        }

        return this;
    }

    public PersonGenerator ConfigAge()
    {
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            var rangeKey = _randomes[index] / 100f;
            var rate = _gameSettings.People.AgeTable.OrderBy(x => x.Value - rangeKey).First(x => x.Value - rangeKey >= 0);
            person.Age = rate.Key + _random.Next() / 10;
        }

        return this;
    }

    public IEnumerable<Person> Build()
    {
        _randomes = Array.Empty<int>();
        _started = false;
        return _people;
    }

    private void CheckStarted()
    {
        if (!_started)
        {
            throw new InvalidOperationException("Not started.");
        }
    }
}

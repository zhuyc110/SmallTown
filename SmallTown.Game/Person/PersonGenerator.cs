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

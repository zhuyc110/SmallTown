using Microsoft.Extensions.Options;
using SmallTown.Engine.Core;
using SmallTown.Engine.Function;
using SmallTown.Engine.Infrastructure;
using SmallTown.Game.Config;
using SmallTown.Game.Person.Name;
using System.Collections.Immutable;

namespace SmallTown.Game.Person;
public class PersonGenerator : IPrioritizedInitializable
{
    private readonly List<Person> _people;
    private readonly GameSettings _gameSettings;
    private readonly IRandom _random;
    private readonly INameManager _nameManager;
    private int[] _randomes = Array.Empty<int>();
    private bool _started = false;

    public int Priority { get => 0; }

    public PersonGenerator(IOptions<GameSettings> gameSettings, IRandom random, INameManager nameManager)
    {
        _people = new List<Person>();
        _gameSettings = gameSettings.Value;
        _random = random;
        _nameManager = nameManager;
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

    public PersonGenerator ConfigFirstName()
    {
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            person.FirstName = _nameManager.GetFirstName(_randomes.Choice(), person.Age, person.Sex);
        }

        return this;
    }

    public PersonGenerator ConfigSex()
    {
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            person.Sex = _randomes.Choice() > _gameSettings.People.SexRate ? Sex.Female : Sex.Male;
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
            person.Age = rate.Key + _randomes[index] % 10;
        }

        return this;
    }

    public IEnumerable<Person> Build()
    {
        _people.Sort((x, y) => x.Age - y.Age);
        _randomes = Array.Empty<int>();
        _started = false;
        return _people;
    }

    public Task StartAsync()
    {
        Start(1000).ConfigAge().ConfigSex().ConfigFirstName().Build();

        return Task.CompletedTask;
    }
}

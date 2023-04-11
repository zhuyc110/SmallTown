using Microsoft.Extensions.Options;
using SmallTown.Engine.Core;
using SmallTown.Engine.Function;
using SmallTown.Engine.Infrastructure;
using SmallTown.Game.Config;
using SmallTown.Game.Person.Name;
using System;
using System.Collections.Immutable;

namespace SmallTown.Game.Person;
public class PersonGenerator : IPrioritizedInitializable
{
    private const int EDGE_CASE = 95;

    private readonly List<Person> _people;
    private readonly GameSettings _gameSettings;
    private readonly IRandom _random;
    private readonly INameManager _nameManager;
    private readonly IPersonalityManager _personalityManager;
    private bool _started = false;

    public int Priority { get => 0; }

    public PersonGenerator(IOptions<GameSettings> gameSettings, IRandom random, INameManager nameManager, IPersonalityManager personalityManager)
    {
        _people = new List<Person>();
        _gameSettings = gameSettings.Value;
        _random = random;
        _nameManager = nameManager;
        _personalityManager = personalityManager;
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

        return this;
    }

    public PersonGenerator ConfigAge()
    {
        var randomes = _random.Get(_people.Count).ToArray();

        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            var rangeKey = randomes[index] / 100f;
            var rate = _gameSettings.People.AgeTable.OrderBy(x => x.Value - rangeKey).First(x => x.Value - rangeKey >= 0);
            person.Age = rate.Key + randomes[index] % 10;
        }

        return this;
    }

    public PersonGenerator ConfigSex()
    {
        var randomes = _random.Get(_people.Count).ToArray();
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            person.Sex = randomes[index] > _gameSettings.People.SexRate ? Sex.Female : Sex.Male;
        }

        return this;
    }

    public PersonGenerator ConfigLastName()
    {
        var randomes = _random.GetFloat(_people.Count).ToArray();
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];

            if (randomes[index] < EDGE_CASE)
            {
                var target = _nameManager.LastNameRateTable.Where(x => x.Key < randomes[index]).MaxBy(x => x.Key);
                person.LastName = target.Value;
            }
            else
            {
                person.LastName = _nameManager.ExtendedLastName.Choice();
            }
        }

        return this;
    }

    public PersonGenerator ConfigFirstName()
    {
        var randomes = _random.Get(_people.Count).ToArray();
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];

            var range = person.Age / 10 * 10;
            if (_nameManager.FirstNameRateTable.TryGetValue((range, person.Sex), out var firstNames) && randomes[index] < EDGE_CASE)
            {
                person.FirstName = firstNames.Choice();
            }
            else
            {
                var extendedNames = _nameManager.ExtendedFirstNameTable[person.Sex];
                person.FirstName = extendedNames.Choice();
            }
        }

        return this;
    }

    public PersonGenerator ConfigPersonality()
    {
        for (var index = 0; index < _people.Count; index++)
        {
            var person = _people[index];
            person.Personality = _personalityManager.Personalities.Choice();
        }

        return this;
    }

    public IEnumerable<Person> Build()
    {
        _people.Sort((x, y) => x.Age - y.Age);
        _started = false;
        return _people;
    }

    public Task StartAsync()
    {
        Start(100).ConfigAge().ConfigSex().ConfigLastName().ConfigFirstName().ConfigPersonality().Build();

        return Task.CompletedTask;
    }
}

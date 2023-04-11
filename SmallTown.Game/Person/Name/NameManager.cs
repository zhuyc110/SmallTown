using SmallTown.Engine.Core;
using SmallTown.Engine.Function;
using SmallTown.Engine.Infrastructure;
using SmallTown.Engine.Resource;
using SmallTown.Game.Shared;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person.Name;
public class NameManager : DataReadingManagerBase, INameManager
{
    private const int EDGE_CASE = 95;
    private const int EXTENDED_VALUE = 100;
    private IDictionary<float, string> _lastNameRateTable = new Dictionary<float, string>();
    private ICollection<string> _extendedLastName = new List<string>();
    private IDictionary<(int, Sex), string[]> _firstNameRateTable = new Dictionary<(int, Sex), string[]>();
    private IDictionary<Sex, string[]> _extendedFirstNameTable = new Dictionary<Sex, string[]>();

    public NameManager(IAssetManager assetManager, ILanguageService languageService)
        : base(assetManager, languageService)
    {
    }

    public string GetFirstName(int random, int age, Sex sex)
    {
        var range = age / 10 * 10;
        if (_firstNameRateTable.TryGetValue((range, sex), out var firstNames) && random < EDGE_CASE)
        {
            return firstNames.Choice();
        }

        var extendedNames = _extendedFirstNameTable[sex];
        return extendedNames.Choice();
    }

    public string GetLastName(float random)
    {
        if (random < EDGE_CASE)
        {
            var target = _lastNameRateTable.Where(x => x.Key < random).MaxBy(x => x.Key);
            return target.Value;
        }

        return _extendedLastName.Choice();
    }

    public async override Task StartAsync()
    {
        var filePath = $"./Data/People/LastName/{_languageService.CurrentLanguage}.json";
        var lastNameRateTable = await _assetManager.LoadAndDeserialize<IdValuePair<float, string>[]>(filePath);
        _lastNameRateTable = lastNameRateTable!.Where(x => x.Id != EXTENDED_VALUE).ToDictionary(x => x.Id, x => x.Value);
        _extendedLastName = lastNameRateTable!.Where(x => x.Id == EXTENDED_VALUE).Single().Value.Split(' ');

        filePath = $"./Data/People/FirstName/{_languageService.CurrentLanguage}.json";
        var firstNameRateTable = await _assetManager.LoadAndDeserialize<FirstName[]>(filePath);
        _firstNameRateTable = firstNameRateTable!.Where(x => x.Age != EXTENDED_VALUE).ToDictionary(x => (x.Age, x.Sex), x => x.Values);
        _extendedFirstNameTable = firstNameRateTable!.Where(x => x.Age == EXTENDED_VALUE).ToDictionary(x => x.Sex, x => x.Values);
    }
}

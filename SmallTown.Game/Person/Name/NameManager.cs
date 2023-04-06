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
    private const int EXTENDED_VALUE = 100;
    private readonly IRandom _random;
    private IDictionary<float, string> _lastNameRateTable = new Dictionary<float, string>();
    private IDictionary<(int, Sex), string[]> _firstNameRateTable = new Dictionary<(int, Sex), string[]>();
    private IDictionary<Sex, string[]> _extendedFirstNameTable = new Dictionary<Sex, string[]>();

    public NameManager(IAssetManager assetManager, ILanguageService languageService, IRandom random)
        : base(assetManager, languageService)
    {
        _random = random;
    }

    public string GetFirstName(int random, int age, Sex sex)
    {
        var range = age / 10 * 10;
        if (_firstNameRateTable.TryGetValue((range, sex), out var firstNames) && random < 95)
        {
            return firstNames.Choice();
        }

        var extendedNames = _extendedFirstNameTable[sex];
        return extendedNames.Choice();
    }

    public async override Task StartAsync()
    {
        var filePath = $"./Data/People/LastName/{_languageService.CurrentLanguage}.json";
        var lastNameRateTable = await _assetManager.LoadAndDeserialize<IdValuePair<float, string>[]>(filePath);
        _lastNameRateTable = lastNameRateTable!.ToDictionary(x => x.Id, x => x.Value);

        filePath = $"./Data/People/FirstName/{_languageService.CurrentLanguage}.json";
        var firstNameRateTable = await _assetManager.LoadAndDeserialize<FirstName[]>(filePath);
        _firstNameRateTable = firstNameRateTable!.Where(x => x.Age != EXTENDED_VALUE).ToDictionary(x => (x.Age, x.Sex), x => x.Values);
        _extendedFirstNameTable = firstNameRateTable!.Where(x => x.Age == EXTENDED_VALUE).ToDictionary(x => x.Sex, x => x.Values);
    }
}

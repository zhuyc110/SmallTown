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

    private IReadOnlyDictionary<float, string> _lastNameRateTable = new Dictionary<float, string>();
    private IReadOnlyCollection<string> _extendedLastName = new List<string>();
    private IReadOnlyDictionary<(int, Sex), string[]> _firstNameRateTable = new Dictionary<(int, Sex), string[]>();
    private IReadOnlyDictionary<Sex, string[]> _extendedFirstNameTable = new Dictionary<Sex, string[]>();

    public IReadOnlyDictionary<float, string> LastNameRateTable => _lastNameRateTable;
    public IReadOnlyCollection<string> ExtendedLastName => _extendedLastName;
    public IReadOnlyDictionary<(int, Sex), string[]> FirstNameRateTable => _firstNameRateTable;
    public IReadOnlyDictionary<Sex, string[]> ExtendedFirstNameTable => _extendedFirstNameTable;

    public NameManager(IAssetManager assetManager, ILanguageService languageService)
        : base(assetManager, languageService)
    {
    }

    public async override Task StartAsync()
    {
        var filePath = $"./Data/People/LastName/{_languageService.CurrentLanguage}.json";
        var lastNameRateTable = await _assetManager.LoadAndDeserialize<IdValuePair<float, string>[]>(filePath);
        _lastNameRateTable = lastNameRateTable!.Where(x => x.Id != EXTENDED_VALUE).ToDictionary(x => x.Id, x => x.Value);
        _extendedLastName = lastNameRateTable!.Where(x => x.Id == EXTENDED_VALUE).Single().Value.Split(' ');

        filePath = $"./Data/People/FirstName/{_languageService.CurrentLanguage}.json";
        var firstNameRateTable = await _assetManager.LoadAndDeserialize<FirstNameValues[]>(filePath);
        _firstNameRateTable = firstNameRateTable!.Where(x => x.Age != EXTENDED_VALUE).ToDictionary(x => (x.Age, x.Sex), x => x.Values);
        _extendedFirstNameTable = firstNameRateTable!.Where(x => x.Age == EXTENDED_VALUE).ToDictionary(x => x.Sex, x => x.Values);
    }
}

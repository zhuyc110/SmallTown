using SmallTown.Engine.Resource;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person
{
    public class PersonalityManager
    {
        private static IList<Personality> Personalities = new List<Personality>();

        private readonly IAssetManager _assetManager;
        private readonly ILanguageService _languageService;

        public PersonalityManager(IAssetManager assetManager, ILanguageService languageService)
        {
            _assetManager = assetManager;
            _languageService = languageService;
        }

        public async Task InitializeAsync()
        {
            if (Personalities.Count > 0)
            {
                return;
            }

            var filePath = $"./Data/Personality/{_languageService.CurrentLanguage}.json";
            var jsonData = await _assetManager.LoadAndDeserialize<Personality[]>(filePath);

            if (jsonData != null)
            {
                Personalities = jsonData.OrderBy(x => x.Id).ToList();
            }
        }

        public static Personality Get(int id)
        {
            if (id <= 0 || Personalities.Count < id)
            {
                return Personalities.First();
            }

            if (Personalities[id - 1].Id != id)
            {
                return Personalities.First();
            }

            return Personalities[id - 1];
        }
    }
}

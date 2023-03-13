using SmallTown.Engine.Function;
using SmallTown.Engine.Resource;
using SmallTown.Function.Framework.GameObject;
using SmallTown.Game.Shared;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person
{
    public class PersonalityManager : IInitializable
    {
        private static IList<Personality> Personalities = new List<Personality>();

        private readonly IAssetManager _assetManager;
        private readonly ILanguageService _languageService;

        public PersonalityManager(IAssetManager assetManager, ILanguageService languageService)
        {
            _assetManager = assetManager;
            _languageService = languageService;
        }

        public async Task StartAsync()
        {
            if (Personalities.Count > 0)
            {
                return;
            }

            var elementFilePath = $"./Data/Personality/Element/{_languageService.CurrentLanguage}.json";
            var elements = await _assetManager.LoadAndDeserialize<IdValuePair<int, string>[]>(elementFilePath);
            Personality.InitElements(elements!);

            var personalityFilePath = $"./Data/Personality/{_languageService.CurrentLanguage}.json";
            var personalities = await _assetManager.LoadAndDeserialize<Personality[]>(personalityFilePath);

            if (personalities != null)
            {
                Personalities = personalities.OrderBy(x => x.Id).ToList();
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

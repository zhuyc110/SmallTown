using SmallTown.Engine.Resource;
using SmallTown.Game.Shared;
using SmallTown.Resource;

namespace SmallTown.Game.Person
{
    public class PersonalityManager : ReadableObjectManagerBase<Personality>
    {
        public PersonalityManager(IAssetManager assetManager, ILanguageService languageService)
            : base(assetManager, languageService)
        {
        }

        protected override string ReadableObjectKey => nameof(Personality);

        public override async Task StartAsync()
        {
            if (ReadableObjects.Count > 0)
            {
                return;
            }

            var elementFilePath = $"./Data/Personality/Element/{_languageService.CurrentLanguage}.json";
            var elements = await _assetManager.LoadAndDeserialize<IdValuePair<int, string>[]>(elementFilePath);
            Personality.InitElements(elements!);

            await base.StartAsync();
        }
    }
}

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

        public PersonalityManager(IAssetManager assetManager)
        {
            _assetManager = assetManager;
        }

        public async Task InitializeAsync(string filePath)
        {
            if (Personalities.Count > 0)
            {
                return;
            }

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

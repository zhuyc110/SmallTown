using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO.Abstractions;

namespace SmallTown.Resource
{
    public class AssetManager : IAssetManager
    {
        private readonly IFile _file;

        public AssetManager(IFileSystem fileSystem)
        {
            _file = fileSystem.File;
        }

        public async Task<JObject?> Load(string path)
        {
            if (!_file.Exists(path))
            {
                return default;
            }

            var jsonString = await _file.ReadAllTextAsync(path);

            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default;
            }

            using var stringReader = new StringReader(jsonString);
            await using var reader = new JsonTextReader(stringReader);
            return await JObject.LoadAsync(reader);
        }

        public async Task<T?> LoadAndDeserialize<T>(string path) where T : class
        {
            if (!_file.Exists(path))
            {
                return default;
            }

            var jsonString = await _file.ReadAllTextAsync(path);

            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
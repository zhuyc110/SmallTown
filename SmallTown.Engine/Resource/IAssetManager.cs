using Newtonsoft.Json.Linq;

namespace SmallTown.Resource
{
    public interface IAssetManager
    {
        Task<JObject?> Load(string path);
        Task<T?> LoadAndDeserialize<T>(string path) where T : class;
    }
}
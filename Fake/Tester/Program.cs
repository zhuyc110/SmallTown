using SmallTown.Game.Person;
using SmallTown.Resource;
using System.IO.Abstractions;

namespace Tester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var assetManager = new AssetManager(new FileSystem());
            var personalityManager = new PersonalityManager(assetManager);
            await personalityManager.InitializeAsync("./Data/Personality/zh-cn.json");
            Console.WriteLine(PersonalityManager.Get(1));

            Console.ReadLine();
        }
    }
}
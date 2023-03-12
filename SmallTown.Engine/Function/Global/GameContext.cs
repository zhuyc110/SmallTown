using SmallTown.Function.Physics;
using SmallTown.Resource;

namespace SmallTown.Function.Global
{
    public class GameContext
    {
        public IPhysicsScene PhysicsScene { get; internal init; }

        public IAssetManager AssetManager { get; internal init; }

        public static GameContext Context
        {
            get;
            internal set;
        }
    }
}
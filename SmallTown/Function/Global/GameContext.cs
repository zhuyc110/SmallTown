using SmallTown.Function.Physics;

namespace SmallTown.Function.Global
{
    public class GameContext
    {
        public IPhysicsScene PhysicsScene { get; internal init; }

        public static GameContext Context
        {
            get;
            internal set;
        }
    }
}
using SmallTown.Function.Framework.GameObject;

namespace SmallTown.Function.Framework.Component.RigidBody
{
    public class RigidBodyComponent : ComponentBase
    {
        public RigidBodyComponent(IGameObject parent) :base(parent)
        {

        }

        public override Task UpdateAsync()
        {
            return Task.CompletedTask;
        }
    }
}

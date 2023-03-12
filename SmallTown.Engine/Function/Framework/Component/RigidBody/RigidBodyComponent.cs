using SmallTown.Function.Framework.GameObject;
using SmallTown.Function.Global;
using SmallTown.Infrastructure;
using System.Numerics;

namespace SmallTown.Function.Framework.Component.RigidBody
{
    public class RigidBodyComponent : ComponentBase
    {
        public RigidBodyComponent(IGameObject parent) : base(parent)
        {

        }

        public override Task UpdateAsync()
        {
            return Task.CompletedTask;
        }

        public void UpdateGlobalTransform(Matrix3x2 transform, bool dirty)
        {
            if (dirty)
            {
                Remove();

                Create(transform);
            }
        }

        private void Remove()
        {
            GameContext.Context.PhysicsScene.RemoveRigidBody(Id);
        }

        private void Create(Matrix3x2 transform)
        {
            Id = GameContext.Context.PhysicsScene.CreateRigidBody(transform.GetDimension(0));
        }
    }
}

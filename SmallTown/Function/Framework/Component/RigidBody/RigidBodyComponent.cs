using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

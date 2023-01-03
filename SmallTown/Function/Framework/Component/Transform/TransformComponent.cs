using SmallTown.Function.Framework.Component.RigidBody;
using SmallTown.Function.Framework.GameObject;
using System.Numerics;

namespace SmallTown.Function.Framework.Component.Transform
{
    public class TransformComponent : ComponentBase
    {
        private bool _dirty;
        private Vector2 _location;
        private Vector2 _scale;

        public TransformComponent(IGameObject parent, Vector2 location, Vector2? scale) : base(parent)
        {
            Location = location;
            Scale = scale ?? Vector2.One;
        }

        public Vector2 Location
        {
            get => _location;
            set
            {
                _location = value;
                _dirty = true;
            }
        }

        public Vector2 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                _dirty = true;
            }
        }

        public Matrix3x2 TransformMatrix => new Matrix3x2(Location.X, Location.Y, Location.X * Scale.X, Location.Y * Scale.Y, Scale.X, Scale.Y);

        public override Task UpdateAsync()
        {
            if (_dirty)
            {
                UpdateRigidBodyComponent();
            }

            return Task.CompletedTask;
        }

        private void UpdateRigidBodyComponent()
        {
            var rigidBody = Parent.GetComponent<RigidBodyComponent>();
            if (rigidBody != null)
            {
                rigidBody.UpdateGlobalTransform(TransformMatrix, _dirty);
                _dirty = false;
            }
        }
    }
}
using System.Collections.Concurrent;
using System.Numerics;

namespace SmallTown.Function.Physics
{
    public class PhysicsScene : IPhysicsScene, IUpdatable
    {
        private readonly ICollection<Guid> _pendingRemoveBodies = new List<Guid>();
        private readonly IDictionary<Guid, IRigidBody> _bodies = new ConcurrentDictionary<Guid, IRigidBody>();

        public Guid CreateRigidBody(Vector2 position)
        {
            var rigidBody = RigidBody.Create(position, Vector2.Zero);
            _bodies.TryAdd(rigidBody.Id, rigidBody);
            return rigidBody.Id;
        }

        public void RemoveRigidBody(Guid id)
        {
            _pendingRemoveBodies.Add(id);
        }

        public async Task UpdateAsync()
        {
            foreach (var pendingRemoveBody in _pendingRemoveBodies)
            {
                _bodies.Remove(pendingRemoveBody);
            }

            _pendingRemoveBodies.Clear();

            await Task.CompletedTask;
        }
    }
}
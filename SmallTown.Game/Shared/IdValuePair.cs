using System.ComponentModel;
using System.Diagnostics;

namespace SmallTown.Game.Shared
{
    public readonly struct IdValuePair<TId, TValue>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TId _id;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TValue _value;

        public IdValuePair(TId id, TValue value)
        {
            _id = id;
            _value = value;
        }

        public TId Id => _id;

        public TValue Value => _value;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out TId id, out TValue value)
        {
            id = Id;
            value = Value;
        }

        public override string ToString()
        {
            return $"{Id}: {Value}";
        }
    }
}

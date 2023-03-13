using System.ComponentModel;
using System.Diagnostics;

namespace SmallTown.Game.Shared
{
    public readonly struct IdValuePair<TKey, TValue>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TKey _id;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TValue _value;

        public IdValuePair(TKey id, TValue value)
        {
            _id = id;
            _value = value;
        }

        public TKey Id => _id;

        public TValue Value => _value;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out TKey key, out TValue value)
        {
            key = Id;
            value = Value;
        }

        public override string ToString()
        {
            return $"{Id}: {Value}";
        }
    }
}

//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// A terminal atomic
    /// </summary>
    public readonly struct Atom<K> : ISymbol<Atom<K>,K>, ITerminalExpr<K>
        where K : unmanaged
    {
        public uint Key {get;}

        public K Value {get;}

        [MethodImpl(Inline)]
        public Atom(uint key, K value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]

        public bool Equals(Atom<K> src)
            => Key == src.Key && bw64(Value).Equals(bw64(src.Value));

        [MethodImpl(Inline)]
        public int CompareTo(Atom<K> src)
            => bw64(Value).CompareTo(bw64(src.Value));

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Key;

        public override bool Equals(object src)
            => src is Atom<K> s && Equals(s);

        [MethodImpl(Inline)]
        public static bool operator ==(Atom<K> a, Atom<K> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Atom<K> a, Atom<K> b)
            => !a.Equals(b);

        public static Atom<K> Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator K(Atom<K> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Atom<K>((uint key, K value) src)
            => new Atom<K>(src.key, src.value);
    }
}
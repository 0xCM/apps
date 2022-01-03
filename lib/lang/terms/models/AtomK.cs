//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// A terminal atomic
    /// </summary>
    public readonly struct Atom<K> : IAtom<K>
    {
        public K Value {get;}

        [MethodImpl(Inline)]
        public Atom(K value)
        {
            Value = value;
        }
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public static Atom<K> Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator K(Atom<K> src)
            => src.Value;
   }
}
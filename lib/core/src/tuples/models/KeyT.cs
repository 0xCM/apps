//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Key<T> : ITextual, IHashed
        where T : unmanaged
    {
        public T Value {get;}

        public uint Hash {get;}

        [MethodImpl(Inline)]
        public Key(T src)
        {
            Value = src;
            Hash = alg.hash.calc(src);
        }

        [MethodImpl(Inline)]
        public Key(T src, uint hash)
        {
            Value = src;
            Hash = hash;
        }

        public override int GetHashCode()
            => (int)Hash;
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Key<T>(T src)
            => new Key<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Key<T> src)
            => src.Value;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Hashed
    {
        public readonly record struct Hash<T> : IHashCode<T,T>
            where T : unmanaged, IEquatable<T>
        {
            public readonly T Code;

            [MethodImpl(Inline)]
            public Hash(T src)
            {
                Code = src;
            }

            T IHashCode<T>.Value
                => Code;

            T IHashCode<T,T>.Primitive
                => Code;

            [MethodImpl(Inline)]
            public static implicit operator Hash<T>(Hash32<T> src)
                => new Hash<T>(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator Hash<T>(Hash8<T> src)
                => new Hash<T>(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator Hash<T>(Hash64<T> src)
                => new Hash<T>(src.Value);

        }
    }
}
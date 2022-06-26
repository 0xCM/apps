//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Hashed
    {
        public readonly record struct Hash<T>
            where T : unmanaged, IEquatable<T>
        {
            public readonly T Value;

            [MethodImpl(Inline)]
            public Hash(T src)
            {
                Value = src;
            }

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
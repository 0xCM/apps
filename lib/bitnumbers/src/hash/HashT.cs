//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Hash<T>
        where T : unmanaged, IHashCode<T,T>
    {
        T HashCode {get;}

        [MethodImpl(Inline)]
        public Hash(T src)
        {
            HashCode = src;
        }

        public T Value
        {
            [MethodImpl(Inline)]
            get => HashCode.Value;
        }

        [MethodImpl(Inline)]
        public static implicit operator Hash<T>(T src)
            => new Hash<T>(src);
    }
}
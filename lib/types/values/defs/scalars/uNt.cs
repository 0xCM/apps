//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct uN<T> : IUnsignedInteger<T>
        where T : unmanaged
    {
        public uint N;

        public T Storage;

        [MethodImpl(Inline)]
        public uN(uint n, T src)
        {
            N = n;
            Storage = src;
        }

        [MethodImpl(Inline)]
        public uN(uint n)
        {
            N = n;
            Storage = default;
        }

        public Identifier TypeName
            => string.Format("u{0}",N);

        BitWidth ISizedValue.ContentWidth
            => N;

        [MethodImpl(Inline)]
        public static implicit operator uN<T>(uint n)
            => new uN<T>(n);
    }
}
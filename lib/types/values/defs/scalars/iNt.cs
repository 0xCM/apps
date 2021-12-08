//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct iN<T> : ISignedValue<T>
        where T : unmanaged
    {
        public uint N;

        public T Storage;

        [MethodImpl(Inline)]
        public iN(uint n, T src)
        {
            N = n;
            Storage = src;
        }

        [MethodImpl(Inline)]
        public iN(uint n)
        {
            N = n;
            Storage = default;
        }

        public Identifier TypeName
            => string.Format("i{0}",N);

        BitWidth ISizedValue.ContentWidth
            => N;

        [MethodImpl(Inline)]
        public static implicit operator iN<T>(uint n)
            => new iN<T>(n);
    }
}
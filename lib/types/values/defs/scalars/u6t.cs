//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u6<T> : IUnsignedInteger<T>
        where T : unmanaged
    {
        public const uint Width = 6;

        public T Storage;

        [MethodImpl(Inline)]
        public u6(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
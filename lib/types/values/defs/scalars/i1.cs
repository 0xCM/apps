//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct i1<T> : ISignedValue<T>
        where T : unmanaged
    {
        public const uint Width = 1;

        public T Storage;

        [MethodImpl(Inline)]
        public i1(T src)
        {
            Storage = src;
        }

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
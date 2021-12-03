//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct i1<T> : ISigned<T>
        where T : unmanaged
    {
        public const uint Width = 1;

        public T Storage;

        [MethodImpl(Inline)]
        public i1(T src)
        {
            Storage = src;
        }

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
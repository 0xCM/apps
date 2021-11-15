//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct i1<T> : ISigned<T>
        where T : unmanaged
    {
        public static ByteSize SZ => size<i1<T>>();

        public const ulong Width = 1;

        public T Storage;

        [MethodImpl(Inline)]
        public i1(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}
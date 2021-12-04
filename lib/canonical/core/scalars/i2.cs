//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;
    using static Root;

    public struct i2<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 2;

        [MethodImpl(Inline)]
        public i2(T src)
        {
            Storage = src;
        }

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    public struct i16<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 16;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
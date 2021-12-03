//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    public struct i4<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 4;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
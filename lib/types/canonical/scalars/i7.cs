//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    public struct i7<T> : ISigned<T>
        where T : unmanaged
    {
        public const uint Width = 7;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
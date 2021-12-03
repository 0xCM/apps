//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct i3<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 3;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
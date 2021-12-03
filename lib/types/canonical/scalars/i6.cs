//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct i6<T> : ISigned<T>
        where T : unmanaged
    {
        public const uint Width = 6;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
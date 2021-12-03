//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct i256<T> : ISigned<T>
        where T : unmanaged
    {
        public const uint Width = 256;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
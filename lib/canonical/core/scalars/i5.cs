//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i5<T> : ISigned<T>
        where T : unmanaged
    {
        public const uint Width = 5;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct i7<T> : ISigned<T>
        where T : unmanaged
    {
        public const uint Width = 7;

        public T Storage;

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}
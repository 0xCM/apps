//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ValueTypes
{
    public struct i64<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 64;

        public T Storage;

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}
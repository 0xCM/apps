//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct i128<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 128;

        public T Storage;

        BitWidth IValue.ContentWidth
            => Width;
    }
}
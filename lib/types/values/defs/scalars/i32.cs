//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i32<T> : ISignedValue<T>
        where T : unmanaged
    {
        public const uint Width = 32;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
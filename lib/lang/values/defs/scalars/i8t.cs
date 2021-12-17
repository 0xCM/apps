//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i8<T> : ISignedInteger<T>
        where T : unmanaged
    {
        public const uint Width = 8;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
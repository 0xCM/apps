//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i7<T> : ISignedInteger<T>
        where T : unmanaged
    {
        public const uint Width = 7;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
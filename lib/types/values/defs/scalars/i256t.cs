//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i256<T> : ISignedInteger<T>
        where T : unmanaged
    {
        public const uint Width = 256;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i512<T> : ISignedValue<T>
        where T : unmanaged
    {
        public const uint Width = 512;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i3<T> : ISignedInteger<T>
        where T : unmanaged
    {
        public const ulong Width = 3;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
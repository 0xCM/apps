//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i0<T> : ISignedInteger<T>
        where T : unmanaged
    {
        public const ulong Width = 0;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
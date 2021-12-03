//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    public struct i0<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 0;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
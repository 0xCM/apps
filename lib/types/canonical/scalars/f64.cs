//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    public struct f64<T> : IFloat<T>
        where T : unmanaged
    {
        public const ulong Width = 64;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}
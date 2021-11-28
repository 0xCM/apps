//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct f32<T> : IFloat<T>
        where T : unmanaged
    {
        public const ulong Width = 32;

        public T Storage;

        BitWidth IValue.ContentWidth
            => Width;
    }
}
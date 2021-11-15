//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i256<T> : ISigned<T>
        where T : unmanaged
    {
        public const ulong Width = 256;

        public T Storage;

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    public struct i64<T> : ISignedInteger<T>
        where T : unmanaged
    {
        public const uint Width = 64;

        public T Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
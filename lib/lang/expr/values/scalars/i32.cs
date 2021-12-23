//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    public struct i32 : ISignedInteger<int>
    {
        public const uint Width = 32;

        public int Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
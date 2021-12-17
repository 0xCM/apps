//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i8 : ISignedInteger<sbyte>
    {
        public const uint Width = 8;

        public sbyte Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
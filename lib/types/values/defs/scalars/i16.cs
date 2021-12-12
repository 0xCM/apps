//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i16 : ISignedInteger<short>
    {
        public const uint Width = 16;

        public short Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
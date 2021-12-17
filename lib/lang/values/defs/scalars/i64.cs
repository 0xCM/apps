//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public struct i64 : ISignedInteger<long>
    {
        public const uint Width = 64;

        public long Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}
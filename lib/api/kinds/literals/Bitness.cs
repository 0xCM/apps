//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource]
    public enum Bitness : byte
    {
        None = 0,

        [Symbol("b16")]
        b16 = 16,

        [Symbol("b32")]
        b32 = 32,

        [Symbol("b64")]
        b64 = 64
    }
}
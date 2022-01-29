//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public readonly partial struct asm
    {
        const NumericKind Closure = UnsignedInts;

        static ReadOnlySpan<byte> OperandSizes
            => new byte[8]{1,1,0,0,2,2,2,2};

        static ReadOnlySpan<byte> AddressSizes
            => new byte[8]{2,1,2,1,2,1,2,1};
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct HexVector
    {
        public static uint bitstring<N>(HexVector8<N> src, uint i, Span<char> dst, N count = default)
            where N : unmanaged, ITypeNat
                => BitRender.render8x8(src.Bytes, i, dst, count);
    }
}
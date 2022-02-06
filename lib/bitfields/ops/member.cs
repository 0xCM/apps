//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        // public static BitfieldMember member(NativeSize size, BitfieldSegModel src)
        //     => new BitfieldMember(src.SegName, src.MinIndex, src.MaxIndex, src.Mask);

        // public static Index<BitfieldMember> members(BitfieldPattern src)
        //     => src.Segments.Select(s => member(src.MinSize, s));
    }
}
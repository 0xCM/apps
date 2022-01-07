//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using static BitPatternInfo;

    partial struct Bitfields
    {
        public static BitfieldMember member(NativeSize size, Segment src)
            => new BitfieldMember(text.ifempty(src.Identifier, src.Indicator), src.MinIndex, src.MaxIndex, src.Mask);

        public static Index<BitfieldMember> members(BitPatternInfo src, Index<Identifier> identifiers)
            => BitPatterns.segments(src.Pattern,identifiers).Select(s => member(src.MinSize, s));

        public static Index<BitfieldMember> members(BitPatternInfo src)
            => src.Segments.Select(s => member(src.MinSize, s));
    }
}
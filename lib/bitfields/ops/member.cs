//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitfieldPatterns;

    partial struct Bitfields
    {
        public static BitfieldMember member(NativeSize size, PatternSegment src)
            => new BitfieldMember(text.ifempty(src.Identifier, src.Indicator), src.MinIndex, src.MaxIndex, src.Mask);

        public static Index<BitfieldMember> members(PatternInfo src, Index<Identifier> identifiers)
            => BitfieldPatterns.segments(src.Pattern,identifiers).Select(s => member(src.MinSize, s));

        public static Index<BitfieldMember> members(PatternInfo src)
            => src.Segments.Select(s => member(src.MinSize, s));
    }
}
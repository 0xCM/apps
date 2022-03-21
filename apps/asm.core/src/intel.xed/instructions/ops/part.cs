//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using R = XedRules;

    partial class XedPatterns
    {
        [MethodImpl(Inline)]
        public static InstDefPart part(FieldConstraint src)
            => new InstDefPart(src);

        [MethodImpl(Inline)]
        public static InstDefPart part(BitfieldSeg src)
            => new InstDefPart(src);

        [MethodImpl(Inline)]
        public static InstDefPart part(FieldAssign src)
            => new InstDefPart(src);

        [MethodImpl(Inline)]
        public static InstDefPart part(Nonterminal src)
            => new InstDefPart(src);

        [MethodImpl(Inline)]
        public static InstDefPart part(R.FieldValue src)
            => new InstDefPart(src);

        [MethodImpl(Inline)]
        public static InstDefPart part(Hex8 src)
            => new InstDefPart(src);

        [MethodImpl(Inline)]
        public static InstDefPart part(uint5 src)
            => new InstDefPart(src);

    }
}
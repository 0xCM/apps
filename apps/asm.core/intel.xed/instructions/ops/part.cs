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
        public static InstDefField part(FieldConstraint src)
            => new InstDefField(src);

        [MethodImpl(Inline)]
        public static InstDefField part(BitfieldSeg src)
            => new InstDefField(src);

        [MethodImpl(Inline)]
        public static InstDefField part(FieldAssign src)
            => new InstDefField(src);

        [MethodImpl(Inline)]
        public static InstDefField part(Nonterminal src)
            => new InstDefField(src);

        [MethodImpl(Inline)]
        public static InstDefField part(R.FieldValue src)
            => new InstDefField(src);

        [MethodImpl(Inline)]
        public static InstDefField part(Hex8 src)
            => new InstDefField(src);

        [MethodImpl(Inline)]
        public static InstDefField part(uint5 src)
            => new InstDefField(src);
    }
}
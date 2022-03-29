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
    using static XedFields;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static InstDefPart part(FieldConstraint src)
            => new(src.Expression());

        [MethodImpl(Inline), Op]
        public static InstDefPart part(BitfieldSeg src)
            => new(src);

        [MethodImpl(Inline), Op]
        public static InstDefPart part(FieldAssign src)
            => new(src.Expression());

        [MethodImpl(Inline), Op]
        public static InstDefPart part(Nonterminal src)
            => new(src);

        [MethodImpl(Inline), Op]
        public static InstDefPart part(FieldExpr src)
            => new(src);

        [MethodImpl(Inline), Op]
        public static InstDefPart part(Hex8 src)
            => new(src);

        public static InstDefPart part(uint5 src)
            => new(src);
    }
}
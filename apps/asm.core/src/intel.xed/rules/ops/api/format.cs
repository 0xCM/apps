//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public static string format(in RuleToken src)
            => XedFormatters.format(src);

        internal static string format(FieldAssignment src)
            => XedFormatters.format(src);

        internal static string format(in NonterminalRule src)
            => XedFormatters.format(src);

        internal static string format(FieldConstraint src)
            => XedFormatters.format(src);

        internal static string format(BitfieldSeg src)
            => XedFormatters.format(src);

        [MethodImpl(Inline), Op]
        public static string format(RuleOperator src)
            => XedFormatters.format(src);

        [MethodImpl(Inline), Op]
        public static string format(FieldKind src)
            => XedFormatters.format(src);

        [MethodImpl(Inline), Op]
        public static string format(ConstraintKind src)
            => XedFormatters.format(src);

        [MethodImpl(Inline), Op]
        public static string format(NonterminalKind src)
            => XedFormatters.format(src);

        [MethodImpl(Inline), Op]
        public static string format(RuleMacroKind src)
            => XedFormatters.format(src);

        [MethodImpl(Inline), Op]
        public static string format(OpCodeKind src)
            => XedFormatters.format(src);

        public static string format(NontermCall src)
            => XedFormatters.format(src);

        internal static string format(in MacroSpec src)
            => XedFormatters.format(src);

        internal static string format(in RuleCriterion src)
            => XedFormatters.format(src);

        internal static string format(in DispExpr src)
            => XedFormatters.format(src);

        internal static string format(in RuleTable src)
            => XedFormatters.format(src);

        internal static string format(in RuleExpr src)
            => XedFormatters.format(src);
    }
}
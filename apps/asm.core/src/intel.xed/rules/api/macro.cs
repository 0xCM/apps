//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static MacroSpec macro<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => new MacroSpec(name, new MacroExpansion(field, 0, new FieldValue(field, core.bw64(value))));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec macro<T>(RuleMacroKind name, FieldKind field, RuleOperator op, T value)
            where T : unmanaged
                => new MacroSpec(name, new MacroExpansion(field, op, new FieldValue(field, core.bw64(value))));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec assign<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => macro(name, field, RuleOperator.Assign, value);

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, params FieldAssign[] a0)
            => new MacroSpec(name, a0.Map(x => new MacroExpansion(x.Field, RuleOperator.Assign, x.Value)));
    }
}
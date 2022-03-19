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
        public static MacroSpec macro(RuleMacroKind name, params MacroExpansion[] src)
            => new MacroSpec(name,src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec macro<T>(RuleMacroKind name, FieldKind field, RuleOperator op, T value)
            where T : unmanaged
                => new MacroSpec(name, new MacroExpansion(field,op, new FieldValue(field, core.bw64(value))));
    }
}
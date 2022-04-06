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
                => new MacroSpec(name, field, new MacroExpansion(field, 0, new CellValue(field, core.bw64(value))));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec macro<T>(RuleMacroKind name, FieldKind field, OperatorKind op, T value)
            where T : unmanaged
                => new MacroSpec(name, field, new MacroExpansion(field, op, new CellValue(field, core.bw64(value))));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec assign<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => macro(name, field, OperatorKind.Eq, value);

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, params FieldAssign[] a0)
            => new MacroSpec(name, 0, a0.Map(x => new MacroExpansion(x.Field, OperatorKind.Eq, x.Value)));
    }
}
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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec assign<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => new MacroSpec(name, field, new MacroExpansion(field, OperatorKind.Eq, new CellValue(field, core.bw64(value))));

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, FieldKind field, ModeKind value)
            => new MacroSpec(name, field, new MacroExpansion(field, OperatorKind.Eq, new CellValue(field, value)));

        [MethodImpl(Inline), Op]
        static MacroExpansion expansion(FieldKind field, ushort value)
            => new MacroExpansion(field, OperatorKind.Eq, new CellValue(field, value));

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, FieldKind field, EASZ value)
            => new MacroSpec(name, field, expansion(field, (ushort)value));

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, params FieldAssign[] a0)
            => new MacroSpec(name, 0, a0.Map(x => new MacroExpansion(x.Field, OperatorKind.Eq, x.Value)));
    }
}
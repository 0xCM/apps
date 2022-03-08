//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static FieldAssign assign<T>(FieldKind field, T fv)
            where T : unmanaged
                => new FieldAssign(value(field, fcode(field),fv));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec assign<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => new MacroSpec(name, assign(field, value));

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, params FieldAssign[] a0)
            => new MacroSpec(name, a0);
    }
}
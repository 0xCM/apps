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
        public static FieldAssign assign<T>(FieldKind field, T value)
            where T : unmanaged
                => new FieldAssign(field, core.bw64(value));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec assign<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => new MacroSpec(name, assign(field,value));

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, params FieldAssign[] a0)
            => new MacroSpec(name, a0);
    }
}
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
        public static FieldAssign assign<T>(FieldKind field, T fv)
            where T : unmanaged
                => new FieldAssign(value(field, fv));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MacroSpec assign<T>(RuleMacroKind name, FieldKind field, T value)
            where T : unmanaged
                => new MacroSpec(name, assign(field, value));

        [MethodImpl(Inline), Op]
        public static MacroSpec assign(RuleMacroKind name, params FieldAssign[] a0)
            => new MacroSpec(name, a0);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(ModeKind src)
            => assign(FieldKind.MODE, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(ModKind src)
            => assign(FieldKind.MOD, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(DF64 src)
            => assign(FieldKind.DF64, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(SMode src)
            => assign(FieldKind.SMODE, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(VexClass src)
            => assign(FieldKind.VEXVALID, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(VexKind src)
            => assign(FieldKind.VEX_PREFIX, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(SegPrefixKind src)
            => assign(FieldKind.SEG_OVD, (byte)src);

        [MethodImpl(Inline), Op]
        public static FieldAssign assign(EOSZ src)
            => assign(FieldKind.EOSZ, (byte)src);
    }
}
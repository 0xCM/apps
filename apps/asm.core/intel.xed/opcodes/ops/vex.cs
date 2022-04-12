//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedOpCodes
    {
        [MethodImpl(Inline), Op]
        public static VexMapKind? vexmap(VexClass kind, byte code)
            => kind == VexClass.VV1 ? (VexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static EvexMapKind? evexmap(VexClass kind, byte code)
            => kind == VexClass.EVV ? (EvexMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static XopMapKind? xopmap(VexClass kind, byte code)
            => kind == VexClass.XOPV ? (XopMapKind)code : null;

        [MethodImpl(Inline), Op]
        public static ref readonly VexKind vexkind(in RuleState src)
            => ref @as<VexKind>(src.VEX_PREFIX);

        [MethodImpl(Inline), Op]
        public static ref readonly VexClass vexclass(in RuleState src)
            => ref @as<VexClass>(src.VEXVALID);

        [Op]
        public static VexClass vexclass(OpCodeIndex src)
            => vexclass(@class(src));

        [Op]
        public static VexClass vexclass(OpCodeClass src)
        {
            var vc = VexClass.None;
            switch(src)
            {
                case OpCodeClass.Vex:
                    vc = VexClass.VV1;
                break;
                case OpCodeClass.Evex:
                    vc = VexClass.VV1;
                break;
                case OpCodeClass.Xop:
                    vc = VexClass.XOPV;
                break;
            }
            return vc;
        }
    }
}
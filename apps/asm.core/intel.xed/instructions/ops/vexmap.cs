//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
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
    }
}
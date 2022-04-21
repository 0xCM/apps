//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref readonly VexKind vexkind(in OperandState src)
            => ref XedOpCodes.vexkind(src);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref VexKind vexkind(ref OperandState src)
                => ref @as<VexKind>(src.VEX_PREFIX);
        }
    }
}
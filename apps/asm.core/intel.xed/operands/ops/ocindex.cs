//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static OpCodeIndex ocindex(in OperandState state)
            => XedOpCodes.index(state);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref OperandState set(OpCodeIndex src, ref OperandState dst)
            {
                XedOpCodes.mapnum(src, out dst.MAP);
                dst.VEXVALID = (byte)XedOpCodes.vexclass(src);
                return ref dst;
            }
        }
    }
}
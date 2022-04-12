//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ref RuleState set(OpCodeIndex src, ref RuleState dst)
        {
            XedOpCodes.mapcode(src, out dst.MAP);
            dst.VEXVALID = (byte)XedOpCodes.vexclass(src);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static OpCodeIndex ocindex(in RuleState state)
            => XedOpCodes.index(state);
    }
}
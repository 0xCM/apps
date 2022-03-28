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
        public static MachineMode mode(in RuleState src)
            => (ModeKind)src.MODE;

        public static ref RuleState set(MachineMode src, ref RuleState dst)
        {
            dst.MODE = (byte)src;
            return ref dst;
        }
    }
}
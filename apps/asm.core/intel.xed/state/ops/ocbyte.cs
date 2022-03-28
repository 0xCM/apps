//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static Hex8 ocbyte(in RuleState src)
            => src.NOMINAL_OPCODE;

        [MethodImpl(Inline), Op]
        public ref RuleState opcode(Hex8 src, ref RuleState dst)
        {
            dst.NOMINAL_OPCODE = src;
            return ref dst;
        }
    }
}
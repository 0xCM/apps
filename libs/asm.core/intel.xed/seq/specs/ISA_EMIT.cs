//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedRules.RuleName;

    partial class XedSeq
    {
        /*
        SEQUENCE ISA_EMIT
            PREFIX_ENC_EMIT()
            REX_PREFIX_ENC_EMIT() | VEXED_REX_EMIT()
            INSTRUCTIONS_EMIT()
        */
        public static SeqDef ISA_EMIT() => emit(nameof(ISA_EMIT), new RuleName[]{
            PREFIX_ENC,
            VEXED_REX,
            INSTRUCTIONS
        });
    }
}
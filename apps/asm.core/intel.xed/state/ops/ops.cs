//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedDisasm;

    partial class XedState
    {
        public static Dictionary<OpNameKind,DisasmOp> ops(in DisasmState state, in AsmHexCode code)
        {
            var dst = dict<OpNameKind,DisasmOp>();
            var values = opvalues(state.RuleState, code);
            var count = values.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref values[i];
                dst.TryAdd(value.Name, new DisasmOp(value.Name, value.Data));
            }

            if(state.RELBRVal.IsNonZero)
                dst[OpNameKind.RELBR] = new DisasmOp(OpNameKind.RELBR, state.RELBRVal);
            if(state.MEM0Val.IsNonEmpty)
                dst[OpNameKind.MEM0] = new DisasmOp(OpNameKind.MEM0, state.MEM0Val);
            if(state.MEM1Val.IsNonEmpty)
                dst[OpNameKind.MEM1] = new DisasmOp(OpNameKind.MEM1, state.MEM1Val);
            if(state.AGENVal.IsNonEmpty)
                dst[OpNameKind.AGEN] = new DisasmOp(OpNameKind.AGEN, state.AGENVal);
            return dst;
        }
    }
}
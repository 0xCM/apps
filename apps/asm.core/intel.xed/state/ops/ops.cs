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
        public static Dictionary<OpName,DisasmOp> ops(in DisasmState state, in AsmHexCode code)
        {
            var dst = dict<OpName,DisasmOp>();
            var values = opvalues(state.RuleState, code);
            var count = values.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var value = ref values[i];
                dst.TryAdd(value.Name, new DisasmOp(value.Name, value.Data));
            }

            if(state.RELBRVal.IsNonZero)
                dst[OpName.RELBR] = new DisasmOp(OpName.RELBR, state.RELBRVal);
            if(state.MEM0Val.IsNonEmpty)
                dst[OpName.MEM0] = new DisasmOp(OpName.MEM0, state.MEM0Val);
            if(state.MEM1Val.IsNonEmpty)
                dst[OpName.MEM1] = new DisasmOp(OpName.MEM1, state.MEM1Val);
            if(state.AGENVal.IsNonEmpty)
                dst[OpName.AGEN] = new DisasmOp(OpName.AGEN, state.AGENVal);
            return dst;
        }
    }
}
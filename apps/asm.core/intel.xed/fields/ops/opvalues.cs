//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static core;

    using N = XedRules.OpName;

    partial class XedFields
    {
        public static Index<OpValue> opvalues(in RuleState state, in AsmHexCode code)
        {
            var _ops = list<OpValue>();
            if(state.IMM0)
                _ops.Add(new OpValue(N.IMM0, XedFields.imm0(state, code)));

            if(state.IMM1)
                _ops.Add(new OpValue(N.IMM1, XedFields.imm1(state, code)));

            if(state.DISP_WIDTH != 0)
                _ops.Add(new OpValue(N.DISP, XedFields.disp(state, code)));

            if(state.BASE0 != 0)
                _ops.Add(new OpValue(N.BASE0, state.BASE0));

            if(state.BASE1 != 0)
                _ops.Add(new OpValue(N.BASE1, state.BASE1));

            if(state.SCALE != 0)
                _ops.Add(new OpValue(N.SCALE, state.SCALE));

            if(state.INDEX != 0)
                _ops.Add(new OpValue(N.INDEX, state.INDEX));

            if(state.REG0 != 0)
                _ops.Add(new OpValue(N.REG0, state.REG0));

            if(state.REG1 != 0)
                _ops.Add(new OpValue(N.REG1, state.REG1));

            if(state.REG2 != 0)
                _ops.Add(new OpValue(N.REG2, state.REG2));

            if(state.REG3 != 0)
                _ops.Add(new OpValue(N.REG3, state.REG3));

            if(state.REG4 != 0)
                _ops.Add(new OpValue(N.REG4, state.REG4));

            if(state.REG5 != 0)
                _ops.Add(new OpValue(N.REG5, state.REG5));

            if(state.REG6 != 0)
                _ops.Add(new OpValue(N.REG6, state.REG6));

            if(state.REG7 != 0)
                _ops.Add(new OpValue(N.REG7, state.REG7));

            if(state.REG8 != 0)
                _ops.Add(new OpValue(N.REG8, state.REG8));

            if(state.REG9 != 0)
                _ops.Add(new OpValue(N.REG9, state.REG9));

            if(state.RELBRVal.IsNonZero)
                _ops.Add(new OpValue(N.RELBR, state.RELBRVal));

            if(state.MEM0Val.IsNonEmpty)
                _ops.Add(new OpValue(N.MEM0, state.MEM0Val));

            if(state.MEM1Val.IsNonEmpty)
                _ops.Add(new OpValue(N.MEM1, state.MEM1Val));

            if(state.AGENVal.IsNonEmpty)
                _ops.Add(new OpValue(N.AGEN, state.AGENVal));

            return _ops.ToArray();
        }
    }
}
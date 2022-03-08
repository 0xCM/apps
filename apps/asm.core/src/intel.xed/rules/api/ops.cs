//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using N = XedRules.RuleOpName;

    partial class XedRules
    {
        public static RuleOperands ops(in RuleState state, in AsmHexCode code)
        {
            var _ops = list<RuleOp>();
            if(state.IMM0)
                _ops.Add(new RuleOp(N.IMM0, imm(state, code)));

            if(state.BASE0 != 0)
                _ops.Add(new RuleOp(N.BASE0, state.BASE0));

            if(state.BASE1 != 0)
                _ops.Add(new RuleOp(N.BASE1, state.BASE1));

            if(state.SCALE != 0)
                _ops.Add(new RuleOp(N.SCALE, state.SCALE));

            if(state.INDEX != 0)
                _ops.Add(new RuleOp(N.INDEX, state.INDEX));

            if(state.REG0 != 0)
                _ops.Add(new RuleOp(N.REG0, state.REG0));

            if(state.REG1 != 0)
                _ops.Add(new RuleOp(N.REG1, state.REG1));

            if(state.REG2 != 0)
                _ops.Add(new RuleOp(N.REG2, state.REG2));

            if(state.REG3 != 0)
                _ops.Add(new RuleOp(N.REG3, state.REG3));

            if(state.REG4 != 0)
                _ops.Add(new RuleOp(N.REG4, state.REG4));

            if(state.REG5 != 0)
                _ops.Add(new RuleOp(N.REG5, state.REG5));

            if(state.REG6 != 0)
                _ops.Add(new RuleOp(N.REG6, state.REG6));

            if(state.REG7 != 0)
                _ops.Add(new RuleOp(N.REG7, state.REG7));

            if(state.REG8 != 0)
                _ops.Add(new RuleOp(N.REG8, state.REG8));

            if(state.REG9 != 0)
                _ops.Add(new RuleOp(N.REG9, state.REG9));

            if(state.DISP_WIDTH != 0)
                _ops.Add(new RuleOp(N.DISP, disp(state, code)));

            if(state.RELBRVal.IsNonZero)
                _ops.Add(new RuleOp(N.RELBR, state.RELBRVal));

            if(state.MEM0Val.IsNonEmpty)
                _ops.Add(new RuleOp(N.MEM0, state.MEM0Val));

            if(state.MEM1Val.IsNonEmpty)
                _ops.Add(new RuleOp(N.MEM1, state.MEM1Val));

            if(state.AGENVal.IsNonEmpty)
                _ops.Add(new RuleOp(N.AGEN, state.AGENVal));

            return map(_ops, o => (o.Name, o)).ToDictionary();
        }
    }
}
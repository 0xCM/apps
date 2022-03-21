//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using K = XedRules.RuleOpKind;
    using N = XedRules.RuleOpName;

    partial class XedRules
    {
        public static RuleOpValues opvalues(in RuleState state, in AsmHexCode code)
        {
            var _ops = list<RuleOpValue>();
            if(state.IMM0)
                _ops.Add(new RuleOpValue(N.IMM0, imm0(state, code)));

            if(state.IMM1)
                _ops.Add(new RuleOpValue(N.IMM1, imm1(state, code)));

            if(state.DISP_WIDTH != 0)
                _ops.Add(new RuleOpValue(N.DISP, disp(state, code)));

            if(state.BASE0 != 0)
                _ops.Add(new RuleOpValue(N.BASE0, state.BASE0));

            if(state.BASE1 != 0)
                _ops.Add(new RuleOpValue(N.BASE1, state.BASE1));

            if(state.SCALE != 0)
                _ops.Add(new RuleOpValue(N.SCALE, state.SCALE));

            if(state.INDEX != 0)
                _ops.Add(new RuleOpValue(N.INDEX, state.INDEX));

            if(state.REG0 != 0)
                _ops.Add(new RuleOpValue(N.REG0, state.REG0));

            if(state.REG1 != 0)
                _ops.Add(new RuleOpValue(N.REG1, state.REG1));

            if(state.REG2 != 0)
                _ops.Add(new RuleOpValue(N.REG2, state.REG2));

            if(state.REG3 != 0)
                _ops.Add(new RuleOpValue(N.REG3, state.REG3));

            if(state.REG4 != 0)
                _ops.Add(new RuleOpValue(N.REG4, state.REG4));

            if(state.REG5 != 0)
                _ops.Add(new RuleOpValue(N.REG5, state.REG5));

            if(state.REG6 != 0)
                _ops.Add(new RuleOpValue(N.REG6, state.REG6));

            if(state.REG7 != 0)
                _ops.Add(new RuleOpValue(N.REG7, state.REG7));

            if(state.REG8 != 0)
                _ops.Add(new RuleOpValue(N.REG8, state.REG8));

            if(state.REG9 != 0)
                _ops.Add(new RuleOpValue(N.REG9, state.REG9));

            if(state.RELBRVal.IsNonZero)
                _ops.Add(new RuleOpValue(N.RELBR, state.RELBRVal));

            if(state.MEM0Val.IsNonEmpty)
                _ops.Add(new RuleOpValue(N.MEM0, state.MEM0Val));

            if(state.MEM1Val.IsNonEmpty)
                _ops.Add(new RuleOpValue(N.MEM1, state.MEM1Val));

            if(state.AGENVal.IsNonEmpty)
                _ops.Add(new RuleOpValue(N.AGEN, state.AGENVal));

            return map(_ops, o => (o.Name, o)).ToDictionary();
        }
    }
}
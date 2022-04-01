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

    using N = XedModels.OpNameKind;

    partial class XedState
    {
        public static Index<OpValue> opvalues(in RuleState state, in AsmHexCode code)
        {
            var _ops = list<OpValue>();
            if(state.IMM0)
                _ops.Add(new OpValue(N.IMM0, XedState.imm0(state, code)));

            if(state.IMM1)
                _ops.Add(new OpValue(N.IMM1, XedState.imm1(state, code)));

            if(state.DISP_WIDTH != 0)
                _ops.Add(new OpValue(N.DISP, XedState.disp(state, code)));

            if(state.BASE0 != 0)
                _ops.Add(new OpValue(N.BASE0, state.BASE0));

            if(state.BASE1 != 0)
                _ops.Add(new OpValue(N.BASE1, state.BASE1));

            if(state.SCALE != 0)
                _ops.Add(new OpValue(N.SCALE, (MemoryScale)state.SCALE));

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

            return _ops.ToArray();
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var details = XedOpCodes.details(patterns);
            var dst = text.buffer();
            for(var i=0; i<details.Count; i++)
            {
                ref readonly var detail = ref details[i];
                ref readonly var layout = ref detail.Layout;
                ref readonly var expr = ref detail.Expr;

            }

            return true;
        }


        [CmdOp("xed/check/modrm")]
        Outcome CheckModRm(CmdArgs args)
        {
            var spec = ModRmVar.init();
            Write(spec.Format());

            spec.Mod(0b10);
            var a0 = spec.Evaluate();
            Require.equal(a0.Mod(), (uint2)0b10);
            Write(spec.Format());

            spec.Reg(0b101);
            var a1 = spec.Evaluate();
            Require.equal(a1.Reg(), (uint3)0b101);
            Write(spec.Format());

            spec.Rm(0b011);
            var a2 = spec.Evaluate();
            Require.equal(a2.Rm(), (uint3)0b011);
            Write(spec.Format());

            return true;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class CheckCmdProvider
    {

        [CmdOp("check/sdm/sigs")]
        Outcome CheckSdmSigs(CmdArgs args)
        {

            return true;
        }

        Index<AsmSigExpr> Concretize(AsmSigRule<IRuleExpr> src)
        {
            var dst = list<AsmSigExpr>();
            var opcount = src.Operands.Count;
            for(var i=0; i<opcount; i++)
            {
                var sig = new AsmSigExpr(src.Mnemonic);

                ref readonly var op = ref src.Operands[i];
                if(op is IChoiceRule c)
                {
                    var choices = c.Terms;
                }
                else if(op is IOptionRule o)
                {
                    var potential = o.Potential;
                }
                else
                {

                }

            }



            return dst.ToArray();
        }

    }
}
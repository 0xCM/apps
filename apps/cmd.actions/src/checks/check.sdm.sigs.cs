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
            var src = Sdm.LoadImportedOpcodes();
            var forms = src.Select(x => SdmOps.form(x));
            var count = forms.Count;

            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                var decomp = SdmRules.Symbolize(form.Sig);
                Write(string.Format("{0} -> {1}", form.Sig, decomp));
            }

            return true;
        }

        Index<AsmSigExpr> Concretize(AsmSigRule<IRuleExpr> src)
        {
            var dst = list<AsmSigExpr>();
            var opcount = src.Operands.Count;
            for(var i=0; i<opcount; i++)
            {

                ref readonly var op = ref src.Operands[i];
                if(op is IChoiceRule c)
                {
                    var choices = c.Choices;
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
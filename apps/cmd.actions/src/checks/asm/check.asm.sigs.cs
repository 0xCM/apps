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
        [CmdOp("check/asm/sigs")]
        Outcome CheckSdmSigs(CmdArgs args)
        {
            var result = Outcome.Success;
            var sigs = list<AsmSig>();
            var details = Sdm.LoadImportedOpcodes();
            var count = details.Count;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                result = AsmSigs.parse(detail.Sig, out var sig);
                if(result.Fail)
                    break;

                var terms = AsmSigs.terminate(sig);
                var kTerms = terms.Count;
                for(var j=0; j<kTerms; j++)
                {
                    ref readonly var term = ref terms[j];
                    Write(string.Format("{0,-6} | {1, -64}", counter++, term));
                }

            }

            return Sdm.EmitSigOps();
        }
    }
}
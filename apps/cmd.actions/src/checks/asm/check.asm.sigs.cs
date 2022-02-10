//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/sigs")]
        Outcome CheckSdmSigs(CmdArgs args)
        {
            var result = Outcome.Success;
            var details = Sdm.LoadImportedOpcodes();
            var count = details.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                if(!AsmSigs.parse(detail.Sig, out var sig))
                {
                    result = (false, string.Format("Sig parse failure:{0}", detail.Sig));
                    break;
                }
            }

            return result;
        }
    }
}
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
                var decomp = SdmRules.Decompose(form.Sig);
                Write(string.Format("{0} -> {1}", form.Sig, decomp));
            }

            return true;
        }
    }
}
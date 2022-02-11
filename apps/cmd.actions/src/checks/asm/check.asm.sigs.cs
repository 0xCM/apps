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
        [CmdOp("check/asm/forms")]
        Outcome CheckSdmSigs(CmdArgs args)
        {
            var result = Outcome.Success;
            Sdm.EmitForms();
            return true;
        }
    }
}
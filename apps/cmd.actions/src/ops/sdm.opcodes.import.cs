//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("sdm/opcodes/import")]
        Outcome SdmImport(CmdArgs args)
        {
            var result = Outcome.Success;
            var svc = Service(Wf.IntelSdm);
            svc.ImportOpCodes();
            return result;
        }
    }
}
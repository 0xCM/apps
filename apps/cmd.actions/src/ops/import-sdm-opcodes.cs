//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("import-sdm-opcodes")]
        Outcome SdmImport(CmdArgs args)
        {
            var result = Outcome.Success;
            var svc = Service(Wf.IntelSdm);
            svc.ImportOpCodes();
            return result;
        }
    }
}
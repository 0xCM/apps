//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        const string RunSdmEtl = "sdm/run/etl";

        [CmdOp(RunSdmEtl)]
        Outcome runsdmetl(CmdArgs args)
            => Service(Wf.IntelSdm).RunEtl();

        const string ImportSdmOpcodes = "sdm/import/opcodes";

        [CmdOp(ImportSdmOpcodes)]
        Outcome SdmCodeGen(CmdArgs args)
        {
            var opcodes = Sdm.ImportOpCodes();
            return true;
        }
    }
}
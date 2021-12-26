//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        const string RunSdmEtl = "sdm/import";

        [CmdOp(RunSdmEtl)]
        Outcome runsdmetl(CmdArgs args)
            => Sdm.Import();
    }
}
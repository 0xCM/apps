//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GlobalCommands
    {
        const string RunSdmEtl = "sdm/run/etl";

        [CmdOp(RunSdmEtl)]
        Outcome runsdmetl(CmdArgs args)
            => Service(Wf.IntelSdm).RunEtl();
    }
}
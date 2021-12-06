//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GlobalCommands
    {
        [CmdOp("run-sdm-etl")]
        Outcome RunSdmEtl(CmdArgs args)
            => Service(Wf.IntelSdm).RunEtl();
    }
}
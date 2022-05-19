//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("cult/import")]
        Outcome ImportCultData(CmdArgs args)
            => Wf.CultProcessor().Process();
    }
}
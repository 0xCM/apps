//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        DumpBin DumpBin => Service(Wf.DumpBin);

        [CmdOp("dumpbin/dump-dll")]
        Outcome DumpDll(CmdArgs args)
            => DumpBin.DumpModules(Project(), FileModuleKind.Dll);
    }
}
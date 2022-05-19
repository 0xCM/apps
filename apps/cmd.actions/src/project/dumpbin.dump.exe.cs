//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("dumpbin/dump/exe")]
        Outcome DumpExe(CmdArgs args)
            => DumpBin.DumpModules(Project(), FileModuleKind.Exe);
    }
}
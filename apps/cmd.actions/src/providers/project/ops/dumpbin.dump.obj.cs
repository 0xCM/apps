//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("dumpbin/dump/obj")]
        Outcome DumpObj(CmdArgs args)
            => DumpBin.DumpModules(Project(), FileModuleKind.Obj);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using System.IO;
    using static Root;

    using llvm;
    using Asm;

    partial class ProjectCmdProvider
    {
        [CmdOp("dumpbin/dump/dll")]
        Outcome DumpDll(CmdArgs args)
            => DumpBin.DumpModules(Project(), FileModuleKind.Dll);

        LlvmObjDumpSvc LlvmObjDump => Service(Wf.LlvmObjDump);


   }
}
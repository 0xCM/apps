//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class ProjectCmd : ProjectCmdService<ProjectCmd>, IProjectProvider
    {
        CoffServices Coff => Wf.CoffServices();

        WsScripts Scripts => Wf.WsScripts();

        AsmObjects AsmObjects => Wf.AsmObjects();

        ProjectSvc ProjectSvc => Wf.ProjectSvc();

        WsScripts Projects => Wf.WsScripts();

        AsmRegSets Regs => Service(AsmRegSets.create);

        DumpBin DumpBin => Wf.DumpBin();

        AsmFlowCommands AsmFlows => Wf.AsmFlows();

        Dictionary<string,string> BuildCmdNames {get;}
            = array(("mc.models", "project/build/asm"),
                        ("clang.models","project/build/c"),
                        ("llvm.models","project/build/llc"),
                        ("canonical","project/build/builtins")
            ).ToDictionary();

   }
}
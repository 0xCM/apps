//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class ProjectCmd : AppCmdService<ProjectCmd>
    {
        CoffServices Coff => Wf.CoffServices();

        WsScripts Scripts => Wf.WsScripts();

        AsmObjects AsmObjects => Wf.AsmObjects();

        ProjectSvc ProjectSvc => Wf.ProjectSvc();

        WsScripts Projects => Wf.WsScripts();

        AsmRegSets Regs => Service(AsmRegSets.create);

        //DumpBin DumpBin => Wf.DumpBin();

        Dictionary<string,string> BuildCmdNames {get;}
            = new (string project, string cmd)[]{
                        ("mc.models", "project/build/asm"),
                        ("clang.models","project/build/c"),
                        ("llvm.models","project/build/llc"),
                        ("canonical","project/build/builtins")
            }.ToDictionary();
   }
}
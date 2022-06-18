//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using llvm;

    using static core;

    using static WsFileFlows;

    public sealed class AsmToMcAsmCmd : ScriptFlows<AsmToMcAsmCmd,McCmd,AsmToMcAsm>
    {
        public override McCmd BuildCmd(IProjectWs project, string scope, FS.FilePath src)
        {
            var cmd = McCmd.Empty;
            cmd.Source = src;
            cmd.Target = GetTargetPath(project,scope,src);
            cmd.Triple = "x86_64-pc-windows-msvc";
            cmd.X86AsmSyntax = "intel";
            cmd.OutputAsmVariant =  1;
            cmd.PrintImmHex = 1;
            cmd.MasmIntegers = 1;
            cmd.MasmHexFloats = 1;
            return cmd;
        }
    }

    public class AsmFlowCommands : AppService<AsmFlowCommands>
    {
        public SToAsmCmd Select(SToAsm flow)
            => Service(() => SToAsmCmd.create(Wf));

        public AsmToMcAsmCmd Select(AsmToMcAsm flow)
            => Service(() => AsmToMcAsmCmd.create(Wf));
    }

    public partial class ProjectCmd : AppCmdService<ProjectCmd>
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
            = new (string project, string cmd)[]{
                        ("mc.models", "project/build/asm"),
                        ("clang.models","project/build/c"),
                        ("llvm.models","project/build/llc"),
                        ("canonical","project/build/builtins")
            }.ToDictionary();
   }
}
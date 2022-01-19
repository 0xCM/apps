//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static FileFlowTypes;

    public sealed class SToAsmCmd : FileFlowCommands<SToAsmCmd,McCmd,SToAsm>
    {
        public override McCmd BuildCmd(IProjectWs project, string scope, FS.FilePath src)
        {
            var cmd = McCmd.Empty;
            cmd.Source = src;
            cmd.Target = GetTargetPath(project,scope,src);
            cmd.FileType = "asm";
            cmd.Triple = "x86_64-pc-windows-msvc";
            cmd.MCpu = "cascadelake";
            cmd.OutputAsmVariant = 1;
            cmd.PrintImmHex = 1;
            return cmd;
        }
    }

    public sealed class AsmToMcAsmCmd : FileFlowCommands<AsmToMcAsmCmd,McCmd,AsmToMcAsm>
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
}
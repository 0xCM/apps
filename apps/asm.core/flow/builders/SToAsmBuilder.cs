//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static FileFlowTypes;

    class SToAsmBuilder : FlowCmdBuilder<SToAsmBuilder,McCmd,SToAsm>
    {
        public override McCmd BuildCmd(IProjectWs project, string scope, SToAsm flow, FS.FilePath src)
        {
            var cmd = McCmd.Empty;
            cmd.Source = src;
            cmd.Target = project.Out(scope).Create() + src.FileName.ChangeExtension(flow.TargetExt);
            cmd.FileType = "asm";
            cmd.Triple = "x86_64-pc-windows-msvc";
            cmd.MCpu = "cascadelake";
            cmd.OutputAsmVariant = 1;
            cmd.PrintImmHex = 1;
            return cmd;
        }
    }
}
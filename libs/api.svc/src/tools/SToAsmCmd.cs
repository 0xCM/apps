//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypedFileFlows;

    public sealed class SToAsmCmd : ScriptBuilder<SToAsmCmd,McCmd,SToAsm>
    {
        public override McCmd BuildCmd(IProjectWsObsolete project, string scope, FS.FilePath src)
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
}
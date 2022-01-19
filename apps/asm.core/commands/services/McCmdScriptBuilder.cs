//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;

    public class McCmdScriptBuilder : CmdScriptBuilder<McCmdScriptBuilder>
    {
        public McCmdScriptBuilder()
        {

        }

        public override Index<CmdLine> BuildCmdLines(IProjectWs project, string scope, IFileFlowType flowtype)
        {

            CmdLine Gen(FS.FilePath dst)
            {
                var cmd = McCmd.Empty;
                cmd.Source = dst;
                cmd.Target = project.Out(scope).Create() + dst.FileName.ChangeExtension(flowtype.TargetExt);
                cmd.FileType = "asm";
                cmd.Triple = "x86_64-pc-windows-msvc";
                cmd.MCpu = "cascadelake";
                cmd.OutputAsmVariant = 1;
                cmd.PrintImmHex = 1;
                var script = BuildCmdScript(cmd);
                var scriptdir = project.Out(string.Format("{0}.scripts", scope));
                var spath =  scriptdir + dst.FileName.ChangeExtension(FS.Cmd);
                using var writer = spath.AsciWriter();
                var formatted = script.Format();
                writer.WriteLine(formatted);
                return new CmdLine(spath.Format(PathSeparator.BS));
            }

            var buffer = core.bag<CmdLine>();
            iter(project.SrcFiles(scope, false), path => buffer.Add(Gen(path)), true);
            return buffer.Array();
        }
    }
}
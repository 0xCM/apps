//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using llvm;

    public class McCmdScriptBuilder : CmdScriptBuilder<McCmdScriptBuilder>
    {
        public McCmdScriptBuilder()
        {

        }

        public override Index<CmdLine> BuildCmdLines(IProjectWs project, string cmdsrc, IFileFlowType flowtype)
        {
            var dst = core.bag<CmdLine>();
            var src = project.SrcFiles(cmdsrc, false);
            var count = src.Length;
            var outdir = project.Out(cmdsrc).Create();
            var scriptdir = project.Out(string.Format("{0}.scripts", cmdsrc));

            CmdLine Gen(FS.FilePath path)
            {
                var cmd = McCmd.Empty;
                cmd.Source = path;
                cmd.Target = outdir + path.FileName.ChangeExtension(flowtype.TargetExt);
                cmd.FileType = "asm";
                cmd.Triple = "x86_64-pc-windows-msvc";
                cmd.MCpu = "cascadelake";
                cmd.OutputAsmVariant = 1;
                cmd.PrintImmHex = 1;
                var script = BuildCmdScript(cmd);
                var spath =  scriptdir + path.FileName.ChangeExtension(FS.Cmd);
                using var writer = spath.AsciWriter();
                var formatted = script.Format();
                writer.WriteLine(formatted);
                return new CmdLine(spath.Format(PathSeparator.BS));
            }

            iter(src, path => dst.Add(Gen(path)), true);
            return dst.Array();
        }
    }
}
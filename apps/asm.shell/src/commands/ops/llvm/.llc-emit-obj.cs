//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

     using llvm;

    partial class AsmCmdService
    {
        [CmdOp(".llc-obj")]
        public Outcome LlcObj(CmdArgs args)
        {
            var outcome = Outcome.Success;
            var input = State.Files().View;
            var output = list<FS.FilePath>();
            var isets = array("avx512f", "avx2", "avx");

            foreach(var file in input)
            {
                foreach(var iset in isets)
                {
                    var vars = Cmd.vars(
                        ("SrcFile", file.FileName.Format()),
                        ("iset", iset),
                        ("SrcDir", file.FolderPath.Format(PathSeparator.BS))
                        );

                    var cmd = Cmd.cmdline(Ws.Tools().Script(LlvmNames.Tools.llc, "emit-obj").Format(PathSeparator.BS));
                    var response = OmniScript.RunCmd(cmd, vars);
                    var outfile = Lines.prop(response,"DstPath");
                    if(text.nonempty(outfile))
                    {
                        var outpath = FS.path(outfile);
                        Status(string.Format("Emitted {0}", outpath.Format()));
                        output.Add(outpath);
                    }
                }
            }

            Files(output.ToArray(), false);

            return outcome;
        }
    }
}
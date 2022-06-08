//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        [CmdOp("project/nm")]
        Outcome RunLlvmNm(CmdArgs args)
        {
            var result = Outcome.Success;
            var files = Project().Files().Where(f => f.Is(FS.Obj) || f.Is(FS.Dll) || f.Is(FS.Lib) || f.Is(FS.Exe)).View;
            var count = files.Length;
            var outdir = Project().OutDir();
            var script = Tools.Script(ToolNames.llvm_nm, "run");
            for(var i=0; i<count; i++)
            {
                var src = skip(files,i);
                var dst = outdir + src.FileName.WithExtension(FS.Sym);
                var vars = Cmd.vars(
                    ("SrcPath", src.Format(PathSeparator.BS)),
                    ("DstPath", dst.Format(PathSeparator.BS))
                    );
                result = OmniScript.Run(script,vars, false, out _);
                if(result.Fail)
                    return result;
            }
            return result;
        }
    }
}
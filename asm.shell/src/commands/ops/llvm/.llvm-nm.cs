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
        [CmdOp(".llvm-nm")]
        Outcome RunLlvmNm(CmdArgs args)
        {
            var result = Outcome.Success;
            var files = State.Files(FS.Obj, FS.Dll, FS.Lib, FS.Exe).View;
            var count = files.Length;
            var outdir = AsmWs.ObjSymDir().Create();
            var script = Ws.Tools().Script(LlvmNames.Tools.llvm_nm, "run");
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
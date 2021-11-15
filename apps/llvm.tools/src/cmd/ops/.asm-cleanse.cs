//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames.Tools;

    partial class LlvmCmd
    {
        [CmdOp(".clense-asm")]
        Outcome CleanseAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var cmd = Cmd.cmdline(Tools.Script(llvm_mc, "cleanse").Format(PathSeparator.BS));
            var src = State.Files(FS.S).View;
            var count = src.Length;
            var outdir = Data.OutDir("cleansed").Create();

            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var vars = WsVars.create();
                vars.DstDir = outdir;
                vars.SrcDir = path.FolderPath;
                vars.SrcFile = path.FileName;
                vars.SrcId = path.FileName.WithoutExtension.Format();
                result = OmniScript.Run(cmd,vars.ToCmdVars(), out _);
                if(result.Fail)
                    break;
            }

            return result;
        }
    }
}
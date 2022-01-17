//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ToolNames;

    partial class ProjectCmdProvider
    {
        [CmdOp("mc/cleanse")]
        Outcome CleanseAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var project = Project();
            var script = project.Script("cleanse");
            var cmd = Cmd.cmdline(script.Format(PathSeparator.BS));
            var src = project.SrcFiles("att/64", false);
            var count = src.Length;
            project.Out().Delete();
            var outdir = project.Out("att/64").Create();
            var log = project.Out() + FS.file("cleanse", FS.Log);

            void OnStatus(in string msg)
            {
                Status(msg);
            }

            void OnError(in string msg)
            {
                Error(msg);
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                var vars = WsVars.create();
                vars.Actor = ToolNames.llvm_mc;
                vars.SrcPath = path;
                vars.DstPath = outdir + path.FileName.ChangeExtension(FS.Asm);
                result = OmniScript.Run(cmd, vars.ToCmdVars(), log, OnStatus, OnError, out var response);
                if(result.Fail)
                    break;
            }

            return result;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    partial class AsmCmdService
    {
        Outcome DumpModules(FileModuleKind kind)
        {
            var result = Outcome.Success;
            var script = kind switch{
                FileModuleKind.Obj => "dump-obj",
                FileModuleKind.Exe => "dump-exe",
                FileModuleKind.Lib => "dump-lib",
                FileModuleKind.Dll => "dump-dll",
                _ => EmptyString
            };

            if(empty(script))
                return (false, string.Format("{0} not supported", kind));

            var project = State.ProjectId();
            var outdir = Ws.Projects().DataOut(project);
            var cmd = Cmd.cmdline(Ws.Tools().Script(Toolspace.dumpbin, script).Format(PathSeparator.BS));
            var input = State.Files().View;
            var count = input.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(input,i);
                var vars = WsVars.create();
                vars.DstDir = outdir;
                vars.SrcDir = path.FolderPath;
                vars.SrcFile = path.FileName;
                result = OmniScript.RunCmd(cmd, vars.ToCmdVars(), out _);
            }
            return result;
        }
    }
}
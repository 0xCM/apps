//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static FileFlowTypes;

    partial class ProjectCmdProvider
    {
        FlowCommands FlowCommands => Service(Wf.FlowCommands);

        [CmdOp("mc/cleanse")]
        Outcome ExecMcCleanse(CmdArgs args)
        {
            var cmdname = "cleanse";
            var scope = "att/64";
            var project = Project();
            var cmd = FlowCommands.Select(SToAsm.Instance);
            cmd.Execute(project, (scope, cmdname));
            return true;
        }

        [CmdOp("mc/asm-to-mcasm")]
        Outcome ExecAsmToMcAsm(CmdArgs args)
        {
            var cmdname = "asm-to-mcasm";
            var scope = "asm";
            var project = Project();
            var cmd = FlowCommands.Select(AsmToMcAsm.Instance);
            cmd.Execute(project, (scope, cmdname));

            // var cmds = cmd.BuildCmdLines(project, scope, cmdname);
            // iter(cmds, cmd => Write(cmd.Format()));

            return true;
        }

    }
}
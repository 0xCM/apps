//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ExecWorkflow : CmdReactor<CmdExec,CmdResult>
    {
        protected override CmdResult Run(CmdExec cmd)
        {
            if(Cmd.find(cmd, out var handler))
            {
                handler();
                return Cmd.ok(cmd, string.Format("Executed <{0}> workflow", cmd.WorkflowName));
            }
            return Cmd.fail(cmd, "Handler not found");
        }
    }
}
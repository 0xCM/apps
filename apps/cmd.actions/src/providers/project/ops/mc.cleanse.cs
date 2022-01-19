//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("mc/cleanse")]
        Outcome McTest(CmdArgs args)
        {
            FlowScriptRunner.RunScripts(Project(), "cleanse", "att/64", FileFlowTypes.SToAsm.Instance, McScriptBuilder);
            return true;
        }
    }
}
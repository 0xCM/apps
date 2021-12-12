//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/run/machine")]
        protected Outcome RunApiMachine(CmdArgs args)
        {
            using var machine = MachineRunner.create(Wf);
            machine.Run(WorkflowOptions.@default());
            return true;
        }
    }
}
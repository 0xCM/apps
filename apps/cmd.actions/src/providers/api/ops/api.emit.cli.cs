//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/cli")]
        protected Outcome EmitMetadataSets(CmdArgs args)
        {
            CliEmitter.EmitMetadaSets(WorkflowOptions.@default());
            return true;
        }
    }
}
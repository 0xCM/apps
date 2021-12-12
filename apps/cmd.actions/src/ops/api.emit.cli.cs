//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GlobalCommands
    {
        [CmdOp("api/emit/cli")]
        protected Outcome EmitMetadataSets(CmdArgs args)
        {
            Service(Wf.CliEmitter).EmitMetadaSets(WorkflowOptions.@default());
            return true;
        }
    }
}
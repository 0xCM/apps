//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("emit-api-metadata-sets")]
        protected Outcome EmitMetadataSets(CmdArgs args)
        {
            Service(Wf.CliEmitter).EmitMetadaSets(WorkflowOptions.@default());
            return true;
        }

    }
}
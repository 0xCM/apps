//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit/cli")]
        void EmitMetadataCli()
        {
            CliEmitter.EmitMetadaSets(WorkflowOptions.@default());
            ApiMetadata.EmitMsil();
        }
    }
}
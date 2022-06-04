//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiActionCmd
    {
        [CmdOp("api/emit/cli")]
        void EmitMetadataCli()
        {
            CliEmitter.Emit(CliEmitOptions.@default());
            ApiMd.EmitMsil();
        }
    }
}
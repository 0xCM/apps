//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("api/emit/msil")]
        Outcome EmitMsil(CmdArgs args)
            => ApiMetadata.EmitMsil();
    }
}
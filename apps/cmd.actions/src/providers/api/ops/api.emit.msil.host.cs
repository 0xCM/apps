//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/msil/host")]
        Outcome EmitHostMsil(CmdArgs args)
            => ApiMetadata.EmitHostMsil(arg(args,0));
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/emit/msil-host")]
        void EmitHostMsil(CmdArgs args)
            => ApiMetadata.EmitHostMsil(arg(args,0));
    }
}
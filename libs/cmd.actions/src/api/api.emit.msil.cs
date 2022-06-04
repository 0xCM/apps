//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiActionCmd
    {
        [CmdOp("api/emit/msil-host")]
        void EmitHostMsil(CmdArgs args)
            => ApiMd.EmitHostMsil(arg(args,0));
    }
}
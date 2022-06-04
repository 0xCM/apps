//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiActionCmd
    {
        [CmdOp("api/capture")]
        void Capture(CmdArgs args)
            => Wf.ApiCapture().Run(args);
    }
}
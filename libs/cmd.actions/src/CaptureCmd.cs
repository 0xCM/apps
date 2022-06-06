//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class CaptureCmd : AppCmdProvider<CaptureCmd>
    {
        [CmdOp("api/capture")]
        void Capture(CmdArgs args)
            => Wf.ApiCapture().Run(args);
    }
}
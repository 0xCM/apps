//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CaptureCmd : AppCmdService<CaptureCmd>
    {
        [CmdOp("api/capture")]
        void Capture(CmdArgs args)
            => Wf.ApiCapture().Run(args);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial class GlobalCommands
    {
        [CmdOp("capture")]
        protected Outcome CaptureV1(CmdArgs args)
        {
            var result = Capture.run();
            return true;
        }

        [CmdOp("capture-v2")]
        protected Outcome CaptureV2(CmdArgs args)
        {
           Wf.ApiExtractWorkflow().Run(args);
           return true;
        }
    }
}
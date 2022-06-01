//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class CaptureCmd : AppCmdProvider<CaptureCmd>
    {
        AsmCallPipe AsmCalls => Service(Wf.AsmCallPipe);

        AsmDecoder AsmDecoder => Service(Wf.AsmDecoder);
    }
}
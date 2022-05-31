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
        ApiPacks ApiPacks => Service(Wf.ApiPacks);

        ApiHexPacks ApiHexPacks => Wf.HexPack();

        AsmCallPipe AsmCalls => Service(Wf.AsmCallPipe);

        AsmDecoder AsmDecoder => Service(Wf.AsmDecoder);


    }

}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct ApiExtracts
    {
        const int DefaultBufferLength = Pow2.T14 + Pow2.T08;

        const int MaxZeroCount = 10;

        const byte ZED = 0;

        const byte RET = 0xc3;

        const byte INTR = 0xcc;

        const byte SBB = 0x19;

        const byte FF = 0xff;

        const byte E0 = 0xe0;

        const byte J48 = 0x48;
    }
}
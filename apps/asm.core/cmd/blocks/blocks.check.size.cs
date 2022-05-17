//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = Asm.AsmOcTokenKind;
    using P = Pow2x32;

    partial class AsmCoreCmd
    {
        [CmdOp("blocks/check/size")]
        Outcome CheckBlockSize(CmdArgs args)
        {
            ByteBlock4 block4 = 0xFF000000;
            Write(Storage.trim(block4).Format());

            ByteBlock4 block3 = 0xFF0000;
            Write(Storage.trim(block3).Format());

            ByteBlock4 block2 =  0xFF00;
            Write(Storage.trim(block2).Format());

            ByteBlock4 block1 =  0xFF;
            Write(Storage.trim(block1).Format());

            ByteBlock4 block0 =  0x0;
            Write(Storage.trim(block0).Format());
            return true;
        }
    }
}
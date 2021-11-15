//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;
    using static Root;

    partial class AsmCmdService
    {
        ReadOnlySpan<byte> Input => new byte[]{0x44, 0x01, 0x58,0x04};

        const string InputBitsA = "0100 0100 0000 0001 0101 1000 0000 0100";

        const uint InputBitsB = 0b0100_0100_0000_0001_0101_1000_0000_0100;

        [CmdOp(".test-bitstrings")]
        Outcome CheckBitstrings(CmdArgs args)
        {
            CharBlocks.alloc(n128, out var block1);
            var count = AsmBitstring.render(Input, block1.Data);
            var chars = slice(block1.Data,0,count);
            var bits = text.format(chars);
            Wf.Row(InputBitsA);
            Wf.Row(bits);

            CharBlocks.alloc(n128, out var block2);
            count = AsmBitstring.bitstring(bytes(InputBitsB), block2.Data);
            bits = text.format(chars);
            Wf.Row(bits);
            return true;
        }

        [CmdOp(".test-bits")]
        Outcome CheckBits(CmdArgs args)
        {
            var v = vpack.vunpack256x8u(0xF0F0F0F0);
            Write(v.FormatBlockedBits(8));
            return true;
        }

        void CheckBitFormatter()
        {
            var block = CharBlock128.Null;
            var buffer = block.Data;
            var input = 0b1100_0111_0101u;
            var n = 12u;
            var data = bytes(input);
            ref readonly var b0 = ref skip(data,0);
            ref readonly var b1 = ref skip(data,1);
            var i=0u;
            BitRender.render(b0, ref i, 8, buffer);
            seek(buffer,i++) = Chars.Underscore;
            BitRender.render(b1, ref i, 4, buffer);
            Write(block.Format());
        }
    }
}
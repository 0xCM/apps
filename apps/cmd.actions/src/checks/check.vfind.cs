//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial class CheckCmdProvider
    {
       static ReadOnlySpan<byte> x7ffaa76f0ae0
            => new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x50,0x0f,0x24,0xa5,0xfa,0x7f,0x00,0x00,0x48,0xb8,0x30,0xdd,0x99,0xa6,0xfa,0x7f,0x00,0x00,0x48,0xff,0xe0,0};

        [CmdOp("check/vfind")]
        Outcome CheckV(CmdArgs args)
        {
            const byte count = 32;
            const byte Target = 0x48;
            var mask = cpu.vindices(cpu.vload(w256,x7ffaa76f0ae0), Target);
            var bits = recover<bit>(Cells.alloc(w256).Bytes);
            var buffer = Cells.alloc(w256).Bytes;
            BitPack.unpack1x32x8(mask, bits);
            var j=z8;
            for(byte i=0; i<count; i++)
            {
                if(skip(bits,i))
                    seek(buffer,j++) = i;
            }

            var indices = slice(buffer,0,j);
            Require.equal(skip(indices,0),5);
            Require.equal(skip(indices,1),8);
            Require.equal(skip(indices,2),18);
            Require.equal(skip(indices,3),28);

            return true;
        }
    }
}
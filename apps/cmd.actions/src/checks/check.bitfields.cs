//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/bitfields")]
        Outcome CheckBitFields(CmdArgs args)
        {
            var storage = ByteBlock32.Empty;
            var buffer = storage.Bytes;
            byte segwidth = 8;
            ReadOnlySpan<byte> indices = new byte[]{3,33,59,61,101,203};
            gbits.enable(buffer, indices);
            var segcount = buffer.Length;
            for(var i=z8; i<segcount; i++)
            {
                ref readonly var cell = ref skip(buffer,i);
                var offset = (byte)(i*segwidth);
                if(cell != 0)
                {
                    var seg = Bitfields.segment(cell, offset, segwidth);
                    Write(seg.Format());
                }
            }

            return true;
        }
    }
}
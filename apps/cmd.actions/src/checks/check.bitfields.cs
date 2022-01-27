//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static Asm.RegClasses;

    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/bitfields")]
        Outcome CheckBitFields(CmdArgs args)
        {
            var storage = ByteBlock32.Empty;
            var buffer = storage.Bytes;
            var segwidth = 8u;
            ReadOnlySpan<uint> indices = new uint[]{3,33,59,61,101,203,222,224,225,226};
            gbits.enable(buffer, indices);
            var segcount = buffer.Length;
            for(var i=0u; i<segcount; i++)
            {
                ref readonly var cell = ref skip(buffer,i);
                var offset = i*segwidth;
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
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class IntelSdm
    {
        public static Index<SdmSigOpCode> summarize(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<SdmSigOpCode>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                opcode(skip(src,i), out seek(dst,i));
            return buffer;
        }
    }
}
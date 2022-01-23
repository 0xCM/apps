//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial struct SdmOps
    {
        [Op]
        public static Index<AsmForm> forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmForm>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                seek(dst,i) = asm.form(sig(record), record.OpCode);
            }
            return buffer;
        }
    }
}
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
        public static Index<AsmFormExpr> forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmFormExpr>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                seek(dst,i) = AsmFormExpr.define(sig(record), record.OpCode);
            }
            return buffer;
        }
    }
}
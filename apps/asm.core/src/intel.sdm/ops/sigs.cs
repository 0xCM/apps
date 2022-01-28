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
        public static Index<AsmSigExpr> sigs(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var dst = dict<string,AsmSigExpr>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                var value = sig(record);
                dst.TryAdd(value.Format(), value);
            }
            return dst.Values.Array();
        }
    }
}
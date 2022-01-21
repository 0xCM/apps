//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct SdmOps
    {
        [Op]
        public static Outcome<uint> rows(ReadOnlySpan<TextLine> src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var result = Outcome.Success;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                result = row(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      term.warn(result.Message);
            }
            return (true,counter);
        }

        [Op]
        public static Outcome<uint> rows(ReadOnlySpan<TextLine> src, Span<AsmSigOpCode> dst)
        {
            var counter = 0u;
            var result = Outcome.Success;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                result = row(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      term.warn(result.Message);
            }
            return (true,counter);
        }
    }
}
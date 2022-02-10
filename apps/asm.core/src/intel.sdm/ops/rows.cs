//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

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
                result = detail(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      term.warn(result.Message);
            }
            return (true,counter);
        }
    }
}
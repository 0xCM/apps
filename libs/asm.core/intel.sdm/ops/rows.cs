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
        public static uint rows(ReadOnlySpan<TextLine> src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var result = Outcome.Success;
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                result = detail(skip(src,i), out seek(dst, i));
                if(result.Fail)
                      Errors.Throw(result.Message);
            }
            return count;
        }
    }
}
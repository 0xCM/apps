//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Resources
    {
        [Op]
        public static ApiCodeRes code(string id, ReadOnlySpan<CodeBlock> src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new BinaryResSpec(string.Format("{0}_{1}", id, i), skip(src,i));
            return new ApiCodeRes(buffer);
        }
    }
}
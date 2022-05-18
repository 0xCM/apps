//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline)]
        public static BpDef def(BfOrigin origin, in asci32 name, in asci64 content)
            => new BpDef(origin, name, content);

        public static Index<BpDef> defs(ReadOnlySpan<BpInfo> src)
        {
            var count = src.Length;
            var dst = alloc<BpDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).Def;
            return dst;
        }
    }
}
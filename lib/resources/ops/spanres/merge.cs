//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial struct SpanRes
    {
        [Op]
        public static ByteSpanSpec merge(Identifier name, ByteSpanSpecs props)
        {
            var buffer = alloc<byte>(props.TotalSize);
            var c0 = props.Count;
            ref var dst = ref first(buffer);
            var view = props.View;
            var k=0;
            for(var i=0; i<c0; i++)
            {
                ref readonly var prop = ref skip(view,i);
                ref readonly var src = ref prop.FirstByte;
                var c1 = prop.Data.Count;
                for(var j=0; j<c1; j++, k++)
                    seek(dst,k) = skip(src,j);
            }
            return specify(name, buffer, props.First.IsStatic);
        }
    }
}
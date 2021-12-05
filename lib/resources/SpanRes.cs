//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct SpanRes
    {
        [Op]
        static SpanResKind ResKind(Type match)
        {
            ref readonly var src = ref first(span(ResAccessorTypes));
            var kind = SpanResKind.None;
            if(skip(src,0).Equals(match))
                kind = SpanResKind.ByteSpan;
            else if(skip(src,1).Equals(match))
                kind = SpanResKind.CharSpan;
            return kind;
        }
    }
}
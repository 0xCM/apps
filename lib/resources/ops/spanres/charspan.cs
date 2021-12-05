//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SpanRes
    {
        [MethodImpl(Inline), Op]
        public static CharSpanSpec charspan(Identifier name, string data, bool @static = true)
            => new CharSpanSpec(name, data, @static);
    }
}
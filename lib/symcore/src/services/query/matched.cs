//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static TextMatch matched(TextMarker marker, LineOffset offset)
            => new TextMatch(marker,offset);
    }
}
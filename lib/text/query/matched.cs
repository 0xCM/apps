//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static TextMatch matched(TextMarker marker, LineOffset offset)
            => new TextMatch(marker,offset);
    }
}
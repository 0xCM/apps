//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static TextMarker marker(string id, string src)
            => new TextMarker(id, src);
    }
}
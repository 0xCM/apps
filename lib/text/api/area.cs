//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static TextArea area(LineNumber minline, ushort mincol, LineNumber maxline, ushort maxcol)
            =>  new TextArea(minline, mincol, maxline,maxcol);
    }
}
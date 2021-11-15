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
        public static TextLine line(uint number, string src)
            => new TextLine(number, src);

        [MethodImpl(Inline), Op]
        public static TextLine line(uint number, TextRow src)
            => new TextLine(number, src.RowText);
    }
}
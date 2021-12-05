//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        [Op]
        public static RowHeader ToRowHeader(this TextDocHeader src, string delimiter, ReadOnlySpan<byte> widths)
            => Tables.header(src, delimiter, widths);
    }
}
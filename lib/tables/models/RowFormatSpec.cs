//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines formatting specifications for each cell in a row
    /// </summary>
    public readonly struct RowFormatSpec
    {
        public RowHeader Header {get;}

        public Index<CellFormatSpec> Cells {get;}

        public string Pattern {get;}

        public ushort RowPad {get;}

        [MethodImpl(Inline)]
        public RowFormatSpec(RowHeader header, CellFormatSpec[] src, string pattern, ushort rowpad = 0)
        {
            Header = header;
            Cells = src;
            Pattern = pattern;
            RowPad = rowpad;
        }
    }
}
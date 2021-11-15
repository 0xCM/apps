//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct HeaderCell : ITextual, IComparable<HeaderCell>
    {
        public uint Index {get;}

        public Name Name {get;}

        public RenderWidth Width {get;}

        public CellFormatSpec CellFormat {get;}

        [MethodImpl(Inline)]
        public HeaderCell(uint index, string name, RenderWidth width)
        {
            Index = index;
            Name = name ?? "!null!";
            Width = width;
            CellFormat = new CellFormatSpec("{0}", width);
        }

        [MethodImpl(Inline)]
        public string Format()
            => RP.rpad(Name, Width);

        [MethodImpl(Inline)]
        public int CompareTo(HeaderCell src)
            => Index.CompareTo(src.Index);

        public static HeaderCell Empty
            => new HeaderCell(0, EmptyString, 0);
    }
}
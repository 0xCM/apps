//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static FormatFunctions;

    public readonly ref struct DelimitedSpan<T>
    {
        public ReadOnlySpan<T> Data {get;}

        public char Delimiter {get;}

        public int CellPad {get;}

        readonly FormatCells<T> Render;

        [MethodImpl(Inline)]
        public DelimitedSpan(ReadOnlySpan<T> src, char delimiter = FieldDelimiter, int pad = 0)
        {
            Data = src;
            Delimiter = delimiter;
            Render = text.delimit;
            CellPad = pad;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Render(Data, Delimiter, CellPad);

        public override string ToString()
            => Format();
    }
}
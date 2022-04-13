//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FormatDelegates;

    [DataType("despan<{0}>")]
    public readonly ref struct DelimitedSpan<T>
    {
        public readonly ReadOnlySpan<T> Data;

        public readonly char Delimiter;

        public readonly int CellPad;

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
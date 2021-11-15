//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class TextGrid
    {
        public Index<TextRow> RowData {get;}

        public TextDocFormat Format {get;}

        public TextDocHeader Header {get;}

        public uint RowCount {get;}

        public uint ColCount {get;}

        [MethodImpl(Inline)]
        public TextGrid(TextDocFormat format, TextDocHeader header, params TextRow[] rows)
        {
            RowData = rows;
            Header = header;
            Format = format;
            RowCount = RowData.Count;
            ColCount = RowData.IsEmpty ? 0u : (uint)RowData.First.CellCount;
        }

        public ReadOnlySpan<TextRow> Rows
        {
            [MethodImpl(Inline)]
            get => RowData.View;
        }

        public TextRow[] Storage
        {
            [MethodImpl(Inline)]
            get => RowData.Storage;
        }

        public ref readonly TextRow this[int index]
        {
            [MethodImpl(Inline)]
            get => ref RowData[index];
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Rows.Length;
        }

        public bool HasHeader
        {
            [MethodImpl(Inline)]
            get => Header.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => RowCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => RowCount != 0;
        }

        public static TextGrid Empty
            => new TextGrid(TextDocFormat.Empty, default, sys.empty<TextRow>());
    }
}
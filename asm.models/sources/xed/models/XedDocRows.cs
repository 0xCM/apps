//-----------------------------------------------------------------------------
// Copyright   : (c) Chris Moore, 2020
// License     : MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct XedDocRows
    {
        public readonly FS.FilePath Source;

        readonly Index<TextRow> Data;

        [MethodImpl(Inline)]
        public XedDocRows(FS.FilePath src, Index<TextRow> rows)
        {
            Source = src;
            Data = rows;
        }

        public ref readonly TextRow this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline), Op]
            get => Data.IsNonEmpty;
        }

        public uint RowCount
            => Data.Count;

        public ReadOnlySpan<TextRow> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public static XedDocRows Empty
        {
            [MethodImpl(Inline)]
            get => new XedDocRows(FS.FilePath.Empty, Index<TextRow>.Empty);
        }
    }
}
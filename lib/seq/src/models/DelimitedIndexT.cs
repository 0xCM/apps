//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static FormatFunctions;

    [DataType("index<{0}>")]
    public readonly struct DelimitedIndex<T> : IIndex<T>, ITextual
    {
        public Index<T> Data {get;}

        public char Delimiter {get;}

        public int CellPad {get;}

        readonly FormatCells<T> Render;

        [MethodImpl(Inline)]
        public DelimitedIndex(T[] src, char delimiter = ListDelimiter, int pad = 0)
        {
            Data = src;
            Delimiter = delimiter;
            Render = text.delimit;
            CellPad = pad;
        }

        [MethodImpl(Inline)]
        public DelimitedIndex(T[] src, FormatCells<T> fx, char delimiter = ListDelimiter, int pad = 0)
        {
            Data = src;
            Delimiter = delimiter;
            Render = fx;
            CellPad = pad;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Render(Data, Delimiter, CellPad);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DelimitedIndex<T>(T[] src)
            => new DelimitedIndex<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator DelimitedIndex<T>(Index<T> src)
            => new DelimitedIndex<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator DelimitedIndex<T>(List<T> src)
            => new DelimitedIndex<T>(src.ToArray());
    }
}
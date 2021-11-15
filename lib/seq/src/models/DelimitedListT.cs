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

    [DataType("list<{0}>")]
    public readonly struct DelimitedList<T> : ITextual
    {
        readonly List<T> Data;

        public SeqEnclosureKind Kind {get;}

        public char Delimiter {get;}

        [MethodImpl(Inline)]
        public DelimitedList(char delimiter = Chars.Comma, SeqEnclosureKind kind = SeqEnclosureKind.Embraced)
        {
            Data = new ();
            Kind = kind;
            Delimiter = delimiter;
        }

        [MethodImpl(Inline)]
        public DelimitedList(T[] src, char delimiter =  Chars.Comma, SeqEnclosureKind kind = SeqEnclosureKind.Embraced )
        {
            Data = new List<T>(src);
            Kind = kind;
            Delimiter = delimiter;
        }

        [MethodImpl(Inline)]
        public void Add(in T src)
        {
            Data.Add(src);
        }

        public uint ItemCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public ReadOnlySpan<T> Items
            => Data.ViewDeposited();
        public string Format()
            => string.Concat(seq.left(Kind), text.delimit(Data, Delimiter), seq.right(Kind));

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DelimitedList<T>(T[] src)
            => new DelimitedList<T>(src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LiteralSeq<T> : IIndex<Literal<T>>
    {
        Index<Literal<T>> _Terms {get;}

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public LiteralSeq(Identifier name, Literal<T>[] src)
        {
            Name = name;
            _Terms = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => _Terms.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => _Terms.Length;
        }

        public ReadOnlySpan<Literal<T>> View
        {
            [MethodImpl(Inline)]
            get => _Terms.Edit;
        }

        public Span<Literal<T>> Edit
        {
            [MethodImpl(Inline)]
            get => _Terms.Edit;
        }

        public Literal<T>[] Storage
        {
            get => _Terms;
        }

        public ref Literal<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref _Terms[index];
        }

        public ref Literal<T> this[long index]
        {
            [MethodImpl(Inline)]
            get => ref _Terms[index];
        }

        public string Format()
            => ExprFormatters.LiteralSeq<T>().Format(this);

        public override string ToString()
            => Format();
    }
}
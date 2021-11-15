//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LiteralSeq<T>
    {
        Index<Literal<T>> _Terms {get;}

        public Label Name {get;}

        [MethodImpl(Inline)]
        public LiteralSeq(Label name, Literal<T>[] src)
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

        public Span<Literal<T>> Terms
        {
            [MethodImpl(Inline)]
            get => _Terms.Edit;
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
    }
}
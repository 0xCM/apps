//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct LiteralSeq<T>
        {
            Index<NamedValue<T>> _Terms {get;}

            [MethodImpl(Inline)]
            public LiteralSeq(NamedValue<T>[] src)
            {
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

            public Span<NamedValue<T>> Terms
            {
                [MethodImpl(Inline)]
                get => _Terms.Edit;
            }

            public ref NamedValue<T> this[ulong index]
            {
                [MethodImpl(Inline)]
                get => ref _Terms[index];
            }

            public ref NamedValue<T> this[long index]
            {
                [MethodImpl(Inline)]
                get => ref _Terms[index];
            }

        }
    }
}
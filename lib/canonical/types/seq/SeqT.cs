//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Seq<T> : ISeq<T>
        where T : IType
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public Seq(T[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator Seq<T>(T[] src)
            => new Seq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](Seq<T> src)
            => src;
    }
}
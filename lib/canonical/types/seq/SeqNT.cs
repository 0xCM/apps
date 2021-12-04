//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Seq<N,T> : ISeq<N,T>
        where N : unmanaged, ITypeNat
        where T : IType
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        internal Seq(T[] src)
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
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.CodeAnalysis;

    using static Root;
    using static core;

    public sealed class CaSymbols<T> : CaSymbols<CaSymbols<T>,T>, ICaSymbols<T>
        where T : ISymbol
    {
        public CaSymbols()
        {

        }

        public CaSymbols(uint count)
            : base(count)
        {

        }

        [MethodImpl(Inline)]
        public CaSymbols(T[] src)
        {
            Data = src;
        }

        public ref CaSymbol<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }

        public new Span<CaSymbol<T>> Edit
        {
            [MethodImpl(Inline)]
            get => recover<T,CaSymbol<T>>(base.Edit);
        }

        public new ReadOnlySpan<CaSymbol<T>> View
        {
            [MethodImpl(Inline)]
            get => recover<T,CaSymbol<T>>(base.View);
        }

        [MethodImpl(Inline)]
        public static implicit operator CaSymbols<T>(T[] src)
            => new CaSymbols<T>(src);
    }
}
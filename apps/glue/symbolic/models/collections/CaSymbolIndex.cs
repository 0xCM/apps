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

    public sealed class CaSymbolIndex : CaSymbols<CaSymbolIndex,ISymbol>, ICaSymbols<ISymbol>
    {
        public CaSymbolIndex()
        {

        }

        public CaSymbolIndex(uint count)
            : base(count)
        {

        }

        [MethodImpl(Inline)]
        public CaSymbolIndex(ISymbol[] src)
        {
            Data = src;
        }

        public new Span<CaSymbol> Edit
        {
            [MethodImpl(Inline)]
            get => recover<ISymbol,CaSymbol>(base.Edit);
        }

        public new ReadOnlySpan<CaSymbol> View
        {
            [MethodImpl(Inline)]
            get => recover<ISymbol,CaSymbol>(base.View);
        }

        public ref CaSymbol this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }

        [MethodImpl(Inline)]
        public static implicit operator CaSymbolIndex(ISymbol[] src)
            => new CaSymbolIndex(src);
    }
}
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

    public sealed class CodeSymbolIndex : CodeSymbols<CodeSymbolIndex,ISymbol>, ICodeSymbols<ISymbol>
    {
        public CodeSymbolIndex()
        {

        }

        public CodeSymbolIndex(uint count)
            : base(count)
        {

        }

        [MethodImpl(Inline)]
        public CodeSymbolIndex(ISymbol[] src)
        {
            Data = src;
        }

        public new Span<CodeSymbol> Edit
        {
            [MethodImpl(Inline)]
            get => recover<ISymbol,CodeSymbol>(base.Edit);
        }

        public new ReadOnlySpan<CodeSymbol> View
        {
            [MethodImpl(Inline)]
            get => recover<ISymbol,CodeSymbol>(base.View);
        }

        public ref CodeSymbol this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,index);
        }

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbolIndex(ISymbol[] src)
            => new CodeSymbolIndex(src);
    }
}
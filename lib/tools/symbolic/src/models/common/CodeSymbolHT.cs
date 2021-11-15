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

    using api = CodeSymbols;

    public readonly struct CodeSymbol<H,T> : ICodeSymbol<H,T>
        where T : ISymbol
        where H : new()
    {
        readonly CodeSymbols<H,T> _Source;

        readonly uint Index;

        [MethodImpl(Inline)]
        internal CodeSymbol(CodeSymbols<H,T> src, uint index)
        {
            _Source  = src;
            Index = index;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source != null;
        }

        public T Source
        {
            [MethodImpl(Inline)]
            get => _Source.Subject(Index);
        }

        public SymbolKind Kind => Source.Kind;

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        ISymbol ICodeSymbol.Source
            => Source;

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbol<T>(CodeSymbol<H,T> src)
            => new CodeSymbol<T>(src.Source);
    }
}
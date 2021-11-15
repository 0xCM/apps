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

    public readonly struct CodeSymbol<T> : ICodeSymbol<T>
        where T : ISymbol
    {
        public T Source {get;}

        [MethodImpl(Inline)]
        public CodeSymbol(T src)
        {
            Source = src;
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

        public ISymbol Untyped
        {
            [MethodImpl(Inline)]
            get => Source;
        }

        public SymbolKind Kind
        {
            [MethodImpl(Inline)]
            get => Untyped.Kind;
        }

        public string Language
        {
            [MethodImpl(Inline)]
            get => Untyped.Language;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Untyped.Name;
        }

        public string MetadataName
        {
            [MethodImpl(Inline)]
            get => Untyped.MetadataName;
        }


        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CodeSymbol(CodeSymbol<T> src)
            => new CodeSymbol(src.Untyped);
    }
}
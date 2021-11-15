//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.CodeAnalysis;

    using static CodeSymbolModels;

    public ref struct CodeSymbolSet
    {
        internal CodeSymbolSet(params MetadataReference[] metadata)
            : this()
        {
            Metadata = metadata;
        }

        public ReadOnlySpan<CodeSymbol> Untyped {get; private set;}

        public ReadOnlySpan<MetadataReference> Metadata {get;}

        public ReadOnlySpan<AssemblySymbol> Assemblies {get; private set;}

        public ReadOnlySpan<TypeSymbol> Types {get; private set;}

        public ReadOnlySpan<MethodSymbol> Methods {get; private set;}

        public CodeSymbolSet Replace(ReadOnlySpan<CodeSymbol> src)
        {
            Untyped = src;
            return this;
        }

        public CodeSymbolSet Replace(ReadOnlySpan<AssemblySymbol> src)
        {
            Assemblies = src;
            return this;
        }

        public CodeSymbolSet Replace(ReadOnlySpan<TypeSymbol> src)
        {
            Types = src;
            return this;
        }

        public CodeSymbolSet Replace(ReadOnlySpan<MethodSymbol> src)
        {
            Methods = src;
            return this;
        }

        public static CodeSymbolSet Empty => default;
    }
}
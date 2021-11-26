//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.CodeAnalysis;

    using static CaSymbolModels;

    public ref struct CaSymbolSet
    {
        internal CaSymbolSet(params MetadataReference[] metadata)
            : this()
        {
            Metadata = metadata;
        }

        public ReadOnlySpan<CaSymbol> Untyped {get; private set;}

        public ReadOnlySpan<MetadataReference> Metadata {get;}

        public ReadOnlySpan<AssemblySymbol> Assemblies {get; private set;}

        public ReadOnlySpan<TypeSymbol> Types {get; private set;}

        public ReadOnlySpan<MethodSymbol> Methods {get; private set;}

        public CaSymbolSet Replace(ReadOnlySpan<CaSymbol> src)
        {
            Untyped = src;
            return this;
        }

        public CaSymbolSet Replace(ReadOnlySpan<AssemblySymbol> src)
        {
            Assemblies = src;
            return this;
        }

        public CaSymbolSet Replace(ReadOnlySpan<TypeSymbol> src)
        {
            Types = src;
            return this;
        }

        public CaSymbolSet Replace(ReadOnlySpan<MethodSymbol> src)
        {
            Methods = src;
            return this;
        }

        public static CaSymbolSet Empty => default;
    }
}
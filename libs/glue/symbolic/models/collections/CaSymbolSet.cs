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
            Assemblies = sys.empty<AssemblySymbol>();
            Types = sys.empty<TypeSymbol>();
            Methods = sys.empty<MethodSymbol>();
            Fields = sys.empty<FieldSymbol>();
        }

        public ReadOnlySpan<MetadataReference> Metadata {get;}

        public ReadOnlySpan<AssemblySymbol> Assemblies {get; internal set;}

        public ReadOnlySpan<TypeSymbol> Types {get; internal set;}

        public ReadOnlySpan<MethodSymbol> Methods {get; internal set;}

        public ReadOnlySpan<FieldSymbol> Fields {get; internal set;}


        public static CaSymbolSet Empty => default;
    }
}
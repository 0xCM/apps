//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.CodeAnalysis;
    using OmniSharp.Roslyn.CSharp.Services.Documentation;
    using OmniSharp.Models.TypeLookup;

    using static Root;
    using static CodeSymbolModels;
    using static XmlParts;
    using static core;

    [ApiHost]
    public readonly struct CodeSymbols
    {
        public static string format<T>(T src)
            where T : ICodeSymbol
                => src.Source?.ToDisplayString() ?? "<null>";

        [MethodImpl(Inline)]
        public static CodeSymbolKey<T> symkey<T>(T symbol, ulong key)
            where T : ICodeSymbol
                => (symbol,key);

        [MethodImpl(Inline), Op]
        public static CodeSymbolSet set(params MetadataReference[] metadata)
            => new CodeSymbolSet(metadata);

        [Op]
        public static CodeSymbolLookup lookup(CodeSymbolKey[] src)
            => new CodeSymbolLookup(src);

        [MethodImpl(Inline), Op]
        public static CodeSymbol from(ISymbol src)
            => new CodeSymbol(src);

        [MethodImpl(Inline), Op]
        public static AssemblySymbol from(IAssemblySymbol src)
            => new AssemblySymbol(src);

        [MethodImpl(Inline), Op]
        public static ModuleSymbol from(IModuleSymbol src)
            => new ModuleSymbol(src);

        [MethodImpl(Inline), Op]
        public static NamespaceSymbol from(INamespaceSymbol src)
            => new NamespaceSymbol(src);

        [MethodImpl(Inline), Op]
        public static NamedTypeSymbol from(INamedTypeSymbol src)
            => new NamedTypeSymbol(src);

        [MethodImpl(Inline), Op]
        public static TypeSymbol from(ITypeSymbol src)
            => new TypeSymbol(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> convert<T>(ReadOnlySpan<CodeSymbol> src)
            where T : ICodeSymbol
                => recover<CodeSymbol,T>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> materialize<S,T>(ReadOnlySpan<S> src, T target = default)
            where S : ISymbol
            where T : ICodeSymbol
                => recover<S,T>(src);

        [MethodImpl(Inline)]
        public static ReadOnlySpan<CodeSymbol> materialize<S>(ReadOnlySpan<S> src)
            where S : ISymbol
                => recover<S,CodeSymbol>(src);

        [MethodImpl(Inline)]
        public static CodeSymbols<T> index<T>(T[] src)
            where T : ISymbol
                => src;

        [MethodImpl(Inline)]
        public static CodeSymbol<T> define<T>(T src)
            where T : ISymbol
                => new CodeSymbol<T>(src);

        [MethodImpl(Inline), Op]
        public static DocumentationComment docs(XmlText xml)
            => DocumentationConverter.GetStructuredDocumentation(xml.Value, "\n");

        [MethodImpl(Inline), Op]
        public static DocumentationComment docs(ISymbol src)
            => DocumentationConverter.GetStructuredDocumentation(src);
    }
}
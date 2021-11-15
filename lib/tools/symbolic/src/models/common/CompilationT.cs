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
    using static CodeSymbolModels;

    using api = CodeSymbols;

    public readonly struct Compilation<T> : INullity
        where T : Compilation
    {
        public T Source {get;}

        [MethodImpl(Inline)]
        public Compilation(T src)
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

        public AssemblySymbol Assembly
        {
            [MethodImpl(Inline)]
            get => api.from(Source.Assembly);
        }

        public CompilationOptions Options
            => Source.Options;

        public Deferred<SyntaxTree> SyntaxTrees
            => core.defer(Source.SyntaxTrees);

        public ReadOnlySpan<MetadataReference> ExternalReferences
            => Source.ExternalReferences.AsSpan();

        public ReadOnlySpan<MetadataReference> DirectiveReferences
            => Source.DirectiveReferences.AsSpan();

        public Deferred<MetadataReference> References
            => core.defer(Source.References);

        public Deferred<AssemblyIdentity> ReferencedAssemblyNames
            => core.defer(Source.ReferencedAssemblyNames);

        public AssemblySymbol GetAssemblySymbol(MetadataReference src)
            => new AssemblySymbol((IAssemblySymbol)Source.GetAssemblyOrModuleSymbol(src));

        public MetadataReference GetMetadataReference(IAssemblySymbol src)
            => Source.GetMetadataReference(src);

        [MethodImpl(Inline)]
        public static implicit operator Compilation<T>(T src)
            => new Compilation<T>(src);
    }
}
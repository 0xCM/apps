//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    using static XmlParts;

    using OmniSharp.Roslyn.CSharp.Services.Documentation;
    using OmniSharp.Models.TypeLookup;

    [ApiHost]
    public sealed class Roslyn : AppService<Roslyn>
    {
        [Op]
        public Compilation<CSharpCompilation> Compilation(string name, params MetadataReference[] refs)
            => CSharpCompilation.Create(name, references: refs);

        public DocumentationComment GetDocs(XmlText xml)
            => DocumentationConverter.GetStructuredDocumentation(xml.Value, "\n");

        public DocumentationComment GetDocs(ISymbol src)
            => DocumentationConverter.GetStructuredDocumentation(src);
    }
}
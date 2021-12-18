//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.DiaSymReader;

    using static core;
    using static PdbModel;

    partial struct PdbServices
    {
        internal static DocMethodLookup MethodLookup(ISymUnmanagedReader5 src)
        {
            var documents = src.GetDocuments().ToReadOnlySpan();
            var count = documents.Length;
            var dst = new DocMethodLookup();
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref skip(documents,i);
                dst[doc] = src.GetMethodsInDocument(doc);
            }
            return dst;
        }

        internal static DocMethods methods(ISymUnmanagedReader5 reader, ISymUnmanagedDocument doc)
        {
            return new DocMethods(doc,reader.GetMethodsInDocument(doc));
        }
    }
}
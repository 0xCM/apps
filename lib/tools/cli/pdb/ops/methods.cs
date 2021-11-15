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
        internal static DocumentMethods methods(ISymUnmanagedReader5 src)
        {
            var documents = src.GetDocuments().ToReadOnlySpan();
            var count = documents.Length;
            var dst = new DocumentMethods();
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref skip(documents,i);
                dst[doc] = src.GetMethodsInDocument(doc);
            }
            return dst;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static core;
    using static PdbModel;

    public sealed class PdbDataStore
    {
        Dictionary<string, Document> _DocIndex;

        List<Document> _Documents;

        internal PdbDataStore()
        {
            _DocIndex = new();
            _Documents = new();
        }

        internal uint Include(ReadOnlySpan<Document> src)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref skip(src,i);
                if(_DocIndex.TryAdd(doc.Name, doc))
                {
                    _Documents.Add(doc);
                    counter++;
                }

            }
            return counter;
        }

        public ReadOnlySpan<Document> Documents
            => _Documents.ViewDeposited();
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class PdbDocuments
    {
        Dictionary<string, PdbDocument> _DocIndex;

        List<PdbDocument> _Documents;

        public PdbDocuments()
        {
            _DocIndex = new();
            _Documents = new();
        }

        public uint Include(ReadOnlySpan<PdbDocument> src)
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

        public ReadOnlySpan<PdbDocument> Documents
            => _Documents.ViewDeposited();
    }
}
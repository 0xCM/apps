//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedImport
    {
        public class InstImportBlocks
        {
            public SortedLookup<InstForm,uint> Forms;

            public Index<InstBlockImport> Imports;

            public InstBlockLines BlockLines;

            public LineMap<InstBlockLineSpec> LineMap;

            public ConcurrentDictionary<InstForm,string> FormBlocks;

            public ConcurrentDictionary<InstForm,string> FormHeaders;

            public string Description(InstForm form)
                => FormBlocks[form];

            public string Header(InstForm form)
                => FormHeaders[form];
        }
    }
}